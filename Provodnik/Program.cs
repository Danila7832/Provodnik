using Provodnik;
using System;
using System.IO;
using System.Runtime.ConstrainedExecution;

namespace Provodnik
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            int choosed_line = 1;
            DriveInfo[] drives = DriveInfo.GetDrives();
            while (true)
            {
                try
                {
                    int i = 1;

                    foreach (DriveInfo drive in drives)
                    {
                        if (i == choosed_line)
                        {
                            Console.WriteLine($"---> {i}. Диск {drive.Name} {drive.AvailableFreeSpace / 1073741824} Гб свободно из {drive.TotalSize / 1073741824} Гб");
                        }
                        else
                        {
                            Console.WriteLine($"     {i}. Диск {drive.Name} {drive.AvailableFreeSpace / 1073741824} Гб свободно из {drive.TotalSize / 1073741824} Гб");
                        }
                        i++;
                    }
                }
                catch
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.UpArrow & choosed_line > 1)
                    {
                        choosed_line--;
                        Console.Clear();
                    }
                    else if (key.Key == ConsoleKey.DownArrow & choosed_line < drives.Length)
                    {
                        choosed_line++;
                        Console.Clear();
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        Print_dir.ShowDirectory(drives[choosed_line - 1].Name);

                    }
                    else
                    {
                        Console.Clear();
                    }
                }
            }
        }
    }
}

