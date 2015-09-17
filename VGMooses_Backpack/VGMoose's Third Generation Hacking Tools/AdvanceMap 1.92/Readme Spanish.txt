********************************************
*** Advance Map Ver 1.80 - Español       ***
********************************************

Este programa sirve para editar Mapas, movimientos permitidos, data de los bloques, eventos y los pokémons salvajes.
Funciona con Pokémon Rubí & Zafiro, Japones y Ingles

!!!Atención!!!
-------------
Con esta version todos los cambios son guardados directo al rom!
Pero con "Guardar Como" se puede guardar el mapa actual en otro archivo
Una vez cargado, se realiza una copia de archivo actual 
Todos los futuros cambios son guardados en el nuevo archivo




.:|IMPORTANTE|:.
-^-^-^-^-^-^-^-^
Este programa fue hecho por LU-HO Poké y esta registrado por LU-HO Poké!
Si descargaste el programa de una web que no es FWB(Filb's World board [http://www.filbboard.de]
reportamelo por favor a mi mail! Mi mail es: lu.ho@tiscali.ch


********************************
***     Contenido de los Inis     ***
********************************
AdvanceMap.ini:
--------------- 
Este INI fue completamente cambiado.
Ahora cada idioma tiene sus opciones especificas.
Y cada juego tiene algunas opciones especificas de ese juego

Main.ini
--------
Aqui se encuentra el orden con la lista de mapas correspondientes.
Nuevos ordenes puedes ser producidos de ser deseado.
El formato es el siguiente:

[<Foldername>]
1=<Bank>.<map>
2=<Bank>.<map>
3=<Bank>.<map>
4=<Bank>.<map>
5=<Bank>.<map>
...

Ejemplo:
[0]
1=0.0
2=0.1
3=0.2
...

[1]
1=1.0
...

Los nombres de las capertas pueden ser cambiados como desees.

Hay execpiones:
[<FolderName>]
1=<Label>
2=<Label>
...
Para ve más, ver Maps.ini


Maps.ini
--------
Aqui estan los mapas, pero solo los que estan listado en Main.ini apareceran
[<Bank>.<map>]
Name=<Label>

[0.0]
Name=PETALBURG CITY

[1.0]
Name=Route 101

Importante:
Aqui solo de debe cambiar el atributo 'name'.
El encabezado "[0.0]" se refiere a la posicion del mapa, si es cambiado los mapas no funcionaran másp!
En esta version no se usan más offsets, aunque puede que esten todavia.

La excepcion:
Para todas las versiones se debe poner el offset exacto.
Los que no tengan offset no seran cargados.

[<Label from Main.ini>]
Name=<Label>
<Exact Gamelabel>=<Offset>


Ejemplo:
[UNKNOWN45] 
POKEMON SAPPAXPD=$2CA960 
name=Insel?


Tilesets.ini
------------
El creador de tilesets es nuevo que el de la version 1.30
Aqui se puede cambiar el numero de bloques en cada tileset (el primer tileset es 0)
Si el tileset esta en la parte de arrbia automaticamente tiene 200 bloques.

[1]
Blocks=$90

...

[24]
Blocks=$87


Sprachen.ini
------------
Aqui estan todos los idiomas disponibles.
Example:
[Sprachen]
1=Deutsch
2=English

En la subcarpeta "Ini/Sprachen" puedes encontrar el archivos <Languagename>.ini, en donde los textos estan guardados.
Puedes agregar tantos idiomas como quieras, pero ten cuidado de el "End-User Agreement".
El "Acuerdo End-User" debe ser traducido, y debe ser enviado a mi para poder encriptarlo.
Si el idioma no aparece, es que no esta disponible...
Se puede cambiar el idioma en "Settings"->"Language".

Al abrir AdvanceMap, se puede elegir el idioma deseado.
Los archivos GehDaten.ini/AufgabenDaten.ini y otros fueron incluidos en los nuevos archivos de idiomas.



********************************
***     Agradecimientos      ***
********************************
Gran agradecimiento para:
Jigglypuff por la fuente de Goldmap2 Beta
y a Jay, que fue el que me la dio.

Otros agradecimientos a:
Tauwasser y F-Zero por sus guias.
Mikaron por su trabajo.
Serwe por darme ideas.
Mulle el cual me marco un error.
Scizz, Timhay, GruntZ, Ashly138, Usohachi, BlueSonic, Sylph, Liquid_Thunder, IIIMQIII, Netto-kun por la traduccion de los inis.
También, a Filb por su foro.
Otra a F-Zero que me ayudo con las Paletas de los Sprites.
A dark01 que también me ayudo con los Sprites.
Gracias a evilboy  por su ayuda con los FAQs.
Y por ultimo a Scizz, dark01, BlueSonic y F-Zero por los Betatests.