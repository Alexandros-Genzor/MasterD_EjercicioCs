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
        
        
    }

    public virtual void AssignHp()
    {
        
        
    }

    public virtual void AssignWheelCount()
    {
        
        
    }
    
    public abstract void AssignEngineType();

    public virtual void AssignShifterType()
    {
        
        
    }
    
    public abstract void AssignTractionType();
    
    public override string ToString()
    {
        return $"Model: {Model} - {PlateNumber}, {WheelCount} wheels, traction on {TractionType}" +
               $"Engine type: {EngineType}, {HorsePower} HP. Gear shift type: {GearShiftType}";
        
    }

    #endregion

}