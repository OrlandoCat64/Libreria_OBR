1. Requisitos Previos

Antes de desplegar la API, asegúrate de tener:

Windows 10/11 o Windows Server.

IIS (Internet Information Services) instalado:

Características necesarias:

Servidor web (IIS)

ASP.NET 4.8 (o la versión que uses)

Extensiones de .NET

Servicios de IIS > Características de desarrollo de aplicaciones > ASP.NET

.NET Framework o .NET Core/ASP.NET Core Runtime, según tu proyecto.

Visual Studio 2022/2019 (opcional, para compilar el proyecto).

SQL Server Local (si la API requiere base de datos local).

2. Preparar la API

Abre tu proyecto en Visual Studio.

Configura la conexión a la base de datos en appsettings.json o en Web.config según tu proyecto.

Compila el proyecto en Release:

Build > Publish

Selecciona Folder (Carpeta) como destino.

Por ejemplo: C:\Deploy\LibroAPI

Esto genera todos los archivos necesarios para IIS.

3. Configurar IIS

Abre Administrador de IIS:

Inicio > Buscar: IIS > Administrador de Internet Information Services (IIS).

Crear un Sitio Web nuevo:

Click derecho en Sitios > Agregar sitio web.

Nombre del sitio: LibroAPI

Ruta física: C:\Deploy\LibroAPI (la carpeta donde publicaste)

Puerto: 8080 (o el que prefieras)

Hostname: opcional

Configura la aplicación como .NET:

En Pool de aplicaciones, selecciona:

.NET CLR Version v4.0 para .NET Framework

No Managed Code para ASP.NET Core

Tipo de pipeline: Integrated

Asignar permisos:

Asegúrate que IIS_IUSRS tenga permisos de lectura/escritura en la carpeta de la API.


4. Probar la API

Abre tu navegador o Postman.

Ingresa la URL del sitio:

http://localhost:8080/api/libro/autor/1


Deberías obtener la respuesta JSON de tu API.

5. Configuración opcional de CORS

Si tu front-end (por ejemplo LibrosJS) está en otra URL, habilita CORS en tu API:

// En WebApiConfig.cs o Startup.cs
var cors = new EnableCorsAttribute("*", "*", "*");
config.EnableCors(cors);

6. Solución de problemas comunes
Problema	Solución
404 Not Found	Revisa la ruta del sitio en IIS y que web.config exista.
500 Internal Server Error	Verifica la conexión a la base de datos y permisos de la carpeta.
CORS	Configura correctamente EnableCors o usa un proxy en desarrollo.
IIS no inicia la app	Reinicia el Pool de aplicaciones y verifica el Application Pool Identity.
