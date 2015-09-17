********************************************
*** Advance Map Ver 1.80 - Francais      ***
********************************************

Ce programme est destiné à permettre de modifier les cartes, les mouvements possibles, les évènements et les informations relatives aux Pokémons sauvages qui apparaissent.
Dans le futur, les informations liées aux collisions (c-à-d les rencontres avec un objet, en se placant dessus en marchant) pouront aussi être modifiées.
Il fonctionne avec les ROM de Pokémon Rubis, Saphir et Emeraude, en langue Japonaise, Anglaise et Allemande et Française.

!!! Attention !!!
-----------------
Avec cette version, toute les modifications réalisées sont directement sauvegardées dans la ROM !
Grace à la commande "Sauvegarder sous ...", il est possible de faire une copie dans un autre fichier.
Une fois la ROM rechargée via le fichier copie, toutes les modifications sont alors sauvegardées dans le nouveau fichier.


.:|IMPORTANT|:.
-^-^-^-^-^-^-^-
Ce programme a été écrit par LU-HO Poké, et de ce fait, Copyright LU-HO Poké !
Si vous l'avez téléchargé d'un autre site que de FWB (Filb's World Board [http://www.filbboard.de]),
merci de me le signaler. Mon adresse e-mail est : lu.ho@tiscali.ch


*********************************
*** Contenus des fichiers INI ***
*********************************
AdvanceMap.ini:
--------------- 
Les fichiers INI ont été complètement revus et modifiés. 
Maintenant, chaque langage à sa configuration spécifique.
Au delà, chaque jeux à ses propres détails de configuration spécifiques.
Enfin, et cen'est pas la moindre modification, chaque Offset (décalage d'adresse) est stocké dans un pattern (signature).

Par exemple :
[MapBankHeader]
art=pointer
nach=80180068890B091808687047
spiele=BPR,BPG,BPE,AXP,AXV

Celà signifie que juste après une séquence d'octets identique à celle fournie après 'nach' (le Pattern) se trouve le pointer qui défini le décalage (l'Offset) pour le 'MapBankHeader' (Entête de la Banque de Carte).
La dernière ligne indique que cette définition est valable pour plusieurs ROM, dont la liste est donnée après 'spiele'.

Autre Exemple :
[PokemonNamen]
inkSprache=1
art=pointer
vor=30B50025084CC8F7
spiele=AXPJ,AXVJ,AXPE,AXVE

[PokemonNamen2]
art=pointer
position=$000144
spiele=BPR,BPG,BPE,AXP,AXV

Ici, il y a deux paragraphes. 
Dans le premier, le paramètre 'inkSprache' égal à 1 indique qu'il n'est valide que pour les ROM des langues spésifiées dans la liste après 'spiele'.
Ici, le pointeur  se trouve avant le pattern défini par 'vor'.
Puisque toutes les langues ne sont pas couvertes par le premier paragraphe, le deuxième paragraphe indique comment obtenir le pointeur pour les autres ROM. Ici, il sera placé" à la position absolue définie par 'position'.

Attention à toujours mettre un "$" au début d'une valeur indiquée en hexadécimal.


Main.ini
--------
Dans ce fichier sont énumérés les listes correspondant aux cartes.
Elles peuvent être triées dans l'ordre souhaités.
Le format du fichier est le suivant :

[<Foldername>]
1=<Bank>.<map>
2=<Bank>.<map>
3=<Bank>.<map>
4=<Bank>.<map>
5=<Bank>.<map>
...

Exemple :
[0]
1=0.0
2=0.1
3=0.2
...

[1]
1=1.0
...

Les noms de dossiers peuvent être modifiés à volonté;
à l'exception de :

[<FolderName>]
1=<Label>
2=<Label>
...

Pour plus de détails, voir le fichier "Maps.ini"


Maps.ini
--------
On trouve dans ce fichier les listes de cartes, mais seulement celles qui sont déclarées dans le fichier "Main.ini".

Le format est :
[<Banque>.<Carte>]
Name=<Nom_de_Carte>

Par exemple :
[0.0]
Name=PETALBURG CITY

[1.0]
Name=Route 101


Important :
Dans ce fichier, il n'est possible que de modifier la valeur du paramètre 'name' (le nom de la carte).
L'entête du paragraphe ("[<Banque>.<Carte>]", comme dans "[0.0]") est la référence à la position dans l'entête des Cartes, s'il est modifié, la carte ne fonctionnera plus !
Les décalages ('Offset') ne sont plus utilisés dans cette version, mais ils peuvent demeurer dans le fichier.

Il y a une exception :
Le décalage exact de l'en-pied de Carte (Map Footer) doit être déclaré pour toutes les versions de ROM.
Sans cette information, la ROM n'est pas chargée.

Le format est le suivant :
[<Label from Main.ini>]
Name=<Label>
<Exact Gamelabel>=<Offset>

Par exemple:
[UNKNOWN45] 
POKEMON SAPPAXPD=$2CA960 
name=Insel?


Tilesets.ini
------------
Le gestionnaire de Tilesets est apparu avec la version 1.30.
Il est maintenant possible de changer le nombre de blocs de chaque Tileset (le premier porte le numéro 0).
Si le Tileset est dans la partie haute, il a automatiquement 200 blocs.

[1]
Blocks=$90

...

[24]
Blocks=$87


Sprachen.ini
------------
On trouve dans ce fichier les données pour les différentes langues disponibles.
Exemple:
[Sprachen]
1=Deutsch
2=English

Le sous répertoire "Ini/Sprachen" contient des fichiers nommés <Nom_De_Langue>.ini, dans lesquels se trouvent les traductions des textes du programme.
vous pouvez ajouter autant de langue que vous le souhaitez, mais vous devez respecter les termed du "Contrat d'Utilisateur Final" ("EndNutzer Vertrag")
Ce "Contrat d'Utilisateur Final" doit être traduit et être transmit à LU-HO pour qu'il puisse l'encrypter.
Tans que ceci n'est pas fait, la langue n'est pas disponible dans le programme. Ensuite, vous pouvez la sélectionner avec "Settings"->"Language" ("Einstellungen"->"Sprache").

Lors du premier démarrage de AdvanceMap, vous pouvez sélectionner la langue de votre choix.

Les fichiers GehDaten.ini/AufgabenDaten.ini ainsi que d'autres ont maintenant été intégrés dans le nouveau fichier de langue.


********************************
***      Remerciements       ***
********************************
Les plus grand remerciements vont à Jigglypuff pour le Code Source de Goldmap2 Beta et à Jay, qui me l'a transmis.

Que soient aussi remerciés :
Tauwasser et F-Zero pour leurs tutoriaux.
Mikaron pour ses travaux.
Serwe qui m'a apporté quelques idées.
Mulle qui m'a signalé une erreur dans le programme.
Scizz, Timhay, GruntZ, Ashly138, Usohachi, BlueSonic, Sylph, Liquid_Thunder, IIIMQIII, Netto-kun pour leurs traductions des fichiers ini.
Et bien sûr Filb pour son Board.

Un autre grand merci à F-Zero qui m'a aidé sur les Palettes de Sprites.
Merci également à dark01 pour son aide sur les Sprites.
Merci à evilboy for son aide sur les FAQs.

Un dernier grand merci pour Scizz, dark01, BlueSonic et F-Zero pour leur rôle de béta-testeurs.
