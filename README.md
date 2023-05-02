# BancoAPI

Prueba de desarollo para la creacion de una API que simula un banco.
* Verion 1 - Endopoint para clientes funcionando

## Comenzando 🚀
### Pre-requisitos 📋

Tecnologias necesarias para usar el proyecto, que deben estar ya preconfiguradas en Windows 10 o superior
```
Docker Desktop - WSL2
```

```
.Net 7
```

```
Visual Studio 2022
```

```
Postman
```

### Instalación 🔧

* Clonar el repositorio
* Ejecutar el archivo de la solucion


## Despliegue 📦

* Ejecutar docker-compose desde Visual Studio
* Visualizar el estado de los contenedores

```
docker ps
```

* Copiar el archivo BancoAPI.bak al contenedor sql_server y restaurar la base
* El siguiente codigo se ejecuta desde la ubicacion del archivo BancoAPI.bank

```
docker cp ./BancoAPI.bak sql_server:/var/opt/mssql/data
```

## Construido con 🛠️

* .Net 7 Web Api
* C#
* Docker

## Autores ✒️

_Menciona a todos aquellos que ayudaron a levantar el proyecto desde sus inicios_

* **Alfredo Aguirre** - *Desarollador* 
