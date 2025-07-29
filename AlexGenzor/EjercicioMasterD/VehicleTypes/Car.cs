using AlexGenzor.EjercicioMasterD.Other;

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

        AssignModel();
        AssignHp();
        AssignPlateNumber();
        AssignWheelCount();
        AssignEngineType();
        AssignShifterType();
        AssignTractionType();
        
        AssignDoorCount();
        AssignIsSpecialVehicle();
        AssignAreWindowsTinted();
        AssignIsPublicTransportCar();
        

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

    private void AssignIsSpecialVehicle()
    {
        IsSpecialVehicle = MyUtils.DecipherAnswer("¿Es un vehículo especial?");

    }

    private void AssignAreWindowsTinted()
    {
        AreWindowsTinted = MyUtils.DecipherAnswer("¿Tiene las lunas traseras tintadas?");

    }

    private void AssignIsPublicTransportCar()
    {
        IsPublicTransportCar = MyUtils.DecipherAnswer("¿Es un vehículo de servicio público?");

    }

    public override string ToString()
    {
        return base.ToString();
        
    }
    
}