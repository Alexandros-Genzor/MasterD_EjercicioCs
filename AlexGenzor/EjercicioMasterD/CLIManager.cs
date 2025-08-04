using System.Reflection;
using AlexGenzor.EjercicioMasterD.VehicleTypes;

namespace AlexGenzor.EjercicioMasterD;

public class CLIManager
{
    public static Dictionary<string, Vehicle> Vehicles = new Dictionary<string, Vehicle>();
    
    public static void SelectionMenu()
    {
        bool doLeave = false;

        do
        {
            Console.WriteLine("(1) Crear Vehículo.\n(2)Mostrar Vehículos.\n(3)Eliminar Vehículo.\n(4)Salir.\n");
            Console.Write("Seleccione una acción: ");

            switch (Console.ReadLine().ToLower())
            {
                case "1":
                case "crear":
                    CreateVehicleMenu();

                    break;
                
                case "2":
                case "mostrar":
                    // view list
                
                    break;  
                
                case "3":
                case "eliminar":
                    // delete vehicle

                    break;
                
                case "4":
                case "salir":
                    // exit
                    doLeave = true;

                    break;
                
                default:
                    Console.WriteLine("Opción seleccionada no es válida.\n");
                    
                    break;
                    
            }

        } while (!doLeave);

    }

    public static void CreateVehicleMenu()
    {
        bool doLeave = false;

        do
        {
            Console.Clear();

            Console.WriteLine("(1) Crear coche.\n(2) Crear Moto.\n(3) Crear Camión.\n(4) Volver.\n");
            Console.Write("¿Qué vehículo desea crear?: ");

            switch (Console.ReadLine().ToLower())
            {
                case "1":
                case "coche":
                    // create car

                    break;

                case "2":
                case "moto":
                    // create motorbike

                    break;

                case "3":
                case "camion":
                    // create truck

                    break;

                case "4":
                case "volver":
                    // return to previous menu
                    doLeave = true;

                    break;

                default:
                    Console.WriteLine("Opción seleccionada no es válida.\n");

                    break;

            }
            
        } while (!doLeave);

    }

    public static void ListVehiclesMenu()
    {
        bool doLeave = false;

        do
        {
            Console.Clear();
            
            Console.WriteLine("(1) Coches.\n(2) Motos.\n(3) Camiones.\n(4) Todos.\n(5) Volver.");
            Console.Write("Escoge una opción de visualización: ");

            switch (Console.ReadLine().ToLower())
            {
                case "1":
                case "coches":
                    // list all cars

                    break;
                
                case "2":
                case "motos":
                    // list all motorbikes

                    break;
                
                case "3":
                case "camiones":
                    // list all trucks
                    
                    break;
                
                case "4":
                case "todos":
                    // list all vehicles
                    
                    break;
                
                case "5":
                case "volver":
                    // return to previous menu
                    doLeave = true;

                    break;
                
                default:
                    Console.WriteLine("Opción seleccionada no es válida.\n");
                    
                    break;
                
            }
            
        } while (!doLeave);
        
    }

    public static void DeleteVehicleMenu()
    {
        bool doLeave = false;

        do
        {
            Console.Clear();
            
            Console.WriteLine("(1) Coche.\n(2) Moto.\n(3) Camión.\n(4) Volver.\n");
            Console.Write("Seleccione el tipo de vehículo que desea eliminar: ");

            switch (Console.ReadLine().ToLower())
            {
                case "1":
                case "coche":
                    ListVehiclesByClass("Car");
                    
                    break;
                
                case "2":
                case "moto":
                    ListVehiclesByClass("Motorbike");
                    
                    break;
                
                case "3":
                case "camion":
                    ListVehiclesByClass("Truck");
                    
                    break;
                
                case "4":
                case "volver":
                    
                    
                    doLeave = true;
                    break;
                
                default:
                    Console.WriteLine("Opción seleccionada no es válida.\n");
                    
                    break;
                
            }
            
        } while (!doLeave);
        
    }

    private static void ListVehiclesByClass(string className)
    {
        Console.Clear();
        
        foreach (var vehicle in Vehicles)
        {
            if (vehicle.Value.GetType().Name.Equals(className))
                Console.WriteLine(vehicle.Value.ToString());
            
        }
        
    }

}