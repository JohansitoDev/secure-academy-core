# SecureAcademy Core 🏫🛡️

Sistema de Gestión Escolar robusto y de alta seguridad diseñado bajo el enfoque de **Clean Architecture** (Arquitectura Limpia) empleando **.NET 9.0**, **Blazor Web App** para el frontend interactivo y **PostgreSQL en Google Cloud (Cloud SQL)** para la persistencia de datos.

Este proyecto ha sido desarrollado siguiendo estrictamente las directrices del **OWASP Top 10** para mitigar riesgos críticos de seguridad en entornos académicos empresariales.

---

## 🏗️ Arquitectura del Sistema

El proyecto implementa una arquitectura desacoplada en 4 capas principales para asegurar la inversión de dependencias:

* **Domain (Núcleo):** Contiene las entidades puras del negocio (`Estudiante`, `Profesor`, `Calificacion`) libres de dependencias de frameworks externos. Implementa identificadores globales únicos (`Guid`) para mitigar la enumeración de recursos (OWASP A01).
* **Application (Casos de Uso):** Orquesta la lógica del negocio escolar y define las interfaces de abstracción (repositorios).
* **Infrastructure (Infraestructura):** Gestiona el acceso de datos parametrizado mediante **Entity Framework Core** y el proveedor **Npgsql** para PostgreSQL Cloud, neutralizando ataques de inyección SQL (OWASP A03).
* **BlazorApp (Presentación):** Interfaz web de usuario moderna con diseño claro y profesional. Implementa layouts dinámicos basados en roles y protección nativa contra Cross-Site Scripting (XSS) y CSRF.

---

## 🔒 Mitigación OWASP Top 10 Implementada

* **A01:2021-Control de Acceso Vulnerable:** Uso de GUIDs aleatorios no secuenciales en todas las entidades para evitar ataques de manipulación directa de identificadores en rutas o peticiones.
* **A02:2021-Fallos Criptográficos:** Configuración forzada de cifrado en tránsito mediante cadenas de conexión seguras (`SSL Mode=Require`) hacia Cloud SQL.
* **A03:2021-Inyección:** Consultas de base de datos 100% parametrizadas a través del ORM, evitando por completo el uso de SQL en crudo concatenado.
* **A05:2021-Configuración de Seguridad Incorrecta:** Ciclo de DevSecOps inicializado mediante hooks automatizados de **Husky** para pre-commits, previniendo la fuga accidental de credenciales o secretos en el repositorio.

---

## 🚀 Requisitos e Instalación Local

### Prerrequisitos
* .NET SDK 9.0 o superior
* Visual Studio Code (con extensiones de C# activas)
* Instancia de PostgreSQL activa (Local o Google Cloud SQL)

### Pasos para Inicializar

1. Clonar el repositorio:
   ```bash
   git clone [https://github.com/JohansitoDev/secure-academy-core.git](https://github.com/tu-usuario/secure-academy-core.git)
   cd secure-academy-core