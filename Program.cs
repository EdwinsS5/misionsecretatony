using System;
using System.IO;

class Program
{
    static void Main()
    {
        string archivoOriginal = "C:\\tonystark\\Archivo.txt";
        string carpetaBackup = "C:\\tonystark\\Backup";
        string carpetaClasificados = "C:\\tonystark\\ArchivosClasificados";
        string carpetaProyectosSecretos = "C:\\tonystark\\ProyectosSecretos";
        string carpetaLaboratorio = "C:\\tonystark\\LaboratorioAvengers";

        while (true)
        {
            Console.WriteLine("\n----LA MISION SECRETA DE TONY STARK----");
            Console.WriteLine("1---Crear Archivo---");
            Console.WriteLine("2---Agregar Invento---");
            Console.WriteLine("3---Leer Invento Línea por Línea---");
            Console.WriteLine("4---Leer Todo el Archivo---");
            Console.WriteLine("5---Copiar Archivo a Backup---");
            Console.WriteLine("6---Mover Archivo a Clasificados---");
            Console.WriteLine("7---Crear Carpeta Proyectos Secretos---");
            Console.WriteLine("8---Eliminar Archivo---");
            Console.WriteLine("9---Listar Archivos en Laboratorio---");
            Console.WriteLine("10---Salir del programa---");
            Console.Write("Seleccione una Opcion: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    creararchivos(archivoOriginal);
                    break;
                case "2":
                    agregarinvento(archivoOriginal);
                    break;
                case "3":
                    leerinventos(archivoOriginal);
                    break;
                case "4":
                    leertodoarchivo(archivoOriginal);
                    break;
                case "5":
                    copiararchivo(archivoOriginal, carpetaBackup);
                    break;
                case "6":
                    moverarchivo(archivoOriginal, carpetaClasificados);
                    break;
                case "7":
                    crearcarpeta(carpetaProyectosSecretos);
                    break;
                case "8":
                    eliminararchivo(archivoOriginal);
                    break;
                case "9":
                    listararchivos(carpetaLaboratorio);
                    break;
                case "10":
                    Console.WriteLine("¡Hasta luego, Tony Stark!");
                    return;
                default:
                    Console.WriteLine("\nError inesperado. Hasta los genios cometemos errores. Inténtalo de nuevo.");
                    break;
            }
        }
    }
    static void creararchivos(string path)
    {
        string contenido = "Archivo del Señor Tony Stark";


        //Quisiera declararle mi amor, pero temo que mi corazón sea como un archivo .txt: lleno de líneas vacías y errores de sintaxis
        try
        {
            string folderPath = Path.GetDirectoryName(path);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine("¡Carpeta creada con exito!");
            }
            File.WriteAllText(path, contenido);
            Console.WriteLine("¡Señor el archivo se creo con exito!");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("¡Error! No tienes permisos para escribir en esta ubicación. ¡Ultron debe estar bloqueando el acceso!");
        }
        catch (Exception err)
        {
            Console.WriteLine($"¡Error inesperado! {err.Message} ¡Parece que algo salió mal, señor!");
        }
    }
    static void agregarinvento(string path)
    {
        Console.Write("Ingrese el nombre del nuevo invento: ");
        string nuevoInvento = Console.ReadLine();

        try
        {
            File.AppendAllText(path, Environment.NewLine + nuevoInvento);
            Console.WriteLine("¡Invento agregado con éxito!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("¡Error! El archivo Archivo.txt no existe. ¡Ultron debe haberlo borrado!");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("¡Error! La carpeta 'tonystark' no existe. ¡Parece que Ultron la eliminó!");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("¡Error! No tienes permisos para escribir en esta ubicación. ¡Ultron debe estar bloqueando el acceso!");
        }
        catch (Exception err)
        {
            Console.WriteLine($"¡Error inesperado! {err.Message} ¡Parece que algo salió mal, señor!");
        }
    }

    static void leerinventos(string path)
    {
        try
        {
            string[] lineas = File.ReadAllLines(path);

            Console.WriteLine("\nInventos de Tony Stark (Línea por Línea):");
            foreach (string linea in lineas)
            {
                Console.WriteLine(linea);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("¡Error! El archivo 'Archivo.txt' no existe. ¡Ultron debe haberlo borrado!");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("¡Error! La carpeta 'tonystark' no existe. ¡Parece que Ultron la eliminó!");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("¡Error! No tienes permisos para leer en esta ubicación. ¡Ultron debe estar bloqueando el acceso!");
        }
        catch (Exception err)
        {
            Console.WriteLine($"¡Error inesperado! {err.Message} ¡Parece que algo salió mal, señor!");
        }
    }

    static void leertodoarchivo(string path)
    {
        try
        {
            string contenido = File.ReadAllText(path);
            Console.WriteLine("\nInventos de Tony Stark (Todo el Archivo):");
            Console.WriteLine(contenido);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("¡Error! El archivo 'Archivo.txt' no existe. ¡Ultron debe haberlo borrado!");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("¡Error! La carpeta 'tonystark' no existe. ¡Parece que Ultron la eliminó!");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("¡Error! No tienes permisos para leer en esta ubicación. ¡Ultron debe estar bloqueando el acceso!");
        }
        catch (Exception err)
        {
            Console.WriteLine($"¡Error inesperado! {err.Message} ¡Parece que algo salió mal, señor!");
        }
    }

    static void copiararchivo(string archivoOriginal, string carpetaBackup)
    {
        try
        {
            if (!File.Exists(archivoOriginal))
            {
                Console.WriteLine("¡Error! El archivo 'Archivo.txt' no existe. ¡Ultron debe haberlo borrado!");
                return;
            }
            
            if (!Directory.Exists(carpetaBackup))
            {
                Directory.CreateDirectory(carpetaBackup);
                Console.WriteLine("¡Carpeta de Backup creada con éxito!");
            }

            string archivoBackup = Path.Combine(carpetaBackup, "Archivo.txt");
            File.Copy(archivoOriginal, archivoBackup, true); 
            Console.WriteLine("¡Copia de seguridad creada con éxito!");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("¡Error! No tienes permisos para copiar el archivo. ¡Ultron debe estar bloqueando el acceso!");
        }
        catch (Exception err)
        {
            Console.WriteLine($"¡Error inesperado! {err.Message} ¡Parece que algo salió mal, señor!");
        }
    }

    static void moverarchivo(string archivoOriginal, string carpetaClasificados)
    {
        try
        {
            if (!File.Exists(archivoOriginal))
            {
                Console.WriteLine("¡Error! El archivo 'Archivo.txt' no existe. ¡Ultron debe haberlo borrado!");
                return;
            }

            if (!Directory.Exists(carpetaClasificados))
            {
                Directory.CreateDirectory(carpetaClasificados);
                Console.WriteLine("¡Carpeta de Archivos Clasificados creada con éxito!");
            }

            string archivoClasificado = Path.Combine(carpetaClasificados, "Archivo.txt");
            File.Move(archivoOriginal, archivoClasificado);
            Console.WriteLine("¡Archivo movido a Archivos Clasificados con éxito!");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("¡Error! No tienes permisos para mover el archivo. ¡Ultron debe estar bloqueando el acceso!");
        }
        catch (Exception err)
        {
            Console.WriteLine($"¡Error inesperado! {err.Message} ¡Parece que algo salió mal, señor!");
        }
    }

    static void crearcarpeta(string carpetaProyectosSecretos)
    {
        try
        {
            if (!Directory.Exists(carpetaProyectosSecretos))
            {
                Directory.CreateDirectory(carpetaProyectosSecretos);
                Console.WriteLine("¡Carpeta de Proyectos Secretos creada con éxito!");
            }
            else
            {
                Console.WriteLine("¡La carpeta de Proyectos Secretos ya existe!");
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("¡Error! No tienes permisos para crear la carpeta. ¡Ultron debe estar bloqueando el acceso!");
        }
        catch (Exception err)
        {
            Console.WriteLine($"¡Error inesperado! {err.Message} ¡Parece que algo salió mal, señor!");
        }
    }

    static void eliminararchivo(string archivoOriginal)
    {
        try
        {
            if (!File.Exists(archivoOriginal))
            {
                Console.WriteLine("¡Error! El archivo 'Archivo.txt' no existe. ¡Ultron debe haberlo borrado!");
                return;
            }

            File.Delete(archivoOriginal);
            Console.WriteLine("¡Archivo eliminado con éxito!");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("¡Error! No tienes permisos para eliminar el archivo. ¡Ultron debe estar bloqueando el acceso!");
        }
        catch (Exception err)
        {
            Console.WriteLine($"¡Error inesperado! {err.Message} ¡Parece que algo salió mal, señor!");
        }
    }

    static void listararchivos(string carpetaLaboratorio)
    {
        try
        {
            if (!Directory.Exists(carpetaLaboratorio))
            {
                Directory.CreateDirectory(carpetaLaboratorio);
                Console.WriteLine("¡Carpeta 'LaboratorioAvengers' creada con éxito!");
            }

            string[] archivos = Directory.GetFiles(carpetaLaboratorio);
            Console.WriteLine("\nArchivos en el Laboratorio de Avengers:");
            foreach (string archivo in archivos)
            {
                Console.WriteLine(Path.GetFileName(archivo));
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("¡Error! No tienes permisos para listar los archivos. ¡Ultron debe estar bloqueando el acceso!");
        }
        catch (Exception err)
        {
            Console.WriteLine($"¡Error inesperado! {err.Message} ¡Parece que algo salió mal, señor!");
        }
    }
}




