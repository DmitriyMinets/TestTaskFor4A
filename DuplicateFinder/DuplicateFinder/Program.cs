namespace DuplicateFinder
{
    internal class Program
    {
        static void Main()
        {
            int[] M = { 1, 2, 3, 1, 4, 5, 6, 2, 7, 8, 9, 5 }; 

            // Словарь для хранения количества появлений каждого элемента
            Dictionary<int, int> elementCount = [];

            // Массив для хранения повторяющихся элементов
            HashSet<int> duplicates = [];

            foreach (int element in M)
            {
                if (elementCount.TryGetValue(element, out int value))
                {
                    // Если элемент уже есть в словаре, увеличиваем его счетчик
                    elementCount[element] = ++value;
                    // Если элемент появляется более одного раза, добавляем его в множество повторяющихся
                    if (value == 2)
                    {
                        duplicates.Add(element);
                    }
                }
                else
                {
                    // Если элемент встречается впервые, добавляем его в словарь
                    elementCount[element] = 1;
                }
            }

            // Вывод повторяющихся элементов
            Console.WriteLine("Повторяющиеся элементы:");
            foreach (int element in duplicates)
            {
                Console.WriteLine(element);
            }
        }
    }
}
