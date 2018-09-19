# README #

### Introducción a EasySII Monitor ###

Esta aplicación es un ejemplo del uso de la biblioteca EasySII para la serialización XML y gestión de comunicaciones con el SII de la AEAT. Utiliza EasySII para la realización de envíos de ficheros XML al SII de la AEAT. 
La aplicación consiste en un Servicio de Windows que monitorea continuamente una carpeta de salida configurada en el sistema. En el momento en el que una archivo XML es creado en la carpeta de salida, este se transfiere al SII, se recupera la respuesta que queda almacenada en una carpeta de entrada, y el fichero XML de salida se archiva en una carpeta de fichero enviados.

* [Más información en la Página desarrolladores Irene Solutions](https://www.irenesolutions.com/developers.html#sii)

### Inicio Rápido ###

* Instalación del certificado digital

Lo primero que necesita el software para trabajar es acceso a un certificado digital válido para la comunicación con la AEAT. Al tratarse de un servicio de windows, hay que asegurarse que la cuenta de usuario con la que corre, tiene acceso al certificado. Para ello debemos asegurarnos de que el mismo está instalado en el almacén de certificados de 'Local Machine'.

* Ubicación por defecto carpeta de salida

La ubicación por defecto de la carpeta de salida está en la ruta: C:\ProgramData\EasySIIWatcher\Outbox. Se puede cambiar mediante las opciones de configuración del programa.

* Ubicación por defecto carpeta de entrada

La ubicación por defecto de la carpeta de salida está en la ruta: C:\ProgramData\EasySIIWatcher\Inbox. Se puede cambiar mediante las opciones de configuración del programa.

* Ubicación por defecto carpeta de enviados

La ubicación por defecto de la carpeta de salida está en la ruta: C:\ProgramData\EasySIIWatcher\History. Se puede cambiar mediante las opciones de configuración del programa.

* Utilización básica del servicio

Al copiar cualquier archivo XML en la carpeta de salida este será transmitido al SII. Si el fichero creado es un archivo CSV, este se utilizará para la creación y envío de los archivos XML al SII.

* Estructura del fichero CSV para serialización y envío masivo de facturas

El archivo CSV se debe componer de 21 columnas y debe estar codificado en Windows ANSI codepage 1252.  
- Columna 0 (?????):  
- Columna 1: Documento. Número de factura o documento a procesar.

