# Sistema de Gestión de Peluquería (PeluSystem)

Sistema de escritorio desarrollado en C# .NET (Windows Forms) para la administración integral de una peluquería. Este proyecto destaca por su implementación de una **Arquitectura en Capas (N-Tier)**, separando estrictamente la lógica de negocio, el acceso a datos y la interfaz de usuario.

Características Principales
* **Gestión de Usuarios:** ABM (Alta, Baja, Modificación) completo con roles (Administrador, Empleado, Peluquero).
* **Seguridad:** Implementación de hashing **MD5** para el resguardo seguro de contraseñas.
* **Gestión de Clientes y Servicios:** Administración eficiente de la base de datos de clientes y catálogo de servicios.
* **Interfaz MDI:** Navegación fluida y organizada mediante contenedores MDI (Multiple Document Interface).
* **Patrones de Diseño:** Uso de **Repository Pattern** e inyección de dependencias a través de interfaces.

Arquitectura del Proyecto
La solución está estructurada modularmente para asegurar escalabilidad y mantenimiento:

1.  **DOM (Domain):** Entidades del dominio (`Cliente`, `Usuario`, `Servicio`). Clases POCO puras.
2.  **ABS (Abstracciones):** Interfaces (`IClienteRepositorio`, `IUsuarioRepositorio`) para desacoplar la lógica de la implementación de datos.
3.  **REPO (Repositorios):** Capa de acceso a datos utilizando **ADO.NET** puro (`SqlCommand`, `SqlDataReader`) para un control total de las consultas SQL.
4.  **APP (Aplicación):** Lógica de negocio que orquesta las operaciones entre la UI y los datos.
5.  **SERV (Servicios):** Utilidades transversales como la encriptación (`Encriptar.cs`).
6.  **CONTEXT:** Manejo centralizado de la conexión a SQL Server.
7.  **PeluSystem (UI):** Capa de presentación en Windows Forms.

Tecnologías
* **Lenguaje:** C#
* **Framework:** .NET Framework 4.8
* **Base de Datos:** SQL Server
* **Herramientas:** Visual Studio, Git

Instalación y Uso
1.  Clonar el repositorio.
2.  Asegurarse de tener una instancia de SQL Server local.
3.  Configurar la cadena de conexión en `CONTEXT/dalSQLServer.cs` si es necesario (por defecto apunta a `Local`).
4.  Compilar y ejecutar la solución desde Visual Studio.


Desarrollado por Bruno Ulric 

Hair Salon Management System (PeluSystem)

Desktop application developed in C# .NET (Windows Forms) for the comprehensive management of a hair salon. This project stands out for its implementation of an N-Tier Architecture, strictly separating business logic, data access, and user interface.

Key Features
* **User Management:** Full CRUD operations with role-based access (Admin, Employee, Hairdresser).
* **Security:** Implementation of **MD5** hashing for secure password storage.
* **Client & Service Management:** Efficient administration of the client database and service catalog.
* **MDI Interface:** Smooth navigation using Multiple Document Interface (MDI) containers.
* **Design Patterns:** Utilization of the **Repository Pattern** and interface-based dependency injection.

Project Architecture
The solution is modularly structured to ensure scalability and maintainability:

1.  **DOM (Domain):** Domain entities (`Cliente`, `Usuario`, `Servicio`). Pure POCO classes.
2.  **ABS (Abstractions):** Interfaces (`IClienteRepositorio`, `IUsuarioRepositorio`) to decouple logic from data implementation.
3.  **REPO (Repositories):** Data access layer using pure **ADO.NET** (`SqlCommand`, `SqlDataReader`) for full control over SQL queries.
4.  **APP (Application):** Business logic layer that orchestrates operations between UI and data.
5.  **SERV (Services):** Cross-cutting utilities like encryption (`Encriptar.cs`).
6.  **CONTEXT:** Centralized handling of the SQL Server connection.
7.  **PeluSystem (UI):** Presentation layer in Windows Forms.

Technologies
* **Language:** C#
* **Framework:** .NET Framework 4.8
* **Database:** SQL Server
* **Tools:** Visual Studio, Git

Installation & Usage
1.  Clone the repository.
2.  Ensure you have a local SQL Server instance running.
3.  Configure the connection string in `CONTEXT/dalSQLServer.cs` if necessary (defaults to `Local`).
4.  Build and run the solution via Visual Studio.

---
Developed by Bruno Ulric
