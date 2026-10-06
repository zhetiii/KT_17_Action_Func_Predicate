using System;
using System.Collections.Generic;

namespace KT_17_Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("==================================================");
            Console.WriteLine("  КТ №17: Action, Func, Predicate (Вариант 1)    ");
            Console.WriteLine("==================================================\n");

            ScoreProcessor processor = new ScoreProcessor();

            Console.WriteLine("=== 1. Проверка по контрольным ключам ===");
            processor.RunTeacherTests();

            Console.WriteLine("\n=== 2. Демонстрация несовместимости типов делегатов ===");
            processor.DemonstrateTypeIncompatibility();

            Console.WriteLine("\n=== 3. Интерактивный ручной ввод ===");
            RunInteractiveSession(processor);

            Console.WriteLine("\nПрограмма завершена.");
        }

        private static void RunInteractiveSession(ScoreProcessor processor)
        {
            List<int> userScores = ConsoleInputHelper.ReadScores();

            int bonus = ConsoleInputHelper.ReadInt("\nВведите размер бонуса для начисления: ");
            int passingScore = ConsoleInputHelper.ReadInt("Введите проходной балл для поиска: ");

            Func<int, int> applyBonus = processor.GetBonusCalculator(bonus);
            Predicate<int> isPassing = processor.GetPassingPredicate(passingScore);

            Console.WriteLine("\n--- Вывод очков (Action<int>) ---");
            userScores.ForEach(processor.PrintScoreAction);

            Console.WriteLine("\n--- Применение бонуса (Func<int, int>) ---");
            foreach (int score in userScores)
            {
                Console.WriteLine($"Исходные очки: {score} -> С бонусом (+{bonus}): {applyBonus(score)}");
            }

            Console.WriteLine("\n--- Поиск первого проходного балла (Predicate<int>) ---");
            int found = userScores.Find(isPassing);
            if (found != 0 || userScores.Contains(0))
            {
                Console.WriteLine($"Первые очки >= {passingScore}: {found}");
            }
            else
            {
                Console.WriteLine($"Очки >= {passingScore} не найдены.");
            }
        }
    }
}
