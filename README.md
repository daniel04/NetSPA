# NetSPA

Este proyecto es un ejemplo de un SPA con .Net 7 + Angular 15 (compatibles con .Net 8 + Angular 17) 

## Pre-requisitos

* Backend
* .NET 7
* Frontend 
  * NodeJs (cualquier LTS, actual 20.x) 
  * Angular

## Verificar entorno de desarrollo

1. .NET -> # dotnet --version
2. Npm -> # npm -v
3. Angular -> # ng v

## Inicializar un proyecto

1. Ubicar la linea de comandos (CMD) en una carpeta para trabajar
2. Crear proyecto: # dotnet new angular -n NetSPA --no-https 
3. Ingresar a la carpeta creada: # cd NetSPA
4. Ejecutar app: # dotnet run

## Descripción del proyecto generado

1. ClientApp -> FRONTEND (angular)
2. Controlers -> BACKEND (.net/c#)
3. Ejemplo: 
   1. Ingresar a la pag principal de Bootstrap
   2. Buscar una tabla de ejemplo
   2. Copiar el código html al archivo `home.component.html` de `ClientApp/src/app/home`

## Crear Servicio Producto

1. Crear Carpetas: ServiceApp -> Model, Serivices
2. Crear clase Producto, con cualquier atributo
3. Crear servicio de Producto 
   1. Retornar una lista que contenga objetos Producto con datos de prueba

## Crear Controlador Producto

1. En la carpeta Controllers, crear un archivo: ProductosController.cs, dentro crear la clase ProductosController
2. Copiar los atributos de la clase WeatherForecastController 
   1. `[ApiController]`
   2. `[Route("[controller]")]`
3. Crear servicio con el atributo `[HttpGet]`, `public IEnumerable<Producto> GetAll()` 
  1. Instanciar al Servicio: `var productoService = new ProductoService()` y retornar la lista de prueba.

## Consumir desde Angular al Servicio REST: ProductosController

Con base de `fetch-data/fetch-data.component.ts` y su template `fetch-data/fetch-data.component.html` 

Dentro de la carpeta `ClientApp/src/app/home` realizar lo sgte.:

1. Crear una interfaz Producto, con los mismos atributos que la clase Producto.cs
2. Crear una lista de Producto: `public productoList: Producto[] = []`
3. Copiar el Contructor de `fetch-data.component.ts` y reemplazar los tipos de dato y el nombre del servicio REST:
   1. `WeatherForecast[]` ==> `Producto[]`
   2. `baseUrl + 'weatherforecast'` ==> `baseUrl + 'productos'`
4. Agregar el proxy para el servicio REST en Proxy:
   1. Ingresar al archivo `ClientApp/proxy.conf.js`
   2. Agregar a la lista de `const PROXY_CONFIG` el nombre del servicio REST nuevo, en este caso: `"/productos"`

## Acceso a la base de datos con EntityFramework con enfoque Code First

Para esta sección se utiliza una base de datos PostgreSQL y las referencias de la documentación oficial de Microsoft.

Abrir CMD, dirigirse a la raíz del proyecto y seguir los pasos a continuación:

### 1. Configurar Entity Framework 

Referencia: https://learn.microsoft.com/es-es/ef/core/get-started/overview/install

1. Instalar EF de forma global: `# dotnet tool install --global dotnet-ef`
2. Instalar herramientas de EF: `# dotnet add package Microsoft.EntityFrameworkCore.Design -v 6` **(*)**
3. Instalar driver de conexión: `# dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL -v 6` **(*)**

**(*)** El parámetro `-v 6` indica la versión de .net, cambiar por la versión que usa.

### 2. Conectar el proyecto a la base de datos

* Referencia:  https://learn.microsoft.com/es-es/ef/core/get-started/overview/first-app?tabs=netcore-cli
* Cadenas de conexión (si usa diferente a PostgreSql): https://learn.microsoft.com/es-es/ef/core/miscellaneous/connection-strings

1. Crear la clase de Contexto el la carpeta Model `ServicesApp/Model/SpaContext.cs` (revisar los comentarios de la clase `SpaContext`)
2. Agregar la cadena de conexión `"ConnectionStrings"` al archivo `appsettings.json` (revisar el archivo).
3. Configurar la conexión en `Program.cs` (revisar los comentarios del archivo).

### 3. Crear/actualizar las tablas de la base de datos

Referencia: https://learn.microsoft.com/es-es/ef/core/get-started/overview/first-app?tabs=netcore-cli

1. Crear Migración inicial con CMD: `# dotnet ef migrations add CreadoInicial`
2. Actualizar/crear las tablas de la base de datos: `# dotnet ef database update`

## Acceso a la base de datos con EntityFramework con enfoque Data base First

Referencia: https://learn.microsoft.com/es-es/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli#required-arguments

Para este enfoque seguir los pasos 1 y 2 de lo anterior luego:

Crear las clases desde la base de datos: `dotnet ef dbcontext scaffold "Name=ConnectionStrings:tienda-virtual" Npgsql.EntityFrameworkCore.PostgreSQL`

Donde:
* `tienda-virtual` es el nombre de la base de datos
* `Npgsql.EntityFrameworkCore.PostgreSQL` es el driver de conexión (cambiar al que corresponde si usa otra base de datos)

