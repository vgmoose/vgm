==================================================================
Pokémon Fourth Generation Hacking Tools Package v0.9
Compiled by VGMoose
Tools by other cool people (credited in their app)
==================================================================

This download is incomplete, expect it to grow overtime. For more
information, visit my website:
	http://dft.ba/-vgmoosebp
	http://vgmoose.rickyayoub.com

In case subtly is dead, ROMs can be located at the following websites:
	http://www.ndsr.net/
	http://www.thepiratebay.org
	http://www.emuparadise.org
	
---------------------------------------------------------------------------
GENERAL PROCESS FIRST TIMERS OR CONVERTERS FROM THIRD GEN READ HERE
---------------------------------------------------------------------------

In fourth gen, unlike third gen, the common practice of "rom editing" is to first
unpack all of the files from the .nds file into a folder (most of the tools in
this distro use "tmp_romname"). Then, the tools will operate on the folder for the
most part, editing the .narc (nintendo archive) files that are within. (In hg/ss
.narc files aren't given the .narc filename, but they still exist in the root/a
folder.) Once all edits are done to the tmp folder, you can use ndstool (see ppre)
to recompile the rom into a brand new .nds file. From this .nds file then, you can
make a .patch with xdelta.

It's a little confusing at first from the open and edit plug and play world of
third gen, but you get used to it, and it eventually feels more natural.

To get started, I would immediately go to the PPRE folder and launch it. It contains
a limited map editor (with script editing), Pokemon editing, and several other useful
tools. There is no graphical editor for maps yet, however you may have some luck with
crystaltile and the extracted files.

TO EDIT MOST THINGS CONVENIENTLY (TEXT, SCRIPTS, PKMN, ATTACKS)
	Use PPRE

TO COMPILE OR PATCH ROMS
	Use xdelta
	Use PPRE

TO UNPACK ROMS TO TMP_ DIRECTORY
	Use ndstool
	Use PPRE ("set rom" runs ndstool)
	Use Kiwiedit

HEX EDITING
	CrystalTile2 (ctrl+N or the Nds button to active .narc features)

TO EDIT SPRITES
	Use BTK Editor (overworld) after extracting sprite database
	Use PokeDsPic (everything else) after extracting sprite database

FOR MORE SPECIFIC THINGS, THE APPS OFTEN HAVE A SPECIFIC NAME (eg. StarterEd)

---------------------------------------------------------------------------
REFERENCES (http://tinyurl.com/6a6wa8s)
---------------------------------------------------------------------------

MAPS: field-data/land-data/land data release.narc(Dpp) or a/0/6/5(Hgss)
	1) Movement permissions
	2) 3D Objects within maps
		Models:
		0x0-0x4 Model Number (Linked with NSBMD file id into Build_Model.narc(dpp) or bm_field and bm_room(hgss))
		0x5-0x8 X Coordinates
		0x9-0xC Y Coordinates
		0xD-0x10 Z Coordinates
		0x11-0x1C Unknown bytes
		0x1D-0x20 Model widTH
		0x21-0x24 Model height
		0x25-0x28 Model weight
	3) NSBMD model
	4) BDHC, stairs, elevated parts of maps

EVENTS: zone_event-release.narc(dpp) or a/0/1/2(hgss)
	1) Overworld data
		0x0-0x2 Overword Id
		0x2-0x4 Overword Sprite
		0x4-0x6 0verword Movement
		0x6-0x8 Unknown Bytes
		0x8-0xA Script Flag
		0xA-0xC Script Number
		0xC-0xE Unknown Bytes
		0xE-0x18 Line of Sights(Trainer)
		0x18-0x20 X coordinates
		0x20-0x22 Y coordinates
		0x22-0x24 Z coordinates
	2) Warps
		0x0-0x2 X coordinates
		0x2-0x4 Y coordinates
		0x4-0x6 Map Id
		0x6-0xa Maybe Warp Flag
	3) Signs (furniture in pore)
		0x0-0x2 Script
		0x2-0x4 Unknown
		0x4-0x8 X Coordinates
		0x8-0xC Y Coordinates
		0xC-0xF Z Coordinates
	4) Triggers
		0x0-0x2 Script
		0x2-0x4 X Coordinates
		0x4-0x6 Y Coordinates
		0x6-0x8 Width
		0x8-0xA Lenght
		0xA-0xC Weight
		0xC-0xF Flag Number

SCRIPTS: scrip-seq-release.narc(a/0/3/2 for hgss)
	1) Header, contains length of script
	2) Commands, contains actions within script
	(These two pieces are separated by the constant 0xFD13)

MSG DATA: msgdata/msg.narc(dpp) and a/0/2/7 (hgss)

GRAPHIC DATA:
	To quote pichu2000:
"If we open some narc, we can find a NCGR file(RCGN or Tile File), followed usually by a NCLR(RCLN or Palette File) and sometimes by a NCGR(RCGN or Map File), and other two uneditable files(NANR or Animation File and NCER or Cell Animation File).
In Crystaltile we only go on a Tile file, press BackSpace, then go on a Palette file, and press Backspace, and if we find the NCGR, make the same thing.
Then we can see the image onto the window of the rom.
Press Ctrl+e and export image as bmp. Edit with paint, and click Ctrl+I, and we only need to save the rom.
We need pay attention to not change the palette based map, and respect also the tile.

Some images are compressed(NCGR.L), like pokedex screen and other.
We need to decompress the three file associated (right click and press U() option), rebuild a new rom with dslazy, edit image like we done previously, save the three file uncompressed(right click and press E() option), open Crystal tile, go to T and Lz77 compression, select the three file(one for one), and rebuild the new rom.
This is more complicated, but it's the only way to edit the compressed graphic."

In general, http://www.pokecommunity.com/ is a great, well, community for help.

---------------------------------------------------------------------------
OF EMULATORS AND .SAV FILES
---------------------------------------------------------------------------
No$Gba is for computers with less power (the 3D renderer is weaker, to use stronger renderer, go to options and select opengl)
Desmume renders better, but is notoriously slower. More options though.
Desmume 64 bit should be used if you're on 64 bit over the other two no matter what

No$Gba expects ROMs to go to No$Gba/BATTERY. .Sav files will also be placed there.
Desmume can export and import .Sav files from the file menu.

Use PokeSav to edit your .Sav files. You can use hyperGTS or the gts.py scripts (ir-gts) to take in your pokemon from your DS game in your hacks!

Also, one last thing. If you're on a mac, and desperately trying to get this to function, I would check out
No$Gba with wine embedded. One such site where you could obtain this is http://www.barissencan.com/downloads/

---------------------------------------------------------------------------
THAT'S ALL FOLKS
---------------------------------------------------------------------------

I will post a detailed description of ALL of the tools at a later date, but for now this should tide you all over.

Don't forget to visit my Youtube channel for more Pokémon Hacks!
	http://youtube.com/vgmoose

TUTORIALS COMING SOON AT
	http://dft.ba/-vgmoosebp
	
Help and detailed information for these tools will be available at a later date. Honestly if you want to know how to use an app, simply go to http://www.google.com and type in the name of the program, and maybe like "pokemon hack" or the name of the game you're trying to edit.

Thanks, cheers, and happy hacking!

-VGMoose
vgmoose@gmail.com