using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracticaSemaforo
{
    internal class Program
    {
        static Semaphore semaphore = new Semaphore(3, 3);
        static int conteo = 0;

        static void Main(string[] args)
        {
            int n = 0;
            // Creamos varios hilos
            for (n = 0; n < 8; n++)
            {
                new Thread(Metodo).Start(n);
            }
            Console.ReadKey();
        }
        static void Metodo(object n)
        {
            Console.ForegroundColor = ConsoleColor.White;
            global::System.Console.WriteLine("Estamos en el metodo {0}, lo invoco", n);
            Random rnd = new Random();

            // Iniciamos la seccion critica
            semaphore.WaitOne();
            conteo++;
            global::System.Console.WriteLine("Hilos en la seccion ->{0}", conteo);
            Console.ForegroundColor = ConsoleColor.Green;
            global::System.Console.WriteLine("{0} esta en la seccion critica", n);
            Thread.Sleep(1000 * rnd.Next(1, 5));
            Console.ForegroundColor = ConsoleColor.Yellow;
            global::System.Console.WriteLine("{0} abandona la seccion critica ", n);
            //Fin de la seccion critica
            semaphore.Release();
            conteo--;
            global::System.Console.WriteLine("Hilos en la seccion -> {0}", conteo);
        }
    }
}
