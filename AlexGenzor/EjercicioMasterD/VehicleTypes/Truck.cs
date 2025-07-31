using System.Numerics;
using AlexGenzor.EjercicioMasterD.Other;

namespace AlexGenzor.EjercicioMasterD.VehicleTypes;

public class Truck : Vehicle
{
    public enum CabTypes { FlatFront, WideCab }
    
    // public enum TrailerTypes { SemiTrailer, Trailer }
    
    #region FIELDS
    private readonly Dictionary<int, string> _trailerVariations = new Dictionary<int, string>()
    {
        {4, "un semirremolque"},
        {6, "un remolque"},
        {8, "un semirremolque y un remolque"},
        {10, "2 remolques"},
        {12, "3 remolques"}
        
    };
    
    #endregion
    
    #region PROPERTIES
    public CabTypes CabType { get; set; }
    // public Trailer Trailer { get; set; }
    // public TrailerTypes[] Trailers { get; set; }
    public string Trailers { get; set; }
    public bool IsSpecialVehicle { get; set; }
    
    #endregion
    
    #region CONSTRUCTOR

    public Truck()
    {
        
        
    }
    
    #endregion

    public void SetTrailers()
    {
        // in case SetTrailer() call goes before AssignWheelCount() in the constructor
        if (WheelCount == 0)
        {
            Console.WriteLine("No se puede asignar un remolque sin saber el número de ruedas. ");
            AssignWheelCount();
            
            Console.WriteLine("Número de ruedas asignadas. Resumiendo con la asignación de remolques...\n");
            
        }

        var prompt = $"El camión tiene {WheelCount} ruedas, haciendo que sea elegible para " +
                     $"llevar {_trailerVariations[WheelCount]}. ¿Desea añadirlo/s al camión?";
        
        Trailers = (MyUtils.DecipherAnswer(prompt) ? _trailerVariations[WheelCount] : "");

    }

    public void SetIsSpecialVehicle()
    {
        this.IsSpecialVehicle = MyUtils.DecipherAnswer("¿Es el camión un vehículo especial?");

    }
    
    #region OVERRIDEABLES
    public override void AssignWheelCount()
    {
        NoValidWheelCount:
        
        Console.Write("¿Cuántas ruedas tiene el camión? (min 4, max 12): ");

        if (int.TryParse(Console.ReadLine(), out var value))
        {
            if (value >= 4 && value <= 12 && value % 2 == 0) 
                base.WheelCount = value;

            else
            {
                Console.WriteLine("El número de ruedas introducido no es válido. ");
                goto NoValidWheelCount;
                
            }
            
        }
        else
        {
            Console.WriteLine("El valor introducido no es válido. ");
            goto NoValidWheelCount;
            
        }

    }

    public override void AssignEngineType()
    {
        NoValidEngineType:
        
        Console.Write("¿Es unn camíón de (1) Gasolina o (2) Diesel?: ");

        switch (Console.ReadLine().ToLower())
        {
            case "1":
            case "gasolina":
                EngineType = EngineTypes.Petrol;

                break;
            
            case "2":
            case "diesel":
                EngineType = EngineTypes.Diesel;
                
                break;
            
            default:
                Console.WriteLine("La opción seleccionada no es válida. ");
                goto NoValidEngineType;
            
        }
        
        Console.WriteLine();
        
    }

    public override string ToString()
    {
        return $"";

    }

    #endregion
    
}