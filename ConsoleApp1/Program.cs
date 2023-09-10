using System;
using System.Diagnostics;
//Чепилян Семен Вариант 20
class Program
{
    static void Main()
    {
        Console.WriteLine("Программа для автоматического обновления операционной системы запущена");

        if (IsWindows())
        {
            Console.WriteLine("Обнаружена ОС Windows");
            RunWindowsUpdate();
        }
        Console.WriteLine("Программа завершена");
    }

    static bool IsWindows()
    {
        return Environment.OSVersion.Platform == PlatformID.Win32NT;
    }

    static void RunWindowsUpdate()
    {
        try
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C wuauclt /detectnow"; // поиск и установка обновлений
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            Console.WriteLine("Результат обновления Windows:\n" + output);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при обновлении Windows: {ex.Message}");
        }
    }
}
