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

La ubicación por defecto de la carpeta de entrada está en la ruta: C:\ProgramData\EasySIIWatcher\Inbox. Se puede cambiar mediante las opciones de configuración del programa.

* Ubicación por defecto carpeta de enviados

La ubicación por defecto de la carpeta de envíados está en la ruta: C:\ProgramData\EasySIIWatcher\History. Se puede cambiar mediante las opciones de configuración del programa.

* Utilización básica del servicio

Al copiar cualquier archivo XML en la carpeta de salida este será transmitido al SII. Si el fichero creado es un archivo CSV, este se utilizará para la creación y envío de los archivos XML al SII.

### Estructura del fichero CSV para serialización y envío masivo de facturas ###

El archivo CSV se debe componer de 21 columnas y debe estar codificado en Windows ANSI codepage 1252.  
- Columna 00: Tipo documento. 'FE' para facturas emitidas, 'FR' para facturas recibidas, 'OI' para determinadas operaciones intracomunitarias.  
- Columna 01: Documento. Número de factura o documento a procesar.
- Columna 02: Fecha emisión. Fecha de emisión del documento a procesar.  
- Columna 03: Fecha registro. Fecha en la que el documento ha sido registrado en contabilidad.
- Columna 04: Fecha contable. Fecha de contabilización del documento.
- Columna 05: NIF contraparte. Identificador fiscal de la contraparte.
- Columna 06: Nombre contraparte. Denominación del interlocutor de la operación (cliente, acreedor...).
- Columna 07: Descripción operación.
- Columna 08: Base imponible IVA. Para facturas con múltiples bases y tipos hay que incluir una línea por cada tipo.
- Columna 09: Tipo impositivo IVA.
- Columna 10: Cuota IVA.
- Columna 11: Indicador servicio. En las operaciones que requieren desglose por tipo operación, se diferencia a los servicios de las entregas marcando el registro con una 'X' en esta columna. Si el indicador de servicio contiene una 'X' el detalle se serializara como servicio en el bloque DesgloseTipoOperacion.
- Columna 12: Indicador inversión sujeto pasivo. En las operaciones con inversión de sujeto pasivo, se marcará el registro con una 'X' en esta columna. 
- Columna 13: Indicador de importación. 'X' para indicar de que se trata de una liquidación de IVA de aduana normal (en este caso se incluye como contraparte a la empresa informadora, y se incluye el número de DUA como número de documento). 'LC' para indicar que se trata de una liquidación complementaria de aduanas.
- Columna 14: Número factura rectificada. Número de la factura rectificada para rectificaciones de facturas emitidas.
- Columna 15: Fecha operación / Fecha factura rectificada. Cuando se trata de una factua rectificativa (existe un número de factura    rectificada en la columna 14) esta columna se utiliza como la fecha de la factura rectificada. Si la columna 14 está vacía, esta columna se entiende como Fecha operación.
- Columna 16: Dirección operador. Únicamente se informa para los tipos de documento 'OI'.
- Columna 17: País. Código ISO de pais de la contraparte de la operación.
- Columna 18: Indicador de alquiler. 'X' en el caso de que se trate de una factura emitida por alquiler.
- Columna 19: Tipo factura. F1 (Factura), F2 (Factura Simplificada), R1 (Factura Rectificativa Art 80.1 y 80.2 y error fundado en derecho) ...
- Columna 20: Indicador de autofactura. 'X' si se trata de una autofactura.

