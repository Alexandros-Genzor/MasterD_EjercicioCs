namespace AlexGenzor.EjercicioMasterD.VehicleTypes;

public class Truck : Vehicle
{
    public enum CabTypes { FlatFront, WideCab}
    
    #region PROPERTIES
    public CabTypes CabType { get; set; }
    
    #endregion
    
    #region CONSTRUCTOR

    public Truck()
    {
        
        
    }
    
    #endregion
    
    #region OVERRIDEABLES
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