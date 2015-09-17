# An attempt to fix the problem of uploading 136-byte ('boxed') Pokemon to
# the DS. This should properly generate the battle stats so it can be read
# by the games.

from __future__ import division
from array import array
from stats import evcheck, ivcheck

pkm = None

def makeparty(p):
    global pkm
    pkm = array('B')
    pkm.fromstring(p)

    lv = __level()
    id = pkm[0x08] + (pkm[0x09] << 8)

    s = ''
    s += '\x00' * 4      # 0x88 to 0x8b
    s += chr(lv)         # 0x8c
    s += '\x00'          # 0x8d
    s += __stats(lv, id) # 0x8e to 0x9b
    s += '\x00' * 5      # 0x9c to 0xa0
    s += '\x02'          # 0xa1
    s += '\x07'          # 0xa2
    s += '\xff' * 23     # 0xa3 to 0xb9
    s += '\x00' * 2      # 0xba to 0xbb
    s += '\xff' * 2      # 0xbc to 0xbd
    if pkm[0x40] & 4:    # 0xbe to 0xbf; de01 if genderless, 0000 otherwise
        s += '\xde\x01'
    else:
        s += '\x00\x00'
    s += '\xff' * 7      # 0xc0 to 0xc6
    s += '\x88'          # 0xc7
    s += '\x01'          # 0xc8
    s += '\xff' * 5      # 0xc9 to 0xcd
    s += '\xac'          # 0xce
    s += '\x01'          # 0xcf
    s += '\xff' * 4      # 0xd0 to 0xd3
    s += '\x00' * 23     # 0xd4 to 0xea
    s += '\x07'          # 0xeb

    return p + s

def __level():
    exp = pkm[0x10] + (pkm[0x11] << 8) + (pkm[0x12] << 16)
    id = pkm[0x08] + (pkm[0x09] << 8)
    exptype = pokestats.get(id)[0]
    for i in xrange(100):
        xpneeded = lvlexp.get(i + 1)[exptype]
        if xpneeded > exp:
            return i
    return 100

def __stats(level, species):
    base = pokestats.get(species)[1:]
    ivs = ivcheck(pkm[0x38:0x3c])
    evs = evcheck(pkm[0x18:0x1e])[:-1]

    pid = pkm[0] + (pkm[1] << 8) + (pkm[2] << 16) + (pkm[3] << 24)
    nat = nature.get(pid % 25)

    hp = int((((ivs[0] + (2 * base[0]) + (evs[0] / 4) + 100) * level) / 100) \
            + 10)
    hpa = chr(hp >> 8)
    hpb = chr(hp & 0xff)

    atk = __genstat(ivs[1], evs[1], base[1], level, nat[0])
    df = __genstat(ivs[2], evs[2], base[2], level, nat[1])
    spe = __genstat(ivs[3], evs[3], base[5], level, nat[2])
    spa = __genstat(ivs[4], evs[4], base[3], level, nat[3])
    spd = __genstat(ivs[5], evs[5], base[4], level, nat[4])

    # Max HP, Curr HP, followed by remainder of the stats
    return hpb + hpa + hpb + hpa + atk + df + spe + spa + spd

def __genstat(iv, ev, base, level, nat):
    st = int((((iv + (2 * base) + (ev / 4)) * level) / 100) + 5)
    st = int(st * nat)

    sta = chr(st >> 8)
    stb = chr(st & 0xff)
    return stb + sta

