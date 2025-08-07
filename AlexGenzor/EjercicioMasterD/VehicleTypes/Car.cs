using AlexGenzor.EjercicioMasterD.Utils;

namespace AlexGenzor.EjercicioMasterD.VehicleTypes;

public class Car : Vehicle
{
    #region PROPERTIES
    public int DoorCount { get; set; }
    public bool IsSpecialVehicle { get; set; }
    public bool AreWindowsTinted { get; set; }
    public bool IsPublicTransportCar { get; set; }
    
    #endregion
    
    #region CONSTRUCTORS
    
    public Car()
    {
        // base.Model = "Generic";
        // base.HorsePower = 70;
        // base.PlateNumber = AssignPlateNumber();
        // base.WheelCount = 4;
        // base.EngineType = EngineTypes.Petrol;
        // base.GearShiftType = "Manual";
        // base.TractionType = TractionTypes.RearWheels;
        //
        // this.DoorCount = 3;
        // this.IsSpecialVehicle = false;
        // this.AreWindowsTinted = false;
        // this.IsPublicTransportCar = false;

        Console.WriteLine("Configurador de coches:\n");

        
        AssignModel();
        AssignHp();
        base.PlateNumber = AssignPlateNumber();
        AssignWheelCount();
        AssignEngineType();
        AssignShifterType();
        AssignTractionType();
        
        AssignDoorCount();
        SetIsSpecialVehicle();
        SetTintedWindows();
        SetIsPublicTransportCar();
        

    }
    
    #endregion

    private void AssignDoorCount()
    {
        InvalidDoorCount:
        
        Console.Write("¿El coche es de 3 o 5 puertas?: ");

        if (int.TryParse(Console.ReadLine(), out var doorCount))
        {
            if (doorCount == 3 || doorCount == 5)
                this.DoorCount = doorCount;

            else
            {
                Console.WriteLine("Número de puertas inválido. ");
                goto InvalidDoorCount;
                
            }
            
        }
        else
        {
            Console.WriteLine("Valor introducido inválido. ");
            goto InvalidDoorCount;
            
        }
        
    }

    private void SetIsSpecialVehicle()
    {
        IsSpecialVehicle = MyUtils.DecipherAnswer("¿Es un vehículo especial?");
        Console.WriteLine();

    }

    private void SetTintedWindows()
    {
        AreWindowsTinted = MyUtils.DecipherAnswer("¿Tiene las lunas traseras tintadas?");
        Console.WriteLine();

    }

    private void SetIsPublicTransportCar()
    {
        IsPublicTransportCar = MyUtils.DecipherAnswer("¿Es un vehículo de servicio público?");
        Console.WriteLine();

    }

    #region OVERRIDEABLES

    public override void AssignTractionType()
    {
        NoValidTraction:
        
        Console.Write("¿El vehículo es de (1) tracción Delantera, (2) tracción Trasera o (3) tracción Total / 4x4?: ");

        switch (Console.ReadLine().ToLower())
        {
            case "traccion delantera":
            case "delantera":
            case "1":
                TractionType = TractionTypes.FrontWheels;

                break;
            
            case "traccion trasera":
            case "trasera":
            case "2":
                TractionType = TractionTypes.RearWheels;

                break;
            
            case "traccion total":
            case "total":
            case "4x4":
            case "3":
                TractionType = TractionTypes.AllWheels;
                
                break;
            
            default:
                Console.WriteLine("Tracción del vehículo introducida no válida. ");
                goto NoValidTraction;
            
        }
        
        Console.WriteLine();
        
    }

    public override string ToString()
    {
        return $"{PlateNumber} - Coche modelo: {Model}, {DoorCount} puertas con lunas traseras " +
               $"{(AreWindowsTinted ? "tintadas" : "sin tintar")}. Tipo de motor: {EngineType} " +
               $"de {HorsePower} Caballos con cambio de marchas {GearShiftType}. " +
               $"{WheelCount} ruedas, tracción {TractionType}. " +
               $"Vehículo especial: {(IsSpecialVehicle ? "si" : "no")}. " +
               $"Vehículo de transporte público: {(IsPublicTransportCar ? "si" : "no")}. ";

    }
    
    #endregion
    
}