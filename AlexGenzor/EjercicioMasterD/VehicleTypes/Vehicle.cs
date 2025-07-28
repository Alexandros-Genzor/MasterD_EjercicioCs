using System.ComponentModel;

namespace AlexGenzor.EjercicioMasterD.VehicleTypes;

public enum EngineTypes { Petrol, Diesel, Hybrid, Electric }
public enum TractionTypes { AllWheels, FrontWheels, RearWheels }

public abstract class Vehicle
{
    #region PROPERTIES
    public string Model { get; set; }
    public float HorsePower { get; set; }
    public string PlateNumber { get; set; }
    public int WheelCount { get; set; }
    public EngineTypes EngineType { get; set; }
    public string GearShiftType { get; set; }
    public TractionTypes TractionType { get; set; }
    
    #endregion
    
    #region METHODS & FUNCTIONS

    public virtual void AssignModel(string model)
    {
        Console.Write("Introduce el modelo del vehículo: ");
        Model = Console.ReadLine();
        
    }

    public virtual void AssignHp()
    {
        bool isValid = false;
        float value;

        while (!isValid)
        {
            Console.Write("¿Cuàntos caballos de potencia tiene el vehículo?: ");
            if (float.TryParse(Console.ReadLine(), out value))
            {
                HorsePower = value;
                isValid = true;
                
            }
            else
                Console.WriteLine("Valor introducido no válido. ");
            
        }

    }

    /// <summary>
    /// Establishes the vehicle's wheel count.
    /// <remarks>
    /// Default value is 4 wheels. In case of setting a different default value or range of values,
    /// override this function.
    /// </remarks>
    /// </summary>
    public virtual void AssignWheelCount()
    {
        WheelCount = 4;
        
    }
    
    public abstract void AssignEngineType();

    public virtual void AssignShifterType()
    {
        NoValidShifter:
        
        Console.Write("¿El vehículo tiene un cambio de marchas (1) Automático o (2) Manual?: ");
        switch (Console.ReadLine())
        {
            case "Automatico":
            case "automatico":
            case "Auto":
            case "auto":
            case "1":
                GearShiftType = "Automatico";

                break;
            
            case "Manual":
            case "manual":
            case "2":
                GearShiftType = "Manual";

                break;
            
            default:
                Console.WriteLine("Cambio de marchas introducido no válido.");
                goto NoValidShifter;
            
        }
        
    }

    public virtual void AssignTractionType()
    {
        NoValidTraction:
        
        Console.Write("¿El vehículo es de (1) tracción delantera, (2) tracción trasera o (3) tracción total / 4x4?: ");

        switch (Console.ReadLine())
        {
            case "Delantera":
            case "delantera":
            case "1":
                TractionType = TractionTypes.FrontWheels;

                break;
            
            case "Trasera":
            case "trasera":
            case "2":
                TractionType = TractionTypes.RearWheels;

                break;
            
            case "Total":
            case "total":
            case "3":
                TractionType = TractionTypes.AllWheels;
                
                break;
            
            default:
                Console.WriteLine("Tracción del vehículo introducida no válida. ");
                goto NoValidTraction;
            
        }
        
    }
    
    public override string ToString()
    {
        return $"Model: {Model} - {PlateNumber}, {WheelCount} wheels, traction on {TractionType}" +
               $"Engine type: {EngineType}, {HorsePower} HP. Gear shift type: {GearShiftType}";
        
    }

    #endregion

}