# Exp type, HP, Atk, Def, SpA, SpD, Spe Base Stats
pokestats = {
    1: (3, 45, 49, 49, 65, 65, 45),
    2: (3, 60, 62, 63, 80, 80, 60),
    3: (3, 80, 82, 83, 100, 100, 80),
    4: (3, 39, 52, 43, 60, 50, 65),
    5: (3, 58, 64, 58, 80, 65, 80),
    6: (3, 78, 84, 78, 109, 85, 100),
    7: (3, 44, 48, 65, 50, 64, 43),
    8: (3, 59, 63, 80, 65, 80, 58),
    9: (3, 79, 83, 100, 85, 105, 78),
    10: (2, 45, 30, 35, 20, 20, 45),
    11: (2, 50, 20, 55, 25, 25, 30),
    12: (2, 60, 45, 50, 80, 80, 70),
    13: (2, 40, 35, 30, 20, 20, 50),
    14: (2, 45, 25, 50, 25, 25, 35),
    15: (2, 65, 80, 40, 45, 80, 75),
    16: (3, 40, 45, 40, 35, 35, 56),
    17: (3, 63, 60, 55, 50, 50, 71),
    18: (3, 83, 80, 75, 70, 70, 91),
    19: (2, 30, 56, 35, 25, 35, 72),
    20: (2, 55, 81, 60, 50, 70, 97),
    21: (2, 40, 60, 30, 31, 31, 70),
    22: (2, 65, 90, 65, 61, 61, 100),
    23: (2, 35, 60, 44, 40, 54, 55),
    24: (2, 60, 85, 69, 65, 79, 80),
    25: (2, 35, 55, 30, 50, 40, 90),
    26: (2, 60, 90, 55, 90, 80, 100),
    27: (2, 50, 75, 85, 20, 30, 40),
    28: (2, 75, 100, 110, 45, 55, 65),
    29: (3, 55, 47, 52, 40, 40, 41),
    30: (3, 70, 62, 67, 55, 55, 56),
    31: (3, 90, 82, 87, 75, 85, 76),
    32: (3, 46, 57, 40, 40, 40, 50),
    33: (3, 61, 72, 57, 55, 55, 65),
    34: (3, 81, 92, 77, 85, 75, 85),
    35: (1, 70, 45, 48, 60, 65, 35),
    36: (1, 95, 70, 73, 85, 90, 60),
    37: (2, 38, 41, 40, 50, 65, 65),
    38: (2, 73, 76, 75, 81, 100, 100),
    39: (1, 115, 45, 20, 45, 25, 20),
    40: (1, 140, 70, 45, 75, 50, 45),
    41: (2, 40, 45, 35, 30, 40, 55),
    42: (2, 75, 80, 70, 65, 75, 90),
    43: (3, 45, 50, 55, 75, 65, 30),
    44: (3, 60, 65, 70, 85, 75, 40),
    45: (3, 75, 80, 85, 100, 90, 50),
    46: (2, 35, 70, 55, 45, 55, 25),
    47: (2, 60, 95, 80, 60, 80, 30),
    48: (2, 60, 55, 50, 40, 55, 45),
    49: (2, 70, 65, 60, 90, 75, 90),
    50: (2, 10, 55, 25, 35, 45, 95),
    51: (2, 35, 80, 50, 50, 70, 120),
    52: (2, 40, 45, 35, 40, 40, 90),
    53: (2, 65, 70, 60, 65, 65, 115),
    54: (2, 50, 52, 48, 65, 50, 55),
    55: (2, 80, 82, 78, 95, 80, 85),
    56: (2, 40, 80, 35, 35, 45, 70),
    57: (2, 65, 105, 60, 60, 70, 95),
    58: (4, 55, 70, 45, 70, 50, 60),
    59: (4, 90, 110, 80, 100, 80, 95),
    60: (3, 40, 50, 40, 40, 40, 90),
    61: (3, 65, 65, 65, 50, 50, 90),
    62: (3, 90, 85, 95, 70, 90, 70),
    63: (3, 25, 20, 15, 105, 55, 90),
    64: (3, 40, 35, 30, 120, 70, 105),
    65: (3, 55, 50, 45, 135, 85, 120),
    66: (3, 70, 80, 50, 35, 35, 35),
    67: (3, 80, 100, 70, 50, 60, 45),
    68: (3, 90, 130, 80, 65, 85, 55),
    69: (3, 50, 75, 35, 70, 30, 40),
    70: (3, 65, 90, 50, 85, 45, 55),
    71: (3, 80, 105, 65, 100, 60, 70),
    72: (4, 40, 40, 35, 50, 100, 70),
    73: (4, 80, 70, 65, 80, 120, 100),
    74: (3, 40, 80, 100, 30, 30, 20),
    75: (3, 55, 95, 115, 45, 45, 35),
    76: (3, 80, 110, 130, 55, 65, 45),
    77: (2, 50, 85, 55, 65, 65, 90),
    78: (2, 65, 100, 70, 80, 80, 105),
    79: (2, 90, 65, 65, 40, 40, 15),
    80: (2, 95, 75, 110, 100, 80, 30),
    81: (2, 25, 35, 70, 95, 55, 45),
    82: (2, 50, 60, 95, 120, 70, 70),
    83: (2, 52, 65, 55, 58, 62, 60),
    84: (2, 35, 85, 45, 35, 35, 75),
    85: (2, 60, 110, 70, 60, 60, 100),
    86: (2, 65, 45, 55, 45, 70, 45),
    87: (2, 90, 70, 80, 70, 95, 70),
    88: (2, 80, 80, 50, 40, 50, 25),
    89: (2, 105, 105, 75, 65, 100, 50),
    90: (4, 30, 65, 100, 45, 25, 40),
    91: (4, 50, 95, 180, 85, 45, 70),
    92: (3, 30, 35, 30, 100, 35, 80),
    93: (3, 45, 50, 45, 115, 55, 95),
    94: (3, 60, 65, 60, 130, 75, 110),
    95: (2, 35, 45, 160, 30, 45, 70),
    96: (2, 60, 48, 45, 43, 90, 42),
    97: (2, 85, 73, 70, 73, 115, 67),
    98: (2, 30, 105, 90, 25, 25, 50),
    99: (2, 55, 130, 115, 50, 50, 75),
    100: (2, 40, 30, 50, 55, 55, 100),
    101: (2, 60, 50, 70, 80, 80, 140),
    102: (4, 60, 40, 80, 60, 45, 40),
    103: (4, 95, 95, 85, 125, 65, 55),
    104: (2, 50, 50, 95, 40, 50, 35),
    105: (2, 60, 80, 110, 50, 80, 45),
    106: (2, 50, 120, 53, 35, 110, 87),
    107: (2, 50, 105, 79, 35, 110, 76),
    108: (2, 90, 55, 75, 60, 75, 30),
    109: (2, 40, 65, 95, 60, 45, 35),
    110: (2, 65, 90, 120, 85, 70, 60),
    111: (4, 80, 85, 95, 30, 30, 25),
    112: (4, 105, 130, 120, 45, 45, 40),
    113: (1, 250, 5, 5, 35, 105, 50),
    114: (2, 65, 55, 115, 100, 40, 60),
    115: (2, 105, 95, 80, 40, 80, 90),
    116: (2, 30, 40, 70, 70, 25, 60),
    117: (2, 55, 65, 95, 95, 45, 85),
    118: (2, 45, 67, 60, 35, 50, 63),
    119: (2, 80, 92, 65, 65, 80, 68),
    120: (4, 30, 45, 55, 70, 55, 85),
    121: (4, 60, 75, 85, 100, 85, 115),
    122: (2, 40, 45, 65, 100, 120, 90),
    123: (2, 70, 110, 80, 55, 80, 105),
    124: (2, 65, 50, 35, 115, 95, 95),
    125: (2, 65, 83, 57, 95, 85, 105),
    126: (2, 65, 95, 57, 100, 85, 93),
    127: (4, 65, 125, 100, 55, 70, 85),
    128: (4, 75, 100, 95, 40, 70, 110),
    129: (4, 20, 10, 55, 15, 20, 80),
    130: (4, 95, 125, 79, 60, 100, 81),
    131: (4, 130, 85, 80, 85, 95, 60),
    132: (2, 48, 48, 48, 48, 48, 48),
    133: (2, 55, 55, 50, 45, 65, 55),
    134: (2, 130, 65, 60, 110, 95, 65),
    135: (2, 65, 65, 60, 110, 95, 130),
    136: (2, 65, 130, 60, 95, 110, 65),
    137: (2, 65, 60, 70, 85, 75, 40),
    138: (2, 35, 40, 100, 90, 55, 35),
    139: (2, 70, 60, 125, 115, 70, 55),
    140: (2, 30, 80, 90, 55, 45, 55),
    141: (2, 60, 115, 105, 65, 70, 80),
    142: (4, 80, 105, 65, 60, 75, 130),
    143: (4, 160, 110, 65, 65, 110, 30),
    144: (4, 90, 85, 100, 95, 125, 85),
    145: (4, 90, 90, 85, 125, 90, 100),
    146: (4, 90, 100, 90, 125, 85, 90),
    147: (4, 41, 64, 45, 50, 50, 50),
    148: (4, 61, 84, 65, 70, 70, 70),
    149: (4, 91, 134, 95, 100, 100, 80),
    150: (4, 106, 110, 90, 154, 90, 130),
    151: (3, 100, 100, 100, 100, 100, 100),
    152: (3, 45, 49, 65, 49, 65, 45),
    153: (3, 60, 62, 80, 63, 80, 60),
    154: (3, 80, 82, 100, 83, 100, 80),
    155: (3, 39, 52, 43, 60, 50, 65),
    156: (3, 58, 64, 58, 80, 65, 80),
    157: (3, 78, 84, 78, 109, 85, 100),
    158: (3, 50, 65, 64, 44, 48, 43),
    159: (3, 65, 80, 80, 59, 63, 58),
    160: (3, 85, 105, 100, 79, 83, 78),
    161: (2, 35, 46, 34, 35, 45, 20),
    162: (2, 85, 76, 64, 45, 55, 90),
    163: (2, 60, 30, 30, 36, 56, 50),
    164: (2, 100, 50, 50, 76, 96, 70),
    165: (1, 40, 20, 30, 40, 80, 55),
    166: (1, 55, 35, 50, 55, 110, 85),
    167: (1, 40, 60, 40, 40, 40, 30),
    168: (1, 70, 90, 70, 60, 60, 40),
    169: (2, 85, 90, 80, 70, 80, 130),
    170: (4, 75, 38, 38, 56, 56, 67),
    171: (4, 125, 58, 58, 76, 76, 67),
    172: (2, 20, 40, 15, 35, 35, 60),
    173: (1, 50, 25, 28, 45, 55, 15),
    174: (1, 90, 30, 15, 40, 20, 15),
    175: (1, 35, 20, 65, 40, 65, 20),
    176: (1, 55, 40, 85, 80, 105, 40),
    177: (2, 40, 50, 45, 70, 45, 70),
    178: (2, 65, 75, 70, 95, 70, 95),
    179: (3, 55, 40, 40, 65, 45, 35),
    180: (3, 70, 55, 55, 80, 60, 45),
    181: (3, 90, 75, 75, 115, 90, 55),
    182: (3, 75, 80, 85, 90, 100, 50),
    183: (1, 70, 20, 50, 20, 50, 40),
    184: (1, 100, 50, 80, 50, 80, 50),
    185: (2, 70, 100, 115, 30, 65, 30),
    186: (3, 90, 75, 75, 90, 100, 70),
    187: (3, 35, 35, 40, 35, 55, 50),
    188: (3, 55, 45, 50, 45, 65, 80),
    189: (3, 75, 55, 70, 55, 85, 110),
    190: (1, 55, 70, 55, 40, 55, 85),
    191: (3, 30, 30, 30, 30, 30, 30),
    192: (3, 75, 75, 55, 105, 85, 30),
    193: (2, 65, 65, 45, 75, 45, 95),
    194: (2, 55, 45, 45, 25, 25, 15),
    195: (2, 95, 85, 85, 65, 65, 35),
    196: (2, 65, 65, 60, 130, 95, 110),
    197: (2, 95, 65, 110, 60, 130, 65),
    198: (3, 60, 85, 42, 85, 42, 91),
    199: (2, 95, 75, 80, 100, 110, 30),
    200: (1, 60, 60, 60, 85, 85, 85),
    201: (2, 48, 72, 48, 72, 48, 48),
    202: (2, 190, 33, 58, 33, 58, 33),
    203: (2, 70, 80, 65, 90, 65, 85),
    204: (2, 50, 65, 90, 35, 35, 15),
    205: (2, 75, 90, 140, 60, 60, 40),
    206: (2, 100, 70, 70, 65, 65, 45),
    207: (3, 65, 75, 105, 35, 65, 85),
    208: (2, 75, 85, 200, 55, 65, 30),
    209: (1, 60, 80, 50, 40, 40, 30),
    210: (1, 90, 120, 75, 60, 60, 45),
    211: (2, 65, 95, 75, 55, 55, 85),
    212: (2, 70, 130, 100, 55, 80, 65),
    213: (3, 20, 10, 230, 10, 230, 5),
    214: (4, 80, 125, 75, 40, 95, 85),
    215: (3, 55, 95, 55, 35, 75, 115),
    216: (2, 60, 80, 50, 50, 50, 40),
    217: (2, 90, 130, 75, 75, 75, 55),
    218: (2, 40, 40, 40, 70, 40, 20),
    219: (2, 50, 50, 120, 80, 80, 30),
    220: (4, 50, 50, 40, 30, 30, 50),
    221: (4, 100, 100, 80, 60, 60, 50),
    222: (1, 55, 55, 85, 65, 85, 35),
    223: (2, 35, 65, 35, 65, 35, 65),
    224: (2, 75, 105, 75, 105, 75, 45),
    225: (1, 45, 55, 45, 65, 45, 75),
    226: (4, 65, 40, 70, 80, 140, 70),
    227: (4, 65, 80, 140, 40, 70, 70),
    228: (4, 45, 60, 30, 80, 50, 65),
    229: (4, 75, 90, 50, 110, 80, 95),
    230: (2, 75, 95, 95, 95, 95, 85),
    231: (2, 90, 60, 60, 40, 40, 40),
    232: (2, 90, 120, 120, 60, 60, 50),
    233: (2, 85, 80, 90, 105, 95, 60),
    234: (4, 73, 95, 62, 85, 65, 85),
    235: (1, 55, 20, 35, 20, 45, 75),
    236: (2, 35, 35, 35, 35, 35, 35),
    237: (2, 50, 95, 95, 35, 110, 70),
    238: (2, 45, 30, 15, 85, 65, 65),
    239: (2, 45, 63, 37, 65, 55, 95),
    240: (2, 45, 75, 37, 70, 55, 83),
    241: (4, 95, 80, 105, 40, 70, 100),
    242: (1, 255, 10, 10, 75, 135, 55),
    243: (4, 90, 85, 75, 115, 100, 115),
    244: (4, 115, 115, 85, 90, 75, 100),
    245: (4, 100, 75, 115, 90, 115, 85),
    246: (4, 50, 64, 50, 45, 50, 41),
    247: (4, 70, 84, 70, 65, 70, 51),
    248: (4, 100, 134, 110, 95, 100, 61),
    249: (4, 106, 90, 130, 90, 154, 110),
    250: (4, 106, 130, 90, 110, 154, 90),
    251: (3, 100, 100, 100, 100, 100, 100),
    252: (3, 40, 45, 35, 65, 55, 70),
    253: (3, 50, 65, 45, 85, 65, 95),
    254: (3, 70, 85, 65, 105, 85, 120),
    255: (3, 45, 60, 40, 70, 50, 45),
    256: (3, 60, 85, 60, 85, 60, 55),
    257: (3, 80, 120, 70, 110, 70, 80),
    258: (3, 50, 70, 50, 50, 50, 40),
    259: (3, 70, 85, 70, 60, 70, 50),
    260: (3, 100, 110, 90, 85, 90, 60),
    261: (2, 35, 55, 35, 30, 30, 35),
    262: (2, 70, 90, 70, 60, 60, 70),
    263: (2, 38, 30, 41, 30, 41, 60),
    264: (2, 78, 70, 61, 50, 61, 100),
    265: (2, 45, 45, 35, 20, 30, 20),
    266: (2, 50, 35, 55, 25, 25, 15),
    267: (2, 60, 70, 50, 90, 50, 65),
    268: (2, 50, 35, 55, 25, 25, 15),
    269: (2, 60, 50, 70, 50, 90, 65),
    270: (3, 40, 30, 30, 40, 50, 30),
    271: (3, 60, 50, 50, 60, 70, 50),
    272: (3, 80, 70, 70, 90, 100, 70),
    273: (3, 40, 40, 50, 30, 30, 30),
    274: (3, 70, 70, 40, 60, 40, 60),
    275: (3, 90, 100, 60, 90, 60, 80),
    276: (3, 40, 55, 30, 30, 30, 85),
    277: (3, 60, 85, 60, 50, 50, 125),
    278: (2, 40, 30, 30, 55, 30, 85),
    279: (2, 60, 50, 100, 85, 70, 65),
    280: (4, 28, 25, 25, 45, 35, 40),
    281: (4, 38, 35, 35, 65, 55, 50),
    282: (4, 68, 65, 65, 125, 115, 80),
    283: (2, 40, 30, 32, 50, 52, 65),
    284: (2, 70, 60, 62, 80, 82, 60),
    285: (5, 60, 40, 60, 40, 60, 35),
    286: (5, 60, 130, 80, 60, 60, 70),
    287: (4, 60, 60, 60, 35, 35, 30),
    288: (4, 80, 80, 80, 55, 55, 90),
    289: (4, 150, 160, 100, 95, 65, 100),
    290: (0, 31, 45, 90, 30, 30, 40),
    291: (0, 61, 90, 45, 50, 50, 160),
    292: (0, 1, 90, 45, 30, 30, 40),
    293: (3, 64, 51, 23, 51, 23, 28),
    294: (3, 84, 71, 43, 71, 43, 48),
    295: (3, 104, 91, 63, 91, 63, 68),
    296: (5, 72, 60, 30, 20, 30, 25),
    297: (5, 144, 120, 60, 40, 60, 50),
    298: (1, 50, 20, 40, 20, 40, 20),
    299: (2, 30, 45, 135, 45, 90, 30),
    300: (1, 50, 45, 45, 35, 35, 50),
    301: (1, 70, 65, 65, 55, 55, 70),
    302: (3, 50, 75, 75, 65, 65, 50),
    303: (1, 50, 85, 85, 55, 55, 50),
    304: (4, 50, 70, 100, 40, 40, 30),
    305: (4, 60, 90, 140, 50, 50, 40),
    306: (4, 70, 110, 180, 60, 60, 50),
    307: (2, 30, 40, 55, 40, 55, 60),
    308: (2, 60, 60, 75, 60, 75, 80),
    309: (4, 40, 45, 40, 65, 40, 65),
    310: (4, 70, 75, 60, 105, 60, 105),
    311: (2, 60, 50, 40, 85, 75, 95),
    312: (2, 60, 40, 50, 75, 85, 95),
    313: (0, 65, 73, 55, 47, 75, 85),
    314: (5, 65, 47, 55, 73, 75, 85),
    315: (3, 50, 60, 45, 100, 80, 65),
    316: (5, 70, 43, 53, 43, 53, 40),
    317: (5, 100, 73, 83, 73, 83, 55),
    318: (4, 45, 90, 20, 65, 20, 65),
    319: (4, 70, 120, 40, 95, 40, 95),
    320: (5, 130, 70, 35, 70, 35, 60),
    321: (5, 170, 90, 45, 90, 45, 60),
    322: (2, 60, 60, 40, 65, 45, 35),
    323: (2, 70, 100, 70, 105, 75, 40),
    324: (2, 70, 85, 140, 85, 70, 20),
    325: (1, 60, 25, 35, 70, 80, 60),
    326: (1, 80, 45, 65, 90, 110, 80),
    327: (1, 60, 60, 60, 60, 60, 60),
    328: (3, 45, 100, 45, 45, 45, 10),
    329: (3, 50, 70, 50, 50, 50, 70),
    330: (3, 80, 100, 80, 80, 80, 100),
    331: (3, 50, 85, 40, 85, 40, 35),
    332: (3, 70, 115, 60, 115, 60, 55),
    333: (0, 45, 40, 60, 40, 75, 50),
    334: (0, 75, 70, 90, 70, 105, 80),
    335: (0, 73, 115, 60, 60, 60, 90),
    336: (5, 73, 100, 60, 100, 60, 65),
    337: (1, 70, 55, 65, 95, 85, 70),
    338: (1, 70, 95, 85, 55, 65, 70),
    339: (2, 50, 48, 43, 46, 41, 60),
    340: (2, 110, 78, 73, 76, 71, 60),
    341: (5, 43, 80, 65, 50, 35, 35),
    342: (5, 63, 120, 85, 90, 55, 55),
    343: (2, 40, 40, 55, 40, 70, 55),
    344: (2, 60, 70, 105, 70, 120, 75),
    345: (0, 66, 41, 77, 61, 87, 23),
    346: (0, 86, 81, 97, 81, 107, 43),
    347: (0, 45, 95, 50, 40, 50, 75),
    348: (0, 75, 125, 100, 70, 80, 45),
    349: (0, 20, 15, 20, 10, 55, 80),
    350: (0, 95, 60, 79, 100, 125, 81),
    351: (2, 70, 70, 70, 70, 70, 70),
    352: (3, 60, 90, 70, 60, 120, 40),
    353: (1, 44, 75, 35, 63, 33, 45),
    354: (1, 64, 115, 65, 83, 63, 65),
    355: (1, 20, 40, 90, 30, 90, 25),
    356: (1, 40, 70, 130, 60, 130, 25),
    357: (4, 99, 68, 83, 72, 87, 51),
    358: (1, 65, 50, 70, 95, 80, 65),
    359: (3, 65, 130, 60, 75, 60, 75),
    360: (2, 95, 23, 48, 23, 48, 23),
    361: (2, 50, 50, 50, 50, 50, 50),
    362: (2, 80, 80, 80, 80, 80, 80),
    363: (3, 70, 40, 50, 55, 50, 25),
    364: (3, 90, 60, 70, 75, 70, 45),
    365: (3, 110, 80, 90, 95, 90, 65),
    366: (0, 35, 64, 85, 74, 55, 32),
    367: (0, 55, 104, 105, 94, 75, 52),
    368: (0, 55, 84, 105, 114, 75, 52),
    369: (4, 100, 90, 130, 45, 65, 55),
    370: (1, 43, 30, 55, 40, 65, 97),
    371: (4, 45, 75, 60, 40, 30, 50),
    372: (4, 65, 95, 100, 60, 50, 50),
    373: (4, 95, 135, 80, 110, 80, 100),
    374: (4, 40, 55, 80, 35, 60, 30),
    375: (4, 60, 75, 100, 55, 80, 50),
    376: (4, 80, 135, 130, 95, 90, 70),
    377: (4, 80, 100, 200, 50, 100, 50),
    378: (4, 80, 50, 100, 100, 200, 50),
    379: (4, 80, 75, 150, 75, 150, 50),
    380: (4, 80, 80, 90, 110, 130, 110),
    381: (4, 80, 90, 80, 130, 110, 110),
    382: (4, 100, 100, 90, 150, 140, 90),
    383: (4, 100, 150, 140, 100, 90, 90),
    384: (4, 105, 150, 90, 150, 90, 95),
    385: (4, 100, 100, 100, 100, 100, 100),
    386: (4, 50, 150, 50, 150, 50, 150),
    387: (3, 55, 68, 64, 45, 55, 31),
    388: (3, 75, 89, 85, 55, 65, 36),
    389: (3, 95, 109, 105, 75, 85, 56),
    390: (3, 44, 58, 44, 58, 44, 61),
    391: (3, 64, 78, 52, 78, 52, 81),
    392: (3, 76, 104, 71, 104, 71, 108),
    393: (3, 53, 51, 53, 61, 56, 40),
    394: (3, 64, 66, 68, 81, 76, 50),
    395: (3, 84, 86, 88, 111, 101, 60),
    396: (3, 40, 55, 30, 30, 30, 60),
    397: (3, 55, 75, 50, 40, 40, 80),
    398: (3, 85, 120, 70, 50, 50, 100),
    399: (2, 59, 45, 40, 35, 40, 31),
    400: (2, 79, 85, 60, 55, 60, 71),
    401: (3, 37, 25, 41, 25, 41, 25),
    402: (3, 77, 85, 51, 55, 51, 65),
    403: (3, 45, 65, 34, 40, 34, 45),
    404: (3, 60, 85, 49, 60, 49, 60),
    405: (3, 80, 120, 79, 95, 79, 70),
    406: (3, 40, 30, 35, 50, 70, 55),
    407: (3, 60, 70, 55, 125, 105, 90),
    408: (0, 67, 125, 40, 30, 30, 58),
    409: (0, 97, 165, 60, 65, 50, 58),
    410: (0, 30, 42, 118, 42, 88, 30),
    411: (0, 60, 52, 168, 47, 138, 30),
    412: (2, 40, 29, 45, 29, 45, 36),
    413: (2, 60, 59, 85, 79, 105, 36),
    414: (2, 70, 94, 50, 94, 50, 66),
    415: (3, 30, 30, 42, 30, 42, 70),
    416: (3, 70, 80, 102, 80, 102, 40),
    417: (2, 60, 45, 70, 45, 90, 95),
    418: (2, 55, 65, 35, 60, 30, 85),
    419: (2, 85, 105, 55, 85, 50, 115),
    420: (2, 45, 35, 45, 62, 53, 35),
    421: (2, 70, 60, 70, 87, 78, 85),
    422: (2, 76, 48, 48, 57, 62, 34),
    423: (2, 111, 83, 68, 92, 82, 39),
    424: (1, 75, 100, 66, 60, 66, 115),
    425: (5, 90, 50, 34, 60, 44, 70),
    426: (5, 150, 80, 44, 90, 54, 80),
    427: (2, 55, 66, 44, 44, 56, 85),
    428: (2, 65, 76, 84, 54, 96, 105),
    429: (1, 60, 60, 60, 105, 105, 105),
    430: (3, 100, 125, 52, 105, 52, 71),
    431: (1, 49, 55, 42, 42, 37, 85),
    432: (1, 71, 82, 64, 64, 59, 112),
    433: (1, 45, 30, 50, 65, 50, 45),
    434: (2, 63, 63, 47, 41, 41, 74),
    435: (2, 103, 93, 67, 71, 61, 84),
    436: (2, 57, 24, 86, 24, 86, 23),
    437: (2, 67, 89, 116, 79, 116, 33),
    438: (2, 50, 80, 95, 10, 45, 10),
    439: (2, 20, 25, 45, 70, 90, 60),
    440: (1, 100, 5, 5, 15, 65, 30),
    441: (3, 76, 65, 45, 92, 42, 91),
    442: (2, 50, 92, 108, 92, 108, 35),
    443: (4, 58, 70, 45, 40, 45, 42),
    444: (4, 68, 90, 65, 50, 55, 82),
    445: (4, 108, 130, 95, 80, 85, 102),
    446: (4, 135, 85, 40, 40, 85, 5),
    447: (3, 40, 70, 40, 35, 40, 60),
    448: (3, 70, 110, 70, 115, 70, 90),
    449: (4, 68, 72, 78, 38, 42, 32),
    450: (4, 108, 112, 118, 68, 72, 47),
    451: (4, 40, 50, 90, 30, 55, 65),
    452: (4, 70, 90, 110, 60, 75, 95),
    453: (2, 48, 61, 40, 61, 40, 50),
    454: (2, 83, 106, 65, 86, 65, 85),
    455: (4, 74, 100, 72, 90, 72, 46),
    456: (0, 49, 49, 56, 49, 61, 66),
    457: (0, 69, 69, 76, 69, 86, 91),
    458: (4, 45, 20, 50, 60, 120, 50),
    459: (4, 60, 62, 50, 62, 60, 40),
    460: (4, 90, 92, 75, 92, 85, 60),
    461: (3, 70, 120, 65, 45, 85, 125),
    462: (2, 70, 70, 115, 130, 90, 60),
    463: (2, 110, 85, 95, 80, 95, 50),
    464: (4, 115, 140, 130, 55, 55, 40),
    465: (2, 100, 100, 125, 110, 50, 50),
    466: (2, 75, 123, 67, 95, 85, 95),
    467: (2, 75, 95, 67, 125, 95, 83),
    468: (1, 85, 50, 95, 120, 115, 80),
    469: (2, 86, 76, 86, 116, 56, 95),
    470: (2, 65, 110, 130, 60, 65, 95),
    471: (2, 65, 60, 110, 130, 95, 65),
    472: (3, 75, 95, 125, 45, 75, 95),
    473: (4, 110, 130, 80, 70, 60, 80),
    474: (2, 85, 80, 70, 135, 75, 90),
    475: (4, 68, 125, 65, 65, 115, 80),
    476: (2, 60, 55, 145, 75, 150, 40),
    477: (1, 45, 100, 135, 65, 135, 45),
    478: (2, 70, 80, 70, 80, 70, 110),
    479: (2, 50, 50, 77, 95, 77, 91),
    480: (4, 75, 75, 130, 75, 130, 95),
    481: (4, 80, 105, 105, 105, 105, 80),
    482: (4, 75, 125, 70, 125, 70, 115),
    483: (4, 100, 120, 120, 150, 100, 90),
    484: (4, 90, 120, 100, 150, 120, 100),
    485: (4, 91, 90, 106, 130, 106, 77),
    486: (4, 110, 160, 110, 80, 110, 100),
    487: (4, 150, 100, 120, 100, 120, 90),
    488: (4, 120, 70, 120, 75, 130, 85),
    489: (4, 80, 80, 80, 80, 80, 80),
    490: (4, 100, 100, 100, 100, 100, 100),
    491: (4, 70, 90, 90, 135, 90, 125),
    492: (3, 100, 100, 100, 100, 100, 100),
    493: (4, 120, 120, 120, 120, 120, 120)
}

