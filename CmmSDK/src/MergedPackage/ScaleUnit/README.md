# Proyecto solo para CSU Cloud en AZURE

Este proyecto sirve para agrupar todos los paquetes DevAx###.
Cada paquete DevAx### debe usar su proyecto ScaleUnit.csproj para generar nugets.
En el archivo csproj se deben agregar los PackageReference usando los nugets generados.
De esta manera serán incluidos todos juntos en el compilado resultante de este proyecto.
El resultado es un archivo DevAx####.zip con todas las extensiones (POS+CRT) para ser subido al LCS con el fin de desplegarlo en entornos CSU in Cloud.
