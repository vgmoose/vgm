********************************************
*** Advance Map Ver 1.80 - Afrikaans     ***
********************************************

Die program is vir die reditering van Landkaart-, bewegingspermissies, teël-, gebeurtenis-, en wildspokemondata.
Later botsdata behoort ook om rediteerbaar te wees.
Die Program werk ook met die Robyn en Saffier versies, Japanees an Engels.

!!!LET WEL!!!
-------------
Met die versie, sal alle veranderings direk na die ROM gerugsteen word!
Jy kan "Rugsteen As" gebruik om die huidiglike Landkaart in 'n ander leêr te rugsteen.
Wanneer 'n leêr galaai is, is 'n kopie van dit gemaak.
Alle nuwe veranderings is na die nuwe leêr gerugsteen.



.:|BELANGRIK|:.
-^-^-^-^-^-^-
Die program is deur LU-HO Poké geprogrameer, en dus, hou hy ook die kopiereg vir dit.
As jy die program op 'n ander webtuiste afgelaai het, behalwe die FWB(Filb's World board [http://www.filbboard.de]),
laat weet my so gou moontilk, assebleif. My e-pos is: lu.ho@tiscali.ch


********************************
***     Inhoud van Inis      ***
********************************
AdvanceMap.ini:
--------------- 
Die hele INI was oorgedoen.
Elke taal het nou sy eie spesifieke stellings.
Sommige speletjies het ook spesefieke stellings.
Alle spruite is volgens 'n patroon gestoor.

Voorbeeld:
[Landkaartlokasievatekopper]
art=wyser
nach=80180068890B091808687047
spiele=BPR,BPG,BPE,AXP,AXV

Dit beteken dat na die grepe, na "nach" is die wyser na die Landkaartvatekopper die opvolgende. Die begin by "08"
Die fomaat gaan vir al die speletjies wat onder "spiele" verskyn.


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

Hier verskyn 2 inskrywings. In die eerste, verskyn al die taal parameters in die "spiele" lys, want "inkSprache" is na 1 gestel.
Ons het ook 'n wyser na die data by "vor". Onthou, alle wysers begin met "08" vir die versioene.
Omdat die eerste inskrywing nie kompleet is nie, is daar 'n tweede inskrywing wat vir al die versioene gebruik sal word.
Na die tweede inskrywing, sal die wyser gevind word in die posisie gestel in die "position" veranderlike.


Hexgetalle moet altyd 'n "$" as 'n voorsetsel hê!


Main.ini
--------
Hier verskyn die ordes met die ooreenstemmende landkaarte.
Many new orders can be produced at will.
The format is as follows:

[<Vouernaam>]
1=<Lokasie>.<Landkaart>
2=<Lokasie>.<Landkaart>
3=<Lokasie>.<Landkaart>
4=<Lokasie>.<Landkaart>
5=<Lokasie>.<Landkaart>
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

Jy mag die vouername verander;

BEHALWE:
[<Vouernaam>]
1=<Etiket>
2=<Etiket>
...
Vir ander voorbeelde, sien Maps.ini


Maps.ini
--------
Hier verskyn slegs die landkaarte wat in Main.ini verskyn.
[<Lokasie>.<Landkaart>]
Naam=<Etiket>

[0.0]
Name=PETALBURG CITY

[1.0]
Name=Route 101

BELANGRIK:
Hier moet jy slegs die "Etiket" verander!!
Die hoofskrif "[0.0]" verwys na die lokasie van die landkaartvatekopper, as die verander word
sal die landkaarte nie meer werk nie!
Die spruite word nie meer in die versie gebruik nie. Hulle kan maar in die dokument gelos word.

BEHALWE:
Al die versies van die speletjie waar die presiese spruit as die landkaartstapper gegee moet word.
Die sonder 'n spruit sal nie gelaai word nie.

[<Etiket van Main.ini>]
Naam=<Etiket>
<Presiese Speletjiesetiket>=<Spruit>


Voorbeeld:
[UNKNOWN45] 
POKEMON SAPPAXPD=$2CA960 
name=Insel?


Teëlstelle.ini
------------
Die teëlstelbouer is nuut van versie 1.30.
Jy kan hier, as jy wil, die getal Teëls 'n teëlstel bevat verander. Die eerste teëlstel is 0.
As die teëlstel in die opper gedeelte is, het die altyd 200 blokke.

[1]
Blocks=$90

...

[24]
Blocks=$87


Sprachen.ini
------------
Hier verskyn al die beskikbare tale.
Voorbeeld:
[Sprachen]
1=Deutsch
2=English

In die subvouer "Ini/Sprachen" kan jy 'n <Languagename>.ini-leêr vind, waarin al die tekste verskyn.
Jy kan baie ander tale insit, maar jy moet dan die "EndNutzer Vertrag" ook vertaal.
Stuur dit dan vir my per e-pos sodat ek dit kan kodeer.
Die taal wat jy ingesit het sal dan eers beskikbaar word.
Jy kan die taal verander by "Stellings"->"Taal".

By die eerste gebruik van AdvanceMap, kan jy die taal kies.

Die lêre GehDaten.ini/AufgabenDaten.ini en die ander is by die nuwe taallêre ingesluit.



********************************
***          Groete          ***
********************************
'n Groot Hallo aan:
Jigglypuff vir die bron van Goldmap2 Beta
en Jay, wie dit vir my gegee het.

Verdere Groete aan:
Tauwasser en F-Zero vir hulle tutorials.
Mikaron vir sy werk.
Serwe, wie vir my 'n paar idees gegee het.
Mulle, wie vir my 'n fout wat ek begaan het aangewys.
Scizz, Timhay, GruntZ, Ashly138, Usohachi, BlueSonic, Sylph, Liquid_Thunder, IIIMQIII, Netto-kun vir die vertaling van die INI's.
en laaste, aan Filb vir sy bord.
Nog 'n dankie aan F-Zero wie vir my met die sprietpalette gehelp het.
Dark01 vir sy hulp met die spriete.
Dankie ook aan evilboy vir sy hulp by die FAQs.
En ook weer aan Scizz, dark01, BlueSonic and F-Zero vir die "Betatests".