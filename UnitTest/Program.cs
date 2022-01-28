using UnitAppLibrary;
namespace Unit.AppProgram
{
    public class UnitAppProgram
    {
        public static void Main()
        {
            var unitApp = new UnitAppLogic();
            bool estado = true;
            while (estado)
            {
                Console.WriteLine("Por favor elija una opción");
                Console.WriteLine("Elija '1' para continuar y '2' para cerrar el programa, cualquier otra opción sera invalidada.");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese el nombre del archivo: ");
                        string? archivo = Console.ReadLine();
                        unitApp.ReadJSON(archivo);
                        break;
                    case 2:
                        estado = false;
                        break;
                    default:
                        Console.WriteLine("Opción invalida, intente de nuevo");
                        break;
                };

            }
        }
    }
}