# Exp lookup table
lvlexp = {
    1: (0, 0, 0, 0, 0, 0),
    2: (15, 6, 8, 9, 10, 4),
    3: (52, 21, 27, 57, 33, 13),
    4: (122, 51, 64, 96, 80, 32),
    5: (237, 100, 125, 135, 156, 65),
    6: (406, 172, 216, 179, 270, 112),
    7: (637, 274, 343, 236, 428, 178),
    8: (942, 409, 512, 314, 640, 276),
    9: (1326, 583, 729, 419, 911, 393),
    10: (1800, 800, 1000, 560, 1250, 540),
    11: (2369, 1064, 1331, 742, 1663, 745),
    12: (3041, 1382, 1728, 973, 2160, 967),
    13: (3822, 1757, 2197, 1261, 2746, 1230),
    14: (4719, 2195, 2744, 1612, 3430, 1591),
    15: (5737, 2700, 3375, 2035, 4218, 1957),
    16: (6881, 3276, 4096, 2535, 5120, 2457),
    17: (8155, 3930, 4913, 3120, 6141, 3046),
    18: (9564, 4665, 5832, 3798, 7290, 3732),
    19: (11111, 5487, 6859, 4575, 8573, 4526),
    20: (12800, 6400, 8000, 5460, 10000, 5440),
    21: (14632, 7408, 9261, 6458, 11576, 6482),
    22: (16610, 8518, 10648, 7577, 13310, 7666),
    23: (18737, 9733, 12167, 8825, 15208, 9003),
    24: (21012, 11059, 13824, 10208, 17280, 10506),
    25: (23437, 12500, 15625, 11735, 19531, 12187),
    26: (26012, 14060, 17576, 13411, 21970, 14060),
    27: (28737, 15746, 19683, 15244, 24603, 16140),
    28: (31610, 17561, 21952, 17242, 27440, 18439),
    29: (34632, 19511, 24389, 19411, 30486, 20974),
    30: (37800, 21600, 27000, 21760, 33750, 23760),
    31: (41111, 23832, 29791, 24294, 37238, 26811),
    32: (44564, 26214, 32768, 27021, 40960, 30146),
    33: (48155, 28749, 35937, 29949, 44921, 33780),
    34: (51881, 31443, 39304, 33084, 49130, 37731),
    35: (55737, 34300, 42875, 36435, 53593, 42017),
    36: (59719, 37324, 46656, 40007, 58320, 46656),
    37: (63822, 40522, 50653, 43808, 63316, 50653),
    38: (68041, 43897, 54872, 47846, 68590, 55969),
    39: (72369, 47455, 59319, 52127, 74148, 60505),
    40: (76800, 51200, 64000, 56660, 80000, 66560),
    41: (81326, 55136, 68921, 61450, 86151, 71677),
    42: (85942, 59270, 74088, 66505, 92610, 78533),
    43: (90637, 63605, 79507, 71833, 99383, 84277),
    44: (95406, 68147, 85184, 77440, 106480, 91998),
    45: (100237, 72900, 91125, 83335, 113906, 98415),
    46: (105122, 77868, 97336, 89523, 121670, 107069),
    47: (110052, 83058, 103823, 96012, 129778, 114205),
    48: (115015, 88473, 110592, 102810, 138240, 123863),
    49: (120001, 94119, 117649, 109923, 147061, 131766),
    50: (125000, 100000, 125000, 117360, 156250, 142500),
    51: (131324, 106120, 132651, 125126, 165813, 151222),
    52: (137795, 112486, 140608, 133229, 175760, 163105),
    53: (144410, 119101, 148877, 141677, 186096, 172697),
    54: (151165, 125971, 157464, 150476, 196830, 185807),
    55: (158056, 133100, 166375, 159635, 207968, 196322),
    56: (165079, 140492, 175616, 169159, 219520, 210739),
    57: (172229, 148154, 185193, 179056, 231491, 222231),
    58: (179503, 156089, 195112, 189334, 243890, 238036),
    59: (186894, 164303, 205379, 199999, 256723, 250562),
    60: (194400, 172800, 216000, 211060, 270000, 267840),
    61: (202013, 181584, 226981, 222522, 283726, 281456),
    62: (209728, 190662, 238328, 234393, 297910, 300293),
    63: (217540, 200037, 250047, 246681, 312558, 315059),
    64: (225443, 209715, 262144, 259392, 327680, 335544),
    65: (233431, 219700, 274625, 272535, 343281, 351520),
    66: (241496, 229996, 287496, 286115, 359370, 373744),
    67: (249633, 240610, 300763, 300140, 375953, 390991),
    68: (257834, 251545, 314432, 314618, 393040, 415050),
    69: (267406, 262807, 328509, 329555, 410636, 433631),
    70: (276458, 274400, 343000, 344960, 428750, 459620),
    71: (286328, 286328, 357911, 360838, 447388, 479600),
    72: (296358, 298598, 373248, 377197, 466560, 507617),
    73: (305767, 311213, 389017, 394045, 486271, 529063),
    74: (316074, 324179, 405224, 411388, 506530, 559209),
    75: (326531, 337500, 421875, 429235, 527343, 582187),
    76: (336255, 351180, 438976, 447591, 548720, 614566),
    77: (346965, 365226, 456533, 466464, 570666, 639146),
    78: (357812, 379641, 474552, 485862, 593190, 673863),
    79: (367807, 394431, 493039, 505791, 616298, 700115),
    80: (378880, 409600, 512000, 526260, 640000, 737280),
    81: (390077, 425152, 531441, 547274, 664301, 765275),
    82: (400293, 441094, 551368, 568841, 689210, 804997),
    83: (411686, 457429, 571787, 590969, 714733, 834809),
    84: (423190, 474163, 592704, 613664, 740880, 877201),
    85: (433572, 491300, 614125, 636935, 767656, 908905),
    86: (445239, 508844, 636056, 660787, 795070, 954084),
    87: (457001, 526802, 658503, 685228, 823128, 987754),
    88: (467489, 545177, 681472, 710266, 851840, 1035837),
    89: (479378, 563975, 704969, 735907, 881211, 1071552),
    90: (491346, 583200, 729000, 762160, 911250, 1122660),
    91: (501878, 602856, 753571, 789030, 941963, 1160499),
    92: (513934, 622950, 778688, 816525, 973360, 1214753),
    93: (526049, 643485, 804357, 844653, 1005446, 1254796),
    94: (536557, 664467, 830584, 873420, 1038230, 1312322),
    95: (548720, 685900, 857375, 902835, 1071718, 1354652),
    96: (560922, 707788, 884736, 932903, 1105920, 1415577),
    97: (571333, 730138, 912673, 963632, 1140841, 1460276),
    98: (583539, 752953, 941192, 995030, 1176490, 1524731),
    99: (591882, 776239, 970299, 1027103, 1212873, 1571884),
    100: (600000, 800000, 1000000, 1059860, 1250000, 1640000)
}

