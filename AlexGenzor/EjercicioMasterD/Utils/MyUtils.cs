namespace AlexGenzor.EjercicioMasterD.Utils;

public class MyUtils
{
    /// <summary>
    /// Solicita al usuario que introduzca una respuesta Sí / No según una indicación en forma de parámetro. <br/>
    /// En caso de introducir una respuesta no válida a la cuestion, devuelve un aviso de invalidez de la respuesta
    /// y pregunta de nuevo al usuario hasta que una respuesta válida haya sido introducida.
    /// </summary>
    /// <param name="prompt">Cadena de texto que contiene la pregunta a la cuál se pide una respuesta.</param>
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