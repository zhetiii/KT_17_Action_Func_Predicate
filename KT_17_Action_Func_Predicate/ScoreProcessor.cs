using System;
using System.Collections.Generic;

namespace KT_17_Delegates
{
    public class ScoreProcessor
    {
        public Action<int> PrintScoreAction { get; } = score => Console.WriteLine($"Очки: {score}");

        public Func<int, int> GetBonusCalculator(int bonusAmount) => score => score + bonusAmount;

        public Predicate<int> GetPassingPredicate(int threshold) => score => score >= threshold;

        public void RunTeacherTests()
        {
            List<int> scores = new() { 55, 70, 40, 90 };

            Func<int, int> applyBonus = GetBonusCalculator(10);
            Predicate<int> isPassing = GetPassingPredicate(60);

            Console.WriteLine("--- 1. Выполнение Action<int> для каждого элемента ---");
            foreach (int score in scores)
            {
                PrintScoreAction(score);
            }

            Console.WriteLine("\n--- 2. Вызов applyBonus(55) ---");
            int bonusResult = applyBonus(55);
            Console.WriteLine($"Результат: {bonusResult}");

            Console.WriteLine("\n--- 3. Поиск первого значения через scores.Find(isPassing) ---");
            int firstPassing = scores.Find(isPassing);
            Console.WriteLine($"Результат: {firstPassing}");
        }
        public void DemonstrateTypeIncompatibility()
        {
            Predicate<int> isPassingPredicate = score => score >= 60;
            Func<int, bool> isPassingFunc = score => score >= 60;

            Console.WriteLine($"Результат Predicate<int>(70): {isPassingPredicate(70)}");
            Console.WriteLine($"Результат Func<int, bool>(70): {isPassingFunc(70)}");

            Console.WriteLine("\n[Результат]: Попытка присвоить 'Func<int, bool>' переменной 'Predicate<int>' вызывает ошибку CS0029.");
            Console.WriteLine("Вывод: Сигнатуры методов совпадают, но в C# это разные типы делегатов.");
        }
    }
}
