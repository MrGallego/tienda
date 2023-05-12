#tienda

#Requisitos: contar con Postman o un cliente para consumir peticiones, Visual studio para ejecutar el proyecto y sql server para cargar el proyecto.
#El primer paso es crear una base de datos en sql server llamada "Tienda"
#Para usar la aplicación tienda, el primer paso es descargar el proyecto o bien realizar la clonacion del mismo.
#para clonar el proyecto puede seguir la instrucción que indica GitHub
#En la parte principal en el boton code cuenta con las opciones locales para clonar el repositorio
#Luego de haber clonado el proyecto, inicie y verifique que este completo segun el repositorio en github
#El primer paso es verificar el archivo appsettings.json que contiene la cadena de conexión, es importante realizar el respectivo cambio según su servidor corresponda.
#Luego de comprobar es servidor y haber realizado el cambio de conexión, posteriormente puede continuar con la migración de tablas hacia la base de datos.
#para iniciar la migración, se debe ejecutar en la consola de administrador de paquetes de visual studio el siguiente comando
#escribir el comando Add-Migration InitialCreate luego ejecutar el comando Update-Database
#con esto ya queda configurado el proyecto para dar inicio al uso de sus endpoints.

