using System;
using System.Collections.Generic;

namespace KT_17_Delegates
{
    /// <summary>
    /// Класс для обработки очков игрока с использованием делегатов Action, Func и Predicate.
    /// </summary>
    public class ScoreProcessor
    {
        // 1. Action<int> — действие без результата (вывод очков)
        public Action<int> PrintScoreAction { get; } = score => Console.WriteLine($"Очки: {score}");

        // 2. Func<int, int> — метод для расчета бонуса
        public Func<int, int> GetBonusCalculator(int bonusAmount) => score => score + bonusAmount;

        // 3. Predicate<int> — метод для проверки проходного балла
        public Predicate<int> GetPassingPredicate(int threshold) => score => score >= threshold;

        /// <summary>
        /// Выполнение проверки по контрольным ключам из задания:
        /// scores = [55, 70, 40, 90]
        /// </summary>
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

        /// <summary>
        /// Демонстрация принципиальной несовместимости типов Predicate<T> и Func<T, bool>
        /// </summary>
        public void DemonstrateTypeIncompatibility()
        {
            Predicate<int> isPassingPredicate = score => score >= 60;
            Func<int, bool> isPassingFunc = score => score >= 60;

            Console.WriteLine($"Результат Predicate<int>(70): {isPassingPredicate(70)}");
            Console.WriteLine($"Результат Func<int, bool>(70): {isPassingFunc(70)}");

            // Прямая попытка присвоения переменной вызовет ошибку компиляции CS0029:
            // isPassingPredicate = isPassingFunc; // Ошибка компиляции!

            Console.WriteLine("\n[Результат]: Попытка присвоить 'Func<int, bool>' переменной 'Predicate<int>' вызывает ошибку CS0029.");
            Console.WriteLine("Вывод: Сигнатуры методов совпадают, но в C# это разные типы делегатов.");
        }
    }
}