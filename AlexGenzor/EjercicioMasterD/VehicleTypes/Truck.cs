using System.Numerics;
using AlexGenzor.EjercicioMasterD.Utils;

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
        AssignModel();
        AssignHp();
        base.PlateNumber = AssignPlateNumber();
        AssignWheelCount();
        AssignEngineType();
        AssignShifterType();
        AssignTractionType();
        
        SetTrailers();
        SetCabType();
        SetIsSpecialVehicle();
        
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
        
        Trailers = (MyUtils.DecipherAnswer(prompt) ? _trailerVariations[WheelCount] : "sin remolques");

    }

    public void SetCabType()
    {
        NoValidCabType:
        
        Console.Write("¿El camión es de (1) cabina plana o (2) cabina ancha?: ");

        switch (Console.ReadLine().ToLower())
        {
            case "1": 
            case "plana":
            case "cabina plana":
            case "flat":
                this.CabType = CabTypes.FlatFront;
                
                break;
            
            case "2":
            case "ancha":
            case "cabina ancha":
            case "wide":
                this.CabType = CabTypes.WideCab;
                
                break;
            
            default:
                Console.WriteLine("Valor introducido no válido. ");
                goto NoValidCabType;
            
        }
        
        Console.WriteLine();
        
    }

    public void SetIsSpecialVehicle()
    {
        this.IsSpecialVehicle = MyUtils.DecipherAnswer("¿Es el camión un vehículo especial?");
        Console.WriteLine();

    }
    
    #region OVERRIDEABLES
    public override void AssignWheelCount()
    {
        if (WheelCount != 0)
            // in case AssignWheelCount() goes after SetTrailers()
            return;
        
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
        
        Console.WriteLine();

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
        // return $"";
        
        /*return $"Modelo: {Model} - {PlateNumber}, {WheelCount} ruedas, tracción {TractionType}" +
               $"Tipo de motor: {EngineType}, {HorsePower} Caballos. Cambio de marchas: {GearShiftType}";*/
        
        return $"{PlateNumber} - Camión modelo: {Model} con cabina {CabType}. Tipo de motor: {EngineType} " +
               $"de {HorsePower} Caballos con cambio de marchas {GearShiftType}. " +
               $"{WheelCount} ruedas, tracción {TractionType} y {Trailers}. " +
               $"Vehículo especial: {(IsSpecialVehicle ? "si" : "no")}. ";

    }

    #endregion
    
}