using System;

namespace C__more_plus__task3
{
    class FloydWarshall
    {
        // Встановлюємо нескінченність як велике число, яке символізує відсутність шляху
        public const int INF = 99999;

        public static void Main(string[] args)
        {
            // Ініціалізація матриці ваг графа
            int[,] graph = {
            {0,   5,  INF, 10},
            {INF, 0,   3,  INF},
            {INF, INF, 0,   1},
            {INF, INF, INF, 0}
        };

            // Кількість вершин у графі
            int verticesCount = 4;

            // Виклик алгоритму Флойда-Воршелла
            int[,] distances = FloydWarshallAlgorithm(graph, verticesCount);

            // Виведення результатів
            Print(distances, verticesCount);
        }

        // Алгоритм Флойда-Воршелла
        public static int[,] FloydWarshallAlgorithm(int[,] graph, int verticesCount)
        {
            // Створення матриці найкоротших шляхів
            int[,] distances = new int[verticesCount, verticesCount];

            // Ініціалізація матриці найкоротших шляхів
            for (int i = 0; i < verticesCount; ++i)
                for (int j = 0; j < verticesCount; ++j)
                    distances[i, j] = graph[i, j];

            // Основні ітерації алгоритму
            for (int k = 0; k < verticesCount; ++k)
            {
                for (int i = 0; i < verticesCount; ++i)
                {
                    for (int j = 0; j < verticesCount; ++j)
                    {
                        // Оновлення ваги шляху, якщо знайдено кращий шлях
                        if (distances[i, k] + distances[k, j] < distances[i, j])
                            distances[i, j] = distances[i, k] + distances[k, j];
                    }
                }
            }

            return distances;
        }

        // Функція для виведення матриці найкоротших шляхів
        public static void Print(int[,] distances, int verticesCount)
        {
            Console.WriteLine("Матриця найкоротших шляхiв мiж усiма парами вершин:");
            for (int i = 0; i < verticesCount; ++i)
            {
                for (int j = 0; j < verticesCount; ++j)
                {
                    if (distances[i, j] == INF)
                        Console.Write("INF".PadLeft(7));
                    else
                        Console.Write(distances[i, j].ToString().PadLeft(7));
                }
                Console.WriteLine();
            }
        }
    }
}
