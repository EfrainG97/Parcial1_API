# Parcial1_API — API REST de Alumnos

API REST desarrollada con **ASP.NET Core 8** y **Entity Framework Core** que permite gestionar un catálogo de alumnos mediante operaciones CRUD. Utiliza **SQL Server** como base de datos y expone documentación interactiva con **Swagger/OpenAPI**.

---

## Tabla de contenidos

- [Tecnologías](#tecnologías)
- [Estructura del proyecto](#estructura-del-proyecto)
- [Modelo de datos](#modelo-de-datos)
- [Requisitos previos](#requisitos-previos)
- [Configuración](#configuración)
- [Ejecución](#ejecución)
- [Endpoints](#endpoints)
  - [Obtener todos los alumnos](#obtener-todos-los-alumnos)
  - [Obtener un alumno por ID](#obtener-un-alumno-por-id)
  - [Crear un alumno](#crear-un-alumno)
  - [Actualizar un alumno](#actualizar-un-alumno)
  - [Eliminar un alumno](#eliminar-un-alumno)
- [Datos semilla](#datos-semilla)
- [Swagger](#swagger)

---

## Tecnologías

| Componente | Versión / Paquete |
|---|---|
| .NET | 8.0 |
| ASP.NET Core Web API | 8.0 |
| Entity Framework Core (SQL Server) | 8.0.23 |
| Swashbuckle (Swagger) | 6.6.2 |

---

## Estructura del proyecto

```
Parcial1_API/
??? Controllers/
?   ??? AlumnosController.cs   # Controlador con los endpoints CRUD
??? Data/
?   ??? AlumnoContext.cs        # DbContext y datos semilla
??? Migrations/                 # Migraciones de Entity Framework
??? Model/
?   ??? Alumno.cs               # Modelo de la entidad Alumno
??? appsettings.json            # Cadena de conexión y configuración
??? Program.cs                  # Punto de entrada y configuración de servicios
??? Parcial1_API.csproj         # Archivo de proyecto
```

---

## Modelo de datos

La entidad **Alumno** tiene las siguientes propiedades:

| Propiedad | Tipo | Descripción |
|---|---|---|
| `ID` | `int` | Identificador único (clave primaria) |
| `Matricula` | `int` | Número de matrícula del alumno |
| `Nombre` | `string?` | Nombre completo |
| `Edad` | `int` | Edad del alumno |
| `Carrera` | `string?` | Carrera que cursa |

---

## Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/sql-server) (local o remoto)
- (Opcional) [Visual Studio 2022](https://visualstudio.microsoft.com/) 17.8+

---

## Configuración

1. **Clonar el repositorio:**

   ```bash
   git clone https://github.com/EfrainG97/Parcial1_API.git
   cd Parcial1_API
   ```

2. **Configurar la cadena de conexión** en `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "AlumnoContext": "Server=localhost;Database=Cliente-Servidor;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
   }
   ```

   Ajusta `Server` y `Database` según tu entorno.

3. **Aplicar las migraciones** para crear la base de datos y los datos semilla:

   ```bash
   dotnet ef database update --project Parcial1_API
   ```

   > Si aún no existen migraciones, créalas primero:
   > ```bash
   > dotnet ef migrations add InitialCreate --project Parcial1_API
   > dotnet ef database update --project Parcial1_API
   > ```

---

## Ejecución

```bash
dotnet run --project Parcial1_API
```

La API estará disponible en:

| Protocolo | URL |
|---|---|
| HTTP | `http://localhost:5000` |
| HTTPS | `https://localhost:5001` |

---

## Endpoints

Base URL: `/api/Alumnos`

### Obtener todos los alumnos

```
GET /api/Alumnos
```

**Respuesta** `200 OK`:

```json
[
  {
    "id": 1,
    "matricula": 2024001,
    "nombre": "Ana López",
    "edad": 20,
    "carrera": "Ingeniería"
  },
  ...
]
```

---

### Obtener un alumno por ID

```
GET /api/Alumnos/{id}
```

| Parámetro | Ubicación | Tipo | Descripción |
|---|---|---|---|
| `id` | ruta | `int` | ID del alumno |

**Respuestas:**

| Código | Descripción |
|---|---|
| `200 OK` | Devuelve el alumno solicitado |
| `404 Not Found` | No existe un alumno con ese ID |

---

### Crear un alumno

```
POST /api/Alumnos
```

**Body** (`application/json`):

```json
{
  "matricula": 2024011,
  "nombre": "Roberto Castillo",
  "edad": 21,
  "carrera": "Física"
}
```

**Respuestas:**

| Código | Descripción |
|---|---|
| `201 Created` | Alumno creado. Devuelve el recurso con su `id` y el header `Location` |

---

### Actualizar un alumno

```
PUT /api/Alumnos/{id}
```

| Parámetro | Ubicación | Tipo | Descripción |
|---|---|---|---|
| `id` | ruta | `int` | ID del alumno a actualizar |

**Body** (`application/json`):

```json
{
  "id": 1,
  "matricula": 2024001,
  "nombre": "Ana López Martínez",
  "edad": 21,
  "carrera": "Ingeniería Civil"
}
```

> El campo `id` del body debe coincidir con el `id` de la ruta.

**Respuestas:**

| Código | Descripción |
|---|---|
| `204 No Content` | Alumno actualizado correctamente |
| `400 Bad Request` | El `id` de la ruta no coincide con el del body |
| `404 Not Found` | No existe un alumno con ese ID |

---

### Eliminar un alumno

```
DELETE /api/Alumnos/{id}
```

| Parámetro | Ubicación | Tipo | Descripción |
|---|---|---|---|
| `id` | ruta | `int` | ID del alumno a eliminar |

**Respuestas:**

| Código | Descripción |
|---|---|
| `204 No Content` | Alumno eliminado correctamente |
| `404 Not Found` | No existe un alumno con ese ID |

---

## Datos semilla

La base de datos se inicializa con 10 registros de ejemplo mediante `HasData` en `AlumnoContext`:

| ID | Matrícula | Nombre | Edad | Carrera |
|---|---|---|---|---|
| 1 | 2024001 | Ana López | 20 | Ingeniería |
| 2 | 2024002 | Luis Pérez | 22 | Derecho |
| 3 | 2024003 | María Gómez | 21 | Medicina |
| 4 | 2024004 | Carlos Ruiz | 23 | Arquitectura |
| 5 | 2024005 | Sofía Torres | 19 | Psicología |
| 6 | 2024006 | Jorge Díaz | 24 | Contaduría |
| 7 | 2024007 | Valeria Ramos | 20 | Informática |
| 8 | 2024008 | Miguel Sánchez | 22 | Administración |
| 9 | 2024009 | Lucía Navarro | 21 | Biología |
| 10 | 2024010 | Daniel Herrera | 23 | Economía |

---

## Swagger

En modo **Development**, la documentación interactiva de Swagger está disponible en:

```
https://localhost:5001/swagger
```

Desde allí puedes probar cada endpoint directamente en el navegador.
