using System.Reflection;
using AlexGenzor.EjercicioMasterD.Utils;
using AlexGenzor.EjercicioMasterD.VehicleTypes;

namespace AlexGenzor.EjercicioMasterD;

public class CLIManager
{
    private Dictionary<string, Vehicle> _vehicles = new Dictionary<string, Vehicle>();
    
    private enum VehicleTypes { Car, Motorbike, Truck }

    public CLIManager()
    {
        SelectionMenu();
        // DeleteVehicle();
        
    }
    
    #region MENUS
    private void SelectionMenu()
    {
        bool doLeave = false;

        do
        {
            Console.Clear();
            
            Console.WriteLine("(1) Crear Vehículo.\n(2) Mostrar Vehículos.\n(3) Eliminar Vehículo.\n(4) Salir.\n");
            Console.Write("Seleccione una acción: ");

            switch (Console.ReadLine().ToLower())
            {
                case "1":
                case "crear":
                    CreateVehicleMenu();

                    break;
                
                case "2":
                case "mostrar":
                    ListVehiclesMenu();
                    // view list
                
                    break;  
                
                case "3":
                case "eliminar":
                    DeleteVehicleMenu();
                    // delete vehicle

                    break;
                
                case "4":
                case "salir":
                    // exit
                    doLeave = true;

                    break;
                
                default:
                    Console.WriteLine("Opción seleccionada no es válida. Pulse enter para continuar.");
                    
                    break;
                    
            }

        } while (!doLeave);

    }

    private void CreateVehicleMenu()
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
                    CreateVehicle(VehicleTypes.Car);

                    break;

                case "2":
                case "moto":
                    // create motorbike
                    CreateVehicle(VehicleTypes.Motorbike);


                    break;

                case "3":
                case "camion":
                    // create truck
                    CreateVehicle(VehicleTypes.Truck);


                    break;

                case "4":
                case "volver":
                    // return to previous menu
                    doLeave = true;

                    break;

                default:
                    Console.WriteLine("Opción seleccionada no es válida. Pulse enter para continuar.");
                    Console.ReadLine();

                    break;

            }
            
        } while (!doLeave);

    }

    private void ListVehiclesMenu()
    {
        bool doLeave = false;

        do
        {
            Console.Clear();
            
            Console.WriteLine("(1) Coches.\n(2) Motos.\n(3) Camiones.\n(4) Todos.\n(5) Volver.\n");
            Console.Write("Escoge una opción de visualización: ");

            switch (Console.ReadLine().ToLower())
            {
                case "1":
                case "coches":
                    // list all cars
                    ListVehiclesByClass(VehicleTypes.Car);

                    break;
                
                case "2":
                case "motos":
                    // list all motorbikes
                    ListVehiclesByClass(VehicleTypes.Motorbike);

                    break;
                
                case "3":
                case "camiones":
                    // list all trucks
                    ListVehiclesByClass(VehicleTypes.Truck);
                    
                    break;
                
                case "4":
                case "todos":
                    Console.Clear();
                    
                    if (_vehicles.Count == 0)
                        Console.WriteLine("¡Oops! No hay vehículos en la lista. Añade un vehículo. ");

                    else
                        foreach (var vehicle in _vehicles)
                        {
                            Console.WriteLine(vehicle.Value.ToString());
                        
                        }
                    
                    Console.Write("\nPulsa enter para continuar.");
                    Console.ReadLine();
                    
                    break;
                
                case "5":
                case "volver":
                    // return to previous menu
                    doLeave = true;

                    break;
                
                default:
                    Console.WriteLine("Opción seleccionada no es válida. Pulse enter para continuar.");
                    Console.ReadLine();
                    
                    break;
                
            }

        } while (!doLeave);

    }

    private void DeleteVehicleMenu()
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
                    if (ListVehiclesByClass(VehicleTypes.Car, true))
                        DeleteVehicle();
                    
                    break;
                
                case "2":
                case "moto":
                    if (ListVehiclesByClass(VehicleTypes.Motorbike, true))
                        DeleteVehicle();
                    
                    break;
                
                case "3":
                case "camion":
                    if (ListVehiclesByClass(VehicleTypes.Truck, true))
                        DeleteVehicle();
                    
                    break;
                
                case "4":
                case "volver":
                    
                    
                    doLeave = true;
                    break;
                
                default:
                    Console.WriteLine("Opción seleccionada no es válida.");
                    Console.ReadLine();
                    
                    break;
                
            }
            
        } while (!doLeave);
        
    }
    
    #endregion

    private bool ListVehiclesByClass(VehicleTypes type, bool deleteMode = false)
    {
        Console.Clear();
        bool hasVeiclesOfClass = false;
        
        foreach (var vehicle in _vehicles)
        {
            if (vehicle.Value.GetType().Name.Equals(type.ToString()))
            {
                Console.WriteLine(vehicle.Value.ToString());
                hasVeiclesOfClass = true;

            }

        }

        if (!hasVeiclesOfClass)
        {
            Console.WriteLine("¡Oops! Aún no hay vehículos de esta categoría registrados. ");
            
            if (deleteMode)
                Console.WriteLine("Proceso de eliminación de vehículos anulado. ");

        }

        Console.Write("\nPulse enter para continuar.");
        Console.ReadLine();
        
        return hasVeiclesOfClass;

    }

    private void CreateVehicle(VehicleTypes type)
    {
        Vehicle newVehicle = null;
        Console.Clear();

        do
        {
            switch (type)
            {
                case VehicleTypes.Car:
                    newVehicle = new Car();

                    break;

                case VehicleTypes.Motorbike:
                    newVehicle = new Motorbike();

                    break;

                case VehicleTypes.Truck:
                    newVehicle = new Truck();

                    break;

            }
            
            Console.WriteLine();

        } while (!MyUtils.DecipherAnswer("¿Esta contento con la información del vehículo?"));
        
        this._vehicles.Add(newVehicle.PlateNumber, newVehicle);

    }

    private void DeleteVehicle()
    {
        bool doLeave = false;

        do
        {
            Console.Write("\nIntroduzca la matrícula del vehículo a eliminar, o escriba 'volver' para salir: ");
            var plate = Console.ReadLine().ToUpper();

            if (plate == "VOLVER")
                doLeave = true;

            if (_vehicles.ContainsKey(plate))
            {
                if (MyUtils.DecipherAnswer($"Vehículo encontrado. " +
                                           $"¿Desea eliminar el vehículo con matrícula {plate}?"))
                {
                    _vehicles.Remove(plate);
                    Console.WriteLine("Vehículo eliminado.");

                    Console.ReadLine();
                    
                    doLeave = true;
                    
                } 
                else
                    Console.WriteLine("Vehículo no eliminado.");

            }
            else
                Console.WriteLine($"Vehículo con matrícula {plate} no existe. Introduce una matrícula válida.");
            
        } while (!doLeave);

    }

}