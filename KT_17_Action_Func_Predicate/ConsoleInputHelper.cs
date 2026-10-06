using System;
using System.Collections.Generic;

namespace KT_17_Delegates
{
    public static class ConsoleInputHelper
    {
        public static List<int> ReadScores()
        {
            List<int> scores = new();
            Console.WriteLine("Введите очки игроков по одному (для завершения нажмите Enter или введите 'stop'):");

            while (true)
            {
                try
                {
                    Console.Write($"Очки игрока #{scores.Count + 1}: ");
                    string input = Console.ReadLine()?.Trim();

                    if (string.IsNullOrEmpty(input) || input.Equals("stop", StringComparison.OrdinalIgnoreCase))
                    {
                        if (scores.Count == 0)
                        {
                            throw new ArgumentException("Список не может быть пустым. Введите хотя бы одно значение.");
                        }
                        break;
                    }

                    if (!int.TryParse(input, out int score))
                    {
                        throw new FormatException($"Введённое значение '{input}' не является целым числом.");
                    }

                    if (score < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(score), "Количество очков не может быть отрицательным.");
                    }

                    scores.Add(score);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"[Ошибка формата]: {ex.Message} Попробуйте снова.");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"[Ошибка диапазона]: {ex.Message} Попробуйте снова.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"[Ошибка ввода]: {ex.Message} Попробуйте снова.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Ошибка]: {ex.Message} Попробуйте снова.");
                }
            }

            return scores;
        }

        public static int ReadInt(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine()?.Trim();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new ArgumentException("Значение не может быть пустым.");
                    }

                    if (!int.TryParse(input, out int result))
                    {
                        throw new FormatException($"Введённое значение '{input}' не является целым числом.");
                    }

                    return result;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"[Ошибка формата]: {ex.Message} Попробуйте снова.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"[Ошибка ввода]: {ex.Message} Попробуйте снова.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Ошибка]: {ex.Message} Попробуйте снова.");
                }
            }
        }
    }
}
