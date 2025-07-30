using AlexGenzor.EjercicioMasterD.Other;

namespace AlexGenzor.EjercicioMasterD.VehicleTypes;

public class Motorbike : Vehicle
{
    #region PROPERTIES
    public bool HasSidecar { get; set; }
    
    #endregion
    
    #region CONSTRUCTOR
    public Motorbike()
    {
        AssignModel();
        AssignHp();
        AssignPlateNumber();
        AssignWheelCount();
        AssignEngineType();
        AssignShifterType();
        
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
        
        Console.Write("¿Es una motocicleta de (1) Gasolina o (2) Eléctrica?: ");

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
        return $"";

    }

    #endregion
    
}