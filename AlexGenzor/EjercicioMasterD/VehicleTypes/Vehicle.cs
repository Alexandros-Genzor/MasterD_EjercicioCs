using System.ComponentModel;

namespace AlexGenzor.EjercicioMasterD.VehicleTypes;

public enum EngineTypes { Petrol, Diesel, Hybrid, Electric }
public enum TractionTypes { AllWheels, FrontWheels, RearWheels }

public abstract class Vehicle
{
    #region PROPERTIES
    public string Model { get; set; }
    public float HorsePower { get; set; }
    public string PlateNumber { get; protected set; }
    public int WheelCount { get; set; }
    public EngineTypes EngineType { get; set; }
    // dictionary made to show a more readable value to each enum element
    /*public Dictionary<EngineTypes, string> EngineTypeDict { get; } = new Dictionary<EngineTypes, string>()
    {
        { EngineTypes.Petrol, "Gasolina"},
        { EngineTypes.Diesel, "Diesel"},
        { EngineTypes.Hybrid, "Híbrido"},
        { EngineTypes.Electric, "Eléctrico"}
    };*/

    public string GearShiftType { get; set; }
    public TractionTypes TractionType { get; set; }
    // dictionary made to show a more readable value to each enum element
    /*public Dictionary<TractionTypes, string> TractionTypeDict { get; } = new Dictionary<TractionTypes, string>()
    {
        { TractionTypes.FrontWheels, "Tracción delantera"}, 
        { TractionTypes.RearWheels, "Tracción trasera"}, 
        { TractionTypes.AllWheels, "Tracción total"}
    };*/
    
    #endregion
    
    
    #region METHODS & FUNCTIONS

    public virtual void AssignModel()
    {
        Console.Write("Introduce el modelo del vehículo: ");
        this.Model = Console.ReadLine();
        
        Console.WriteLine();
        
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
                this.HorsePower = value;
                isValid = true;
                
            }
            else
                Console.WriteLine("Valor introducido no válido. ");
            
        }
        
        Console.WriteLine();

    }

    // Default actions for car. Override for other vehicles.
    public virtual void AssignWheelCount()
    {
        WheelCount = 4;
        
    }

    // Default actions for car. Override for other vehicles.
    public virtual void AssignEngineType()
    {
        bool isValid;

        do
        {
            Console.Write("¿Es un vehículo de (1) Gasolina, (2) Diesel, (3) Híbrido o (4) Eléctrico?: ");
            isValid = true;

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
                
                case "3":
                case "hbrido":
                    EngineType = EngineTypes.Hybrid;
                    
                    break;
                
                case "4":
                case "electrico":
                    EngineType = EngineTypes.Electric;
                    
                    break;
                
                default:
                    Console.WriteLine("La opción seleccionada no es válida. ");
                    isValid = false;
                    
                    break;
                
            }

        } while (!isValid);
        
        Console.WriteLine();
        
    }

    public virtual void AssignShifterType()
    {
        NoValidShifter:
        
        Console.Write("¿El vehículo tiene un cambio de marchas (1) Automático o (2) Manual?: ");
        switch (Console.ReadLine().ToLower())
        {
            case "automatico":
            case "auto":
            case "1":
                GearShiftType = "Automatico";

                break;
            
            case "manual":
            case "2":
                GearShiftType = "Manual";

                break;
            
            default:
                Console.WriteLine("Cambio de marchas introducido no válido.");
                goto NoValidShifter;
            
        }
        
        Console.WriteLine();
        
    }

    public virtual void AssignTractionType()
    {
        TractionType = TractionTypes.RearWheels;

    }
    
    public virtual string AssignPlateNumber()
    {
        Random rand = new Random();
        
        string plateNumber = "";
        
        plateNumber+=rand.Next(0, 10000).ToString("0000") + " ";
        
        for (int i = 0; i < 3; i++) 
        {
            // range in rand.Next() represents the range of values within the ascii table that 
            // corresponds to all capitalised letters of the alphabet.
            plateNumber+=(char)rand.Next(65, 91);

        }
        
        Console.WriteLine($"Matrícula del vehículo: {plateNumber}\n");

        return plateNumber;

    }

    public override string ToString()
    {
        return $"{PlateNumber} - Modelo: {Model}, {WheelCount} ruedas, tracción {TractionType}" +
               $"Tipo de motor: {EngineType}, {HorsePower} Caballos. Cambio de marchas: {GearShiftType}";
        
    }

    #endregion

}