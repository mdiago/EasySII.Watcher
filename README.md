# README #

### Introducción a EasySII Monitor ###

Esta aplicación es un ejemplo del uso de la biblioteca EasySII para la serialización XML y gestión de comunicaciones con el SII de la AEAT. Utiliza EasySII para la realización de envíos de ficheros XML al SII de la AEAT. 
La aplicación consiste en un Servicio de Windows que monitorea continuamente una carpeta de salida configurada en el sistema. En el momento en el que una archivo XML es creado en la carpeta de salida, este se transfiere al SII, se recupera la respuesta que queda almacenada en una carpeta de entrada, y el fichero XML de salida se archiva en una carpeta de fichero enviados.

* [Más información en la Página desarrolladores Irene Solutions](https://www.irenesolutions.com/developers.html#sii)

### Inicio Rápido ###

* Instalación del certificado digital

Lo primero que necesita el software para trabajar es acceso a un certificado digital válido para la comunicación con la AEAT. Al tratarse de un servicio de windows, hay que asegurarse que la cuenta de usuario con la que corre, tiene acceso al certificado. Para ello debemos asegurarnos de que el mismo está instalado en el almacén de certificados de 'Local Machine'.