nature = {
    0:  (1.0, 1.0, 1.0, 1.0, 1.0),
    1:  (1.1, 0.9, 1.0, 1.0, 1.0),
    2:  (1.1, 1.0, 0.9, 1.0, 1.0),
    3:  (1.1, 1.0, 1.0, 0.9, 1.0),
    4:  (1.1, 1.0, 1.0, 1.0, 0.9),
    5:  (0.9, 1.1, 1.0, 1.0, 1.0),
    6:  (1.0, 1.0, 1.0, 1.0, 1.0),
    7:  (1.0, 1.1, 0.9, 1.0, 1.0),
    8:  (1.0, 1.1, 1.0, 0.9, 1.0),
    9:  (1.0, 1.1, 1.0, 1.0, 0.9),
    10: (0.9, 1.0, 1.1, 1.0, 1.0),
    11: (1.0, 0.9, 1.1, 1.0, 1.0),
    12: (1.0, 1.0, 1.0, 1.0, 1.0),
    13: (1.0, 1.0, 1.1, 0.9, 1.0),
    14: (1.0, 1.0, 1.1, 1.0, 0.9),
    15: (0.9, 1.0, 1.0, 1.1, 1.0),
    16: (1.0, 0.9, 1.0, 1.1, 1.0),
    17: (1.0, 1.0, 0.9, 1.1, 1.0),
    18: (1.0, 1.0, 1.0, 1.0, 1.0),
    19: (1.0, 1.0, 1.0, 1.1, 0.9),
    20: (0.9, 1.0, 1.0, 1.0, 1.1),
    21: (1.0, 0.9, 1.0, 1.0, 1.1),
    22: (1.0, 1.0, 0.9, 1.0, 1.1),
    23: (1.0, 1.0, 1.0, 0.9, 1.1),
    24: (1.0, 1.0, 1.0, 1.0, 1.0)
}
