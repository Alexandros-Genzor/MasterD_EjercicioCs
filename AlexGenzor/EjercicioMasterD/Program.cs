// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
using AlexGenzor.EjercicioMasterD.VehicleTypes;

namespace AlexGenzor.EjercicioMasterD;

public class Program
{
    public static void Main(string[] args)
    {
        Vehicle vehicle = new Truck();
        Console.WriteLine(vehicle.GetType().Name);
        

    }
    
}