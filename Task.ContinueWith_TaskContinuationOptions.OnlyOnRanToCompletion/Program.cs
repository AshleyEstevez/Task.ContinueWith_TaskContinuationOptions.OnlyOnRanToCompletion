using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Task task = await Task.Factory.StartNew(async () =>
        {
            Console.WriteLine("Tarea principal ejecutándose.");
            await Task.Delay(1000);
            Console.WriteLine("Tarea principal terminada.");
        });

        
        task.ContinueWith(t =>
        {
            Console.WriteLine("Tarea0 de continuación ejecutándose.");
        });

        
        await task.ContinueWith(t =>
        {
            Console.WriteLine("Tarea1 de continuación ejecutándose.");
        });

        
        await task.ContinueWith(t =>
        {
            Console.WriteLine("Tarea2 de continuación ejecutándose.");
        }, TaskContinuationOptions.OnlyOnRanToCompletion);

        
        await task.ContinueWith(t =>
        {
            Console.WriteLine("Tarea3 de continuación ejecutándose después de la tarea principal.");
        }, TaskContinuationOptions.OnlyOnRanToCompletion);

       
        await task.ContinueWith(t =>
        {
            Console.WriteLine("Tarea4 de continuación de un hermano ejecutándose después de la tarea principal.");
        }, TaskContinuationOptions.OnlyOnRanToCompletion);
    }
}

