These are modified versions of loadingNOW's PokeDSPic Program. Get the original program and source at http://pokeguide.filb.de/

The source files I am providing would replace the form1.cs file, of course, you have to rename those files to form1.cs

Platinum Sprites:
Pokemon Sprites are "encrypted" differently in Platinum than in D/P. I modified it only in how it decrypts the graphic files for each sprite.

For each species of pokemon there are 4 graphic files and 2 pallete files. When you load pl_pokegra.narc these will show up as 4 consecutive files of size 0x1930. Then 2 consecutive files of size 0x48.
These are:
Pokemon Back Sprite Male
Pokemon Back Sprite Female
Pokemon Front Sprite Male
Pokemon Front Sprite Female
Regular Palette
Shiny Palette

The original PokeDSPic has an auto coloring function. I did not modify this. This function does not work perfectly and while it will show you some of the sprites you may want, it may not show you some. For example, you won't get the Back Male Sprite with the Shiny palette under the auto coloring. You can choose the Back Male Sprite then choose the second palette file to get the shiny version.

This version of PokeDSPic can also be used to obtain the sprites of the alternate forms. (These are in pl_otherpoke.narc)

For pl_otherpoke.narc, the structure is as follows:

All the alternate form graphic files followed all the pallete files for them. Then at the end there is some graphic and palette files for the substitute sprite.

The auto coloring function is useless here (at least as coded and I did not feel like making it better, probably for similar reason to loadingNOW). You need to choose the graphic file you want to see then find the corresponding palette file.

The first few graphic files are the alternate forms of Deoxys. For all the forms there are only two palette files, one for the normal version another for the shiny version.
Following deoxys are all the unowns, again, all of them share two palette files.
TO find the right palette you can also try choosing the graphic file you want then going to the first palette file then just going down the list until you find the correct one.


Platinum Trainer Sprites:
For the platinum trainer sprites the encryption is the same as for the platinum pokemon sprites.

For this version I set it up so that only the auto coloring option changes the palette of a sprite. I made it so that the right palette is automatically chosen.

This version works with trfgra.narc and trbgra.narc from platinum.
If you load trfgra.narc and trbgra.narc from D/P you will get garbage.

Use the original PokeDSPic to view the DP trainer sprites.

Party Icons:

This version will allow you to extract party icon graphics from pl_poke_icon.narc and poke_icon.narc. The palette situation here is difficult again. This is because there is just one palette file for all the icons. The palette file include 3, 16 color palattes, I added a button that lets you cycle through the different palettes. If you get to an icon and the colors seem off, one or two presses of the new button will get you the right colors.

Item Icons:

This version allows you to extract item icons from item_icon.narc for both Platinum and DP.


Send any questions to scvgeo@gmail.com. You can also contact me at the pokesav.org forums or their irc channel. If I posted this myself in a forum please feel free to ask questions there.

-SCV