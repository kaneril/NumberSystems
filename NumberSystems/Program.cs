using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NumberSystems
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:\n 1 Перевести из одной системы счисления в другую\n 2 Завершить работу");
                var str = Console.ReadLine();
                switch (str)
                {
                    case "1":
                        TransferToAnotherSystem();
                        break;                    
                    case "2":
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неверный код действия");
                        break;
                }
            }
        }
        static void TransferToAnotherSystem()
        {
            var alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Console.WriteLine("Внимание! Данная программа работает только с НАТУРАЛЬНЫМИ числами, представленных в системах счисления с основаниями [ 2; 36 ]");
            Console.WriteLine("Введите НАТУРАЛЬНОЕ число, которое нужно перевести в другую систему счисления");
            var numeric= Console.ReadLine();
            Console.WriteLine("Введите основание системы счисления этого числа (ДЕСЯТИЧНОЕ НАТУРАЛЬНОЕ число)");
            var OldBase = Console.ReadLine();
            Console.WriteLine("Введите новое основание системы счисления, в которую необходимо перевести Ваше число (ДЕСЯТИЧНОЕ НАТУРАЛЬНОЕ число)");
            var NewBase = Console.ReadLine();
            if (CheckInput(numeric, OldBase, NewBase, alphabet))
            {

            }
        }
        static bool CheckInput(string numeric, string OldBase, string NewBase, string alphabet)
        {
            return (CheckSymbols(numeric, alphabet) && CheckSymbols(OldBase, alphabet) && CheckSymbols(NewBase, alphabet) && CheckBase(OldBase, alphabet.Length) && CheckBase(NewBase, alphabet.Length) && CheckNumeric(numeric, OldBase, alphabet));
        }
        static bool CheckSymbols(string number, string alphabet)
        {
            Regex reg = new Regex(@"[^"+alphabet+"]", RegexOptions.IgnoreCase);
            MatchCollection mc = reg.Matches(number);
            if (mc.Count!=0)
            {
                Console.WriteLine("Неверный формат числа");
                return false;
            }           
            return true;            
        }
        static bool CheckBase(string SomeBase, int maxValue)
        {
            try
            {
                int m = Int32.Parse(SomeBase);
                if ((m >= 2) && (m <= maxValue))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Неверный формат основания системы счисления");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
        static bool CheckNumeric(string numeric, string OldBase, string alphabet)
        {
            var numerics = alphabet.Remove(Int32.Parse(OldBase));
            Regex reg = new Regex(@"[^" + numerics + "]", RegexOptions.IgnoreCase);
            MatchCollection mc = reg.Matches(numeric);
            if (mc.Count != 0)
            {
                Console.WriteLine("В числе использованы символы больше основания системы счисления");
                return false;
            }
            return true;
        }
    }
}
