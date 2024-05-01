using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_Process
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            while (true)
            {
                Console.WriteLine("Программа Диспетчер задач");
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Показать список процессов");
                Console.WriteLine("2. Завершить процесс");
                Console.WriteLine("3. Выход");

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, выберите действие 1, 2 или 3:");
                }

                switch (choice)
                {
                    case 1:
                        ShowProcesses();
                        Console.ReadKey();
                        break;
                    case 2:
                        CloseProcess();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Программа завершена.");
                        break;
                }
                Console.Clear();
            }
        }

        private static void CloseProcess()
        {
            Console.WriteLine("Введите ID процесса, который вы хотите завершить:");
            int processId;

            while (!int.TryParse(Console.ReadLine(), out processId))
            {
                Console.WriteLine("Процесс с таким Id не найден. Повторите ввод");
            }

            try
            {
                Process process = Process.GetProcessById(processId);
                process.Kill();
                Console.WriteLine($"Процесс {process.ProcessName} успешно завершен.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ShowProcesses()
        {
            var processes = Process.GetProcesses();
            foreach (var item in processes.OrderBy(i => i.Id))
            {
                Console.WriteLine($"Id: {item.Id} Name: {item.ProcessName}");
            }
        }
    }
}
