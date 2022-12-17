using System;
using System.IO;

namespace Provodnik
{
    public class Print_dir
    {
        public static void ShowDirectory(string dir_path)
        { 
            int line = 0;
            while (true)
            {
                
                string[] allDirectories = Directory.GetDirectories(dir_path);
                string[] allFiles = Directory.GetFiles(dir_path);
                Console.WriteLine("F1 - Создать файл  F2 - Создать папку  F3 - Удалить файл  F4 - Удалить папку");
                Console.WriteLine("");
                
                foreach (string dir in allDirectories)
                {
                    if (line == Array.IndexOf(allDirectories, dir))
                    {
                        Console.WriteLine($"----> {dir}");
                    }
                    else
                    {
                        Console.WriteLine($"      {dir}");
                    }
                }
                
                foreach (string file in allFiles)
                {
                    if (line == (Array.IndexOf(allFiles, file) + allDirectories.Length))
                    {
                        Console.WriteLine($"----> {file}");
                    }
                    else
                    {
                        Console.WriteLine($"      {file}");
                    }
                }
             
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow & line > 0)
                {
                    line--;
                    Console.Clear();
                }
                else if (key.Key == ConsoleKey.DownArrow & line < (allDirectories.Length + allFiles.Length - 1))
                {
                    line++;
                    Console.Clear();
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    if (line <= allDirectories.Length)
                    {
                        Print_dir.ShowDirectory(allDirectories[line]);
                   }
                    
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    break;
                     
                }
                else if (key.Key == ConsoleKey.F1)
                {
                    Console.Clear();
                    Console.Write("Введите название файла: ");
                    string FileName = Console.ReadLine();
                    File.Create(dir_path + "\\" + FileName);
                    Console.Clear();
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    Console.Clear();
                    Console.Write("Введите название папки: ");
                    string DirName = Console.ReadLine();
                    Directory.CreateDirectory(dir_path + "\\" + DirName);
                    Console.Clear();
                }
                else if (key.Key == ConsoleKey.F3)
                {
                    Console.Clear();
                   int DeletingChoosedLine = 0;
                     while (true)
                   {
                         Console.WriteLine($"Вы уверены что хотите удалить файл {allFiles[line - allDirectories.Length]}?");
                       if (DeletingChoosedLine == 0)
                        {
                            Console.WriteLine("---> Нет");
                            Console.WriteLine("     Да");
                        }
                        else
                        {
                            Console.WriteLine("     Нет");
                            Console.WriteLine("---> Да");
                        }
                     
                        ConsoleKeyInfo deleting_key = Console.ReadKey();
                        
                        if (deleting_key.Key == ConsoleKey.UpArrow & DeletingChoosedLine > 0)
                        {
                            DeletingChoosedLine--;
                            Console.Clear();
                        }
                        else if (deleting_key.Key == ConsoleKey.DownArrow & DeletingChoosedLine < 1)
                        {
                            DeletingChoosedLine++;
                            Console.Clear();
                        }
                        else if (deleting_key.Key == ConsoleKey.Enter)
                        {
                            if (DeletingChoosedLine == 0)
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                File.Delete(allFiles[line - allDirectories.Length]);
                                Console.Clear();
                                break;
                            }
                        }
                        else
                        {
                            Console.Clear();
                        }
                     
                    }
                }
                else if (key.Key == ConsoleKey.F4)
                {
                    Console.Clear();
                    int DeletingChoosedLine = 0;
                    while (true)
                    {
                        Console.WriteLine($"Вы уверены что хотите удалить папку {allDirectories[line]}?");
                        if (DeletingChoosedLine == 0)
                        {
                            Console.WriteLine("---> Нет");
                            Console.WriteLine("     Да");
                        }
                        else
                        {
                            Console.WriteLine("     Нет");
                            Console.WriteLine("---> Да");
                        }

                        ConsoleKeyInfo deleting_key = Console.ReadKey();
                     
                        if (deleting_key.Key == ConsoleKey.UpArrow & DeletingChoosedLine > 0)
                        {
                            DeletingChoosedLine--;
                            Console.Clear();
                        }
                        else if (deleting_key.Key == ConsoleKey.DownArrow & DeletingChoosedLine < 1)
                        {
                            DeletingChoosedLine++;
                            Console.Clear();
                        }
                        else if (deleting_key.Key == ConsoleKey.Enter)
                        {
                            if (DeletingChoosedLine == 0)
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                DeleteDirectory(allDirectories[line]);
                                Directory.Delete(allDirectories[line]);
                                Console.Clear();
                                break;
                            }
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                }
                else
                {
                    Console.Clear();
                }
            }
         }

        public static void DeleteDirectory(string dir_path)
        {
            string[] allDirectories = Directory.GetDirectories(dir_path);
            string[] allFiles = Directory.GetFiles(dir_path);
             
            foreach (var file in allFiles)
            {
                File.Delete(file);
            }
             
            foreach (var directory in allDirectories)
            {
                DeleteDirectory(directory);
                Directory.Delete(directory);
            }
        }
    }
} 