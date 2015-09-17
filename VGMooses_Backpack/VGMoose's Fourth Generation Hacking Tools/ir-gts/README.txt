Infinite Recursion's GTS Script (IR-GTS)


IR-GTS is a Python script that allows you to transfer Pokemon to and from
retail Nintendo DS cartridges. It works for all Generation-IV Pokemon games
(Diamond, Pearl, Platinum, HeartGold and SoulSilver). Most of the credit goes
to LordLandon for his SendPKM script, as well as the description of the GTS
protocol from http://projectpokemon.org/wiki/GTS_protocol.


IR-GTS should be platform-independent, and has been tested on Windows and Mac
OS X.


Requirements:
Python 2.6 (Available from http://www.python.org)
DS Pokemon game
Wireless network
Administrator access to your computer


How to:
First, launch the 'gts.py' file, either by double-clicking or from a command
prompt. This will give you an IP address to use for your DS' DNS Settings
(available from the network configuration screen). After you've changed the
DNS accordingly, choose an option from the main menu by typing a letter and
pressing [Enter]:


's' - Send a Pokemon to the DS game. This works in exactly the same way as
LordLandon's SendPKM script (in fact, it's almost entirely the same code). When
prompted, type in the file path to the PKM file you want to send (e.g.
'C:\Users\InfiniteRecursion\MAWILE.pkm'). You should also be able to drag the
file into the prompt window, and it will automatically enter the path for you.
Press [Enter], and then enter the GTS in-game when prompted. After a short time,
the Pokemon will appear on the DS, and be placed in either an empty spot in your
party or the first available PC box.

Sending more than one at a time isn't currently possible, which means that you
have to exit and re-enter the GTS to send another.


'r' - Receive a Pokemon from the DS game. After choosing this option, IR-GTS
will give you a 'Ready to receive from NDS' prompt. Once you see this, enter the
GTS and attempt to offer the Pokemon you wish to transfer, in the same way as if
you were completing an actual GTS trade. After choosing a Pokemon, it doesn't
matter what you request; I usually mash [A] through the prompts until it tries
to send. You will then receive an error on the DS stating that the Pokemon
cannot be offered for trade - this is to prevent accidental deletion if
something goes wrong. On your computer, it will automatically try to save the
file as [nickname].pkm within the Pokemon directory. If the file already exists,
it prompts for a new name.

As of Revision 24, this will now create (or add to) a pokemon.txt file with the
stats of the pokemon you send to your computer. Nature, Ability, Shininess, OT
ID and Secret ID, IVs, EVs, and Happiness are all recorded.


'm' - Receive multiple Pokemon from the DS game. This works precisely the same
way as above, except it won't dump you back to the menu after receiving each
one. There is no need to exit and re-enter the GTS for this function. Press
[Control] + [C] to return to the main menu.

If you run into any problems, please let me know at trocaire [at] minorchaos
[dot] net. When the window closes without warning, it usually means it's
encountered an error - if possible, I ask that you try running the program from
a command prompt and copy/paste the entire output, so I can know exactly what
happened. Otherwise, please let me know which function you were attempting, and
after which point the program died.


Enjoy!
-Infinite Recursion
