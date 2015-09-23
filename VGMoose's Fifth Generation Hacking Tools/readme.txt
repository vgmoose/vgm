==================================================================
Pokémon Fifth Generation Hacking Tools Package v0.5
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
REFERENCES FROM ANDRECITO77 
---------------------------------------------------------------------------

Hello! My name is Andrecito77 and I am going to try to help you guys by make a big resource for all hackers. Below are all of our findings. Sometimes I won't post a finding in this post because only a select few will find it of interest, but if you look through the replies you will find them.

Here is what we know:

NOTE: All Items selected in [] are unsure. All items with * means that that has been hacked.

a/0/
a/0/0/2 IS THE SCRIPT!!!!!
a/0/0/4 Pokemon Sprites
a/0/0/7 In-menu Pokemon sprites
a/0/0/8 In-menu Pokemon sprites
a/0/1/1 Contains the images for the fight menu/Model data for battle stages]
a/0/1/4 *Are the overworld BTX files
a/0/2/5 Item sprites
a/0/3/0 [Touchscreen status]
a/0/3/1 Player sprites
a/0/3/2 NPC sprites
a/0/4/1 Trainer sprites in combat
a/0/5/2 Pokemon Sprites
a/0/5/5 Pokemon types / movement type
a/0/8/3 [Pokemon status menu]
a/0/8/5 World map


a/1/
a/1/1/8 Keyboard
a/1/2/0 Wifi club screen
a/1/2/4 Pokemon types / movement type
a/1/3/1 [Character Artworks]
a/1/3/7 Battle Recorder
a/1/3/9 DSi / DSi XL / LL Menu Screen
a/1/4/3 Game Sync Screens
a/1/5/1 Season Screens (Spring, Summer, Autumn, Winter)
a/1/6/4 Copyright Screen
a/1/7/0 Player and his friend's Pictures
a/1/7/1 CGear
a/1/7/3 Balloons
a/1/8/4 Trainer Sprites
a/1/8/7 Mysterious Person 'N'
a/1/9/7 Wifi and Wifi related models (example, world globe)


a/2/
a/2/0/1 [Certificate]
a/2/0/2 [Certificate]
a/2/0/5 [Starter's pictures/3D Models]
a/2/0/6 Battle Subway Map
a/2/0/7 Has model data (same as below)
a/2/1/0
a/2/1/7
a/2/1/8
a/2/1/9
a/2/2/0 ['The End' Screen/3D Models]
a/2/2/2
a/2/2/8
a/2/2/9
a/2/3/0 Has MDL0 files (3d models)
a/2/4/4 Some Text (not the Script)

Help me updating this by posting in the comments any findings.

UPDATE 1: Added Soniyx's findings and also reorganized the other data.
UPDATE 2: Added winwakrs veekun.com data, added the needed script data from atoxic, also added mvit's model data.
	
original post: http://gbatemp.net/lofiversion/index.php?t255124.html

---------------------------------------------------------------------------
GENERAL PROCESS FIRST TIMERS OR CONVERTERS FROM THIRD GEN READ HERE
---------------------------------------------------------------------------

In fifth gen, unlike third gen, the common practice of "rom editing" is to first
unpack all of the files from the .nds file into a folder. Then, the tools will operate on the folder for the
most part, editing the .narc (nintendo archive) files that are within. (b/w these files, like hg/ss aren't usually explicitly called .narc, but are located in the "a" folder) Once all edits are done to the tmp folder, you can use ndstool (see ppre)
to recompile the rom into a brand new .nds file. From this .nds file then, you can
make a .patch with xdelta.

It's a little confusing at first from the open and edit plug and play world of
third gen, but you get used to it, and it eventually feels more natural.

TO COMPILE OR PATCH ROMS
	Use xdelta

TO UNPACK ROMS TO TMP_ DIRECTORY
	Use ndstool
	Use Kiwiedit

HEX EDITING
	CrystalTile2 (ctrl+N or the Nds button to active .narc features)

TO EDIT SPRITES
	Use BTK Editor (overworld) after extracting sprite database

TO EDIT TEXT (a/0/0/2 (other text) and a/0/0/3 (story text))
	Use pptxt, a specific fifth gen editor

The help file in pptxt will use nitro explorer, but you can use a similar process in kiwieditor, see my site for extended help. I would play Kiwieditor in-between nitro explorer (just a tree) and crystaltile2 (tree and hex editor) in technicalness. Nitro explorer may be included in a future update, but for now kiwieditor covers all the needs.

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