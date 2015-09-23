********************************************
*** Advance Map Ver 1.80 - Netherlands       ***
********************************************

Deze tool is voor het verandern van maps, movement permissions, block data, events en wild pokemon data.
Later collision data moet ook verandert kunnen worden.
Het werkt met R/S/E FR/LG, Japans en Engels.

!!!AANDACHT!!!
-------------
Met deze versie worden allen versie's in de rom opgeslagen!
Door "Opslaan Als" je kunt de map in een anderen file opslaan.
Als het geladen is worden er een copy van de file gemaakt.
Allen anderen veranderingen worden in de new file opgeslagen.



.:|BELANGRIJK|:.
-^-^-^-^-^-^-
Deze programma is gemaakt door LU-HO Poké en is copyrightED by LU-HO Poké!
Als je het van een andern plaats dan van FB(FilbBoard [http://www.filbboard.de/]),
vertel het me dan meteen! Mijn e-mail is: lu.ho@tiscali.ch


********************************
***     Contents van Inis     ***
********************************
AdvanceMap.ini:
--------------- 
De INI is compleet anders.
Nu heeft elke taal zijn eigen settings.
Verder hebben allen games Game specifiy settings.
Laats en zo..., elke offset is opgelsgane by een patroon.

Voorbeeld 1:
[MapBankHeader]
art=pointer
nach=80180068890B091808687047
spiele=BPR,BPG,BPE,AXP,AXV

Dit betekent dat achter de Bytes "nach" de Pointer naar de Map Header is.
Deze setting gaat voor allen games die zijn onder "spiele".


Voorbeeld 2:
[PokemonNamen]
inkSprache=1
art=pointer
vor=30B50025084CC8F7
spiele=AXPJ,AXVJ,AXPE,AXVE

[PokemonNamen2]
art=pointer
position=$000144
spiele=BPR,BPG,BPE,AXP,AXV

Hier zijn 2 entrys. In het 1st, Allen taal taan achter "spiele", omdt "inkSprache" is gezet op 1.
Ook hebben we pointer naar de point "vor" beschreven Bytes.
Omdat niet allen games onder de eerste 1st entry zitten, er is een 2nd entry die word gebrukt voor elke spel.
Naar de 2nd entry, de Pointer word gevonden bij de positie set in de "position" variable.


Hex values moeten altijd de "$" hebben!


Main.ini
--------
Hier de volgorden met de corresponding maps zijn listed.
Veel nieuwe orders kunnen worden produced waneer je wilt.
De format is als volgt:

[<Foldername>]
1=<Bank>.<map>
2=<Bank>.<map>
3=<Bank>.<map>
4=<Bank>.<map>
5=<Bank>.<map>
...

Voorbeeld:
[0]
1=0.0
2=0.1
3=0.2
...

[1]
1=1.0
...

De map namen kunnen verandert worden zo als je wilt;

Maar niet altijd:
[<FolderName>]
1=<Label>
2=<Label>
...
Voor meer, kijk naar Maps.ini


Maps.ini
--------
Hier zijn de map, maar allen de genen die in Main.ini staan.
[<Bank>.<map>]
Name=<Label>

[0.0]
Name=PETALBURG CITY

[1.0]
Name=Route 101

Belangrijk:
Hier moet je allen 'naam' veranderen.
De heading van de entry "[0.0]" is de plek waar de map is, is dit word verandert dan werkt
de map niet meer!
De offsets worden niet meer gebuikt in deze versie, maar ze kunnen er nog wel zijn.

Maar:
hier voor allen game versions de exact offset naar de Map Footer moet nog worden aangegeven.
Die zonder een Offset worden niet geladen.

[<Label from Main.ini>]
Name=<Label>
<Exact Gamelabel>=<Offset>


Voorbeeld:
[UNKNOWN45] 
POKEMON SAPPAXPD=$2CA960 
name=Insel?


Tilesets.ini
------------
De tileset-builder is niet van versie 1.30.
Hier kun je het aantal bloken avn een tileset veranderen (eerste tileset is 0)
Al de tileset in de boven gedeelte is dan heeft het auto 200 blocks.

[1]
Blocks=$90

...

[24]
Blocks=$87


Sprachen.ini
------------
Hier staan allen talen in die er zijn in de tool.
Voorlbeeld:
[Sprachen]
1=Deutsch
2=English

In de Submap "Ini/Sprachen" kun je een <Languagename> vinden. ini-file, waar de texts is opgelsagen.
Je kunt zo veel talen toevoegen als je wilt.
Je kunt de taal verandern onder "Settings"->"Language".

Bij de eerste start van AdvanceMap, kun je de taal kiesen die je wilt.

De bestanden GehDaten.ini/AufgabenDaten.ini Zitten nu in de nieuwe taal bestanden.



********************************
***          Greets          ***
********************************
A huge greeting goes to:
Jigglypuff for the Source of Goldmap2 Beta
and Jay, who gave it to me.

Further greets go to:
Tauwasser and F-Zero for their tutorials.
Mikaron for his work.
Serwe for giving me a few ideas.
Mulle who pointed me to a mistake.
Scizz, XXXXXXXXX, XXXXXXXXX, XXXXXXXXX, ... for the translations of the inis.
And of course, Filb for his board.
Another tahnk you goes out to F-Zero who helped me with the Sprite-Pallets.
Also dark01 received a big thank you for his help with the Sprites.
Thanks to evilboy for his help at the FAQs.
Another thanks goes to Scizz, dark01, BlueSonic and F-Zero for the Betatests.