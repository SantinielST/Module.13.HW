using System.Text;

namespace Module._13.HW;

internal class Program
{
    static void Main(string[] args)
    {
        var path = $"D:/Repos/Module.13.HW/Module.13.HW/text.txt"; // Записываем путь к файлу в переменную

        var text = new StringBuilder(); // Создаем обект каласса StringBuilder для записи текста из файла

        using (StreamReader sr = new StreamReader(path)) // С помощью конструкции using открываем файл и читаем информацию из него
        {
            string? line;
            while ((line = sr.ReadLine()) != null) // Читаем из файла пока не закончится текст
            {
                if (line != string.Empty)
                    text.AppendLine(line);
            }
        }

        var noPunctuationText = new string(text.ToString().Where(c => !char.IsPunctuation(c) && !char.IsControl(c)).ToArray()) // Исключаем знаки пунктуации и символы
            .Split(' ').GroupBy(s => s).OrderByDescending(s => s.Count()) // Разделяем текст в массив, в качестве разделителя служит пробел, группируем массив строк, сортируем по количеству повторов по убыванию
            .Where(s => s.Key != "").Take(10); // Исключаем оставшиеся пустые строки, берём первые 10 строк из словаря

        foreach (var item in noPunctuationText)
        {
            Console.WriteLine($"Количество повторов: {item.Count()}, слово: {item.Key}"); // Выводим 10 слов с наибольшим количеством повторов
        }
    }
}
