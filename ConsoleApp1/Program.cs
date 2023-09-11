using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine("Системный монитор:");
        Console.WriteLine("Нажмите Ctrl+C для завершения.");

        while (!Console.KeyAvailable || Console.ReadKey().Key != ConsoleKey.C)
        {
            // Мониторим загрузку CPU
            float cpuUsage = GetCpuUsage();
            Console.WriteLine($"CPU: {cpuUsage}%");

            // Мониторим доступную оперативную память (RAM)
            float ramAvailable = GetAvailableRam();
            Console.WriteLine($"RAM: {ramAvailable} MB");

            // Пауза между обновлениями
            Thread.Sleep(1000);
        }
    }

    static float GetCpuUsage()
    {
        using (PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total"))
        {
            cpuCounter.NextValue(); // Инициализация
            Thread.Sleep(1000); // Задержка
            return cpuCounter.NextValue();
        }
    }

    static float GetAvailableRam()
    {
        using (PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes"))
        {
            return ramCounter.NextValue();
        }
    }
}
