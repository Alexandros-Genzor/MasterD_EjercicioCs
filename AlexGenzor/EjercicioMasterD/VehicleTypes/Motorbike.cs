using AlexGenzor.EjercicioMasterD.Utils;

namespace AlexGenzor.EjercicioMasterD.VehicleTypes;

public class Motorbike : Vehicle
{
    #region PROPERTIES
    public bool HasSidecar { get; set; }
    
    #endregion
    
    #region CONSTRUCTOR
    public Motorbike()
    {
        Console.WriteLine("Configurador de motos:\n");
        
        AssignModel();
        AssignHp();
        base.PlateNumber = AssignPlateNumber();
        AssignWheelCount();
        AssignEngineType();
        AssignShifterType();
        AssignTractionType();
        
        AssignSidecar();
        
    }
    
    #endregion

    public void AssignSidecar()
    {
        this.HasSidecar = MyUtils.DecipherAnswer("¿La motocicleta tiene sidecar?");
        Console.WriteLine();

    }
    
    #region OVERRIDEABLES
    public override void AssignWheelCount()
    {
        NoValidWheelCount:
        
        Console.Write("¿La motocicleta tiene 2 o 3 ruedas?: ");

        switch (Console.ReadLine().ToLower())
        {
            case "2":
            case "dos":
                base.WheelCount = 2;

                break;
            
            case "3":
            case "tres":
                base.WheelCount = 3;

                break;
            
            default:
                Console.WriteLine("La opción seleccionada no es válida. ");
                goto NoValidWheelCount;
            
        }
        
        Console.WriteLine();
        
    }
    
    public override void AssignEngineType()
    {
        NoValidEngineType:
        
        Console.Write("¿La motocicleta es de (1) Gasolina o (2) Eléctrica?: ");

        switch (Console.ReadLine().ToLower())
        {
            case "1":
            case "gasolina":
                EngineType = EngineTypes.Petrol;

                break;
            
            case "2":
            case "electrico":
            case "electrica":
                EngineType = EngineTypes.Electric;
                
                break;
            
            default:
                Console.WriteLine("La opción seleccionada no es válida. ");
                goto NoValidEngineType;
            
        }
        
        Console.WriteLine();
        
    }

    public override string ToString()
    {
        return $"{PlateNumber} - Motocicleta modelo: {Model}. Tipo de motor: {EngineTypeDict[EngineType]} " +
               $"de {HorsePower} Caballos con cambio de marchas {GearShiftType}. " +
               $"{WheelCount} ruedas {(HasSidecar ? "con" : "sin")} sidecar, " +
               $"tracción {TractionTypeDict[TractionType]}. ";

    }

    #endregion
    
}