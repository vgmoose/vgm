********************************************
*** Advance Map Ver 1.80 - Polish        ***
********************************************

Ten program s³u¿y do edycji map, zezwoleñ ruchu, danych klocków, event'ów i danych dzikich pokemon'ów.
PóŸniej do edycji powinny byæ dostêpne te¿ dane kolizji.
Dzia³a on z ROM'ami Pokemon Ruby and Sapphire, Japanese and English.

!!!Uwaga!!!
-------------
W tej wersji zmiany s¹ zapisywane bezpoœrednio do ROM'a!
Wciœnij "Zapisz jako" by zapisaæ mapê w innym pliku.
Potem wczytaj œwie¿o stworzony plik.
Wszystkie kolejne zmiany bêd¹ zapisywane w nowym pliku.



.:|WA¯NE|:.
-^-^-^-^-^-^-
Ten program zosta³ stworzony przez LU-HO Poké i w rezultacie prawa autorskie nale¿¹ do LU-HO Poké!
Je¿eli pobra³eœ ten plik z innej strony ni¿ FWB(Filb's World board [http://www.filbboard.de]),
proszê napisz mi o tym szybko! Mój mail to: lu.ho@tiscali.ch


**************************************
***    Zawartoœæ plików ".ini"     ***
**************************************
AdvanceMap.ini:
--------------- 
Ten plik zosta³ kompletnie zmieniony.
Teraz ka¿dy jêzyk posiada swoje w³asne ustawienia.
W przysz³oœci ka¿da gra bêdzie posiada³a swoje w³asne ustawienia.
Ostatnie, lecz nie ostatnie, ka¿dy offset jest przechowywany za pomoc¹ wzoru.

Przyk³ad:
[MapBankHeader]
art=pointer
nach=80180068890B091808687047
spiele=BPR,BPG,BPE,AXP,AXV

To znaczy, ¿e za bajtem "nach" bêdzie pod¹¿a³ pointer od nag³ówka mapy. 
Te opcje znajduj¹ siê pod lini¹ "spiele".


Przyk³ad 2:
[PokemonNamen]
inkSprache=1
art=pointer
vor=30B50025084CC8F7
spiele=AXPJ,AXVJ,AXPE,AXVE

[PokemonNamen2]
art=pointer
position=$000144
spiele=BPR,BPG,BPE,AXP,AXV

To s¹ 2 wyjœcia. w pierwszym, wszystkie poarametry jêzykowe s¹ ustawione w "spiele"- , poniewa¿ "inkSprache" jest ustawione na 1.
Also we have the pointer to the at point "vor" described Bytes.
Poniewa¿ nie we wszystkich grach mo¿na wyko¿ystaæ pierwsze wyjœcie, jest drugie wyjœcie, które zosta³o u¿yte do wszystkich gier.
W drugim wyjœciu, pointer znajduje siê na swojej pozycji w "position" zmiennie.


Wartoœci hex'owe zawsze maj¹ przed sob¹ znak "$"!


Main.ini
--------
Tu s¹ zamieszczone wszystkie zarz¹dzenia odpowiadaj¹ce mapom.
Wszystko jest zapisane w poni¿szym formacie:

[<Foldername>]
1=<Bank>.<map>
2=<Bank>.<map>
3=<Bank>.<map>
4=<Bank>.<map>
5=<Bank>.<map>
...

Przyk³ad:
[0]
1=0.0
2=0.1
3=0.2
...

[1]
1=1.0
...

Nazwy folderów mo¿esz sobie zmieniaæ dowoli;

S¹ pewne wyj¹tki:
[<nazwa folderu>]
1=<etykieta>
2=<etykieta>
...
Po wiêcej musisz zerkn¹æ do Maps.ini


Maps.ini
--------
Tu znajduje siê spis map, ale tylko tych które s¹ zapisane w Main.ini .
[<Bank>.<map>]
Name=<etykieta>

[0.0]
Name=PETALBURG CITY

[1.0]
Name=Route 101

Wa¿ne:
Tu znajdzeisz tylko atrybuty 'name'.
Wyjœciowym jest "[0.0]" je¿eli jego zabraknie ¿adna mapa nie zadzia³a!
Offsety ju¿ nie s¹ u¿ywane w tej wersji wiêc mo¿esz je zmieniæ.

Wyj¹tek:
Tutaj etykieta do offset'u z stopki mapy musi byæ zadeklarowana.
Bez tego offset siê nie za³aduje.

[<etykieta od Main.ini>]
Name=<etykieta>
<Dok³adna etykieta gry>=<Offset>


Przyk³ad:
[UNKNOWN45] 
POKEMON SAPPAXPD=$2CA960 
name=Insel?


Tilesets.ini
------------
Tileset-builder jest nowszy od wersji ver. 1.30.
Teraz mo¿esz zmieniaæ numery klocków z tymi z innych tileset'ów (pierwszy tileset to 0)
Je¿eli tlieset jest w wy¿szej czêœci zmianie ulegnie 200 klocków.

[1]
Blocks=$90

...

[24]
Blocks=$87


Sprachen.ini
------------
Wszystkie jêzyki s¹ zapisane w pewien sposób.
Przyk³ad:
[Sprachen]
1=Deutsch
2=English

w pod-folderze "Ini/Sprachen" mo¿esz znaleŸæ <nazwa jêzyka>.ini-file, gdzie s¹ przechowywane teksty.
Mo¿esz dodaæ tyle jêzyków, ile dusza zapragnie, ale musisz uwa¿aæ na "EndNutzer Vertrag".
"EndNutzer Vertrag" musi byæ przt³umaczone, a ¿eby to zrobic musisz wys³aæ do mnie ten jêzyk a ja go zamieszczê.
Jak d³ugo tego nie zrbisz, tak d³ugo ten jêzyk nie bêdzie dostêpny ....
Mo¿esz zmieniaæ jêzyki w "Settings"->"Language".

w czasie pierwszego startu AdvanceMap'a, mo¿esz wybraæ jêzyk.

Pliki GehDaten.ini/AufgabenDaten.ini i inne s¹ zaliczone w pliki nowego jêzyka.



***************************
***    Podziêkowania    ***
***************************
Wielkie podziêkowania id¹ do:
Jigglypuff for the Source of Goldmap2 Beta
and Jay, who gave it to me.

Dalsze podziêkowania wêdruj¹ do:
Tauwasser and F-Zero for their tutorials.
Mikaron for his work.
Serwe for giving me a few ideas.
Mulle who pointed me to a mistake.
Scizz, Timhay, GruntZ, Ashly138, Usohachi, BlueSonic, Sylph, Liquid_Thunder, IIIMQIII, Netto-kun for the translations of the inis.
And of course, Filb for his board.
Another tahnk you goes out to F-Zero who helped me with the Sprite-Pallets.
Also dark01 received a big thank you for his help with the Sprites.
Thanks to evilboy for his help at the FAQs.
Another thanks goes to Scizz, dark01, BlueSonic and F-Zero for the Betatests.