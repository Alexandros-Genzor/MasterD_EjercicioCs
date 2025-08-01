namespace AlexGenzor.EjercicioMasterD.Utils;

public class MyUtils
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="prompt">Cadena de texto que contiene la pregunta a la cuál responder.</param>
    /// <returns>Booleano cuyo valor corresponde a Si / No respectívamente</returns>
    public static bool DecipherAnswer(string prompt)
    {
        NoValidAnswer:
        
        Console.Write($"{prompt} (y/n): ");

        switch (Console.ReadLine().ToLower()) 
        {
            case "y":
            case "s":
            case "yes":
            case "si":
                return true;
                
            case "n":
            case "no":
                return false;
                
            default:
                Console.WriteLine("Respuesta no válida.");
                
                 goto NoValidAnswer;
                
        }

    }
    
}