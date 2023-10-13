using System.Diagnostics;
using Aspose.Cells;
using Aspose.Cells.Charts;
using ConsoleApp1;

LinearSort LinerSortFunctions = new LinearSort();
MinMaxSort MinMaxSortFunctions = new MinMaxSort();
BubbleSort BubbleSortFunctions = new BubbleSort();
InsertionSort InsertionSortFunctions = new InsertionSort();

//Ошибка 2

try
{
    Console.WriteLine("Введите количество элементов массива (не менее 100):");
    int num = int.Parse(Console.ReadLine() ?? string.Empty);


    bool ValidValue = false || num < 100;

    while (ValidValue)
    {
        Console.WriteLine("Количество элементов меньше 100, введите значение ещё раз");
        num = int.Parse(Console.ReadLine() ?? string.Empty);
        ValidValue = false || num < 100;
    }

    int[] arr = GenerateRandomArray(num);
    int[] array = arr;


    Console.WriteLine("Ваш массив: ");
    foreach (var t in arr)
    {
        Console.Write($"{t}, ");
    }

    Console.WriteLine();

    Console.WriteLine("Выберите порядок сортировки:");
    Console.WriteLine("1 - по возрастанию");
    Console.WriteLine("2 - по убыванию");
    var order = int.Parse(Console.ReadLine() ?? string.Empty);

    int choice;
    int[] methods = new int[5];
    float[] executionTimes = new float[5];
    int times = 0;

    do
    {
        Console.WriteLine("Выберите метод сортировки:");
        Console.WriteLine("1 - Линейный метод");
        Console.WriteLine("2 - Метод минимального (максимального) элемента");
        Console.WriteLine("3 - Метод пузырька");
        Console.WriteLine("4 - Сортировка вставки");

        var method = int.Parse(Console.ReadLine() ?? string.Empty);
        methods[times] = method;

        Stopwatch sw = new Stopwatch();
        sw.Start();

        switch (method)
        {
            case 1:
                LinerSortFunctions.linearSort(arr);
                break;
            case 2:
                MinMaxSortFunctions.minMaxSort(arr);
                break;
            case 3:
                BubbleSortFunctions.bubbleSort(arr);
                break;
            case 4:
                InsertionSortFunctions.insertionSort(arr);
                break;
        }

        sw.Stop();
        executionTimes[times] = (float)sw.Elapsed.TotalMilliseconds;

        Console.WriteLine("Отсортированный массив: ");

        if (order == 1)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}, ");
            }
        }

        else if (order == 2)
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write($"{arr[i]}, ");
            }
        }

        Console.WriteLine();

        Console.WriteLine($"Массив отсортирован за: {sw.Elapsed.TotalMilliseconds} мс");

        Console.WriteLine("Хотите выбрать ещё методы для сравнения?");
        Console.WriteLine("1 - да");
        Console.WriteLine("2 - нет");
        choice = int.Parse(Console.ReadLine() ?? string.Empty);
        arr = array;
        times++;
    } while (choice == 1 && times < methods.Length);


    //-----------------------------------------------------
    // Создаем новый Workbook
    var workbook = new Workbook();

    // Получаем первый лист
    var sheet = workbook.Worksheets[0];

    // Добавляем заголовки для столбцов
    sheet.Cells[0, 0].PutValue("Метод");
    sheet.Cells[0, 1].PutValue("Время выполнения (мс)");
// Заполняем таблицу данными
    for (int i = 0; i < methods.Length; i++)
    {
        sheet.Cells[i + 1, 0].PutValue(methods[i]);
        sheet.Cells[i + 1, 1].PutValue(executionTimes[i]);
    }

    int chartIndex = sheet.Charts.Add(ChartType.Bar, 10, 0, 30, 10);

    Aspose.Cells.Charts.Chart chart = sheet.Charts[chartIndex];

    // Устанавливаем диапазон данных для графика
    chart.NSeries.Add($"B2:B{methods.Length + 1}", true);

    // Устанавливаем заголовок для графика
    chart.Title.Text = "Сравнение времени выполнения методов сортировки";

    // Устанавливаем названия для осей графика
    chart.CategoryAxis.Title.Text = "Метод";
    chart.ValueAxis.Title.Text = "Время выполнения (мс)";

    // Сохраняем файл
    workbook.Save("отчет.xlsx", SaveFormat.Xlsx);
    //--------------------------------------------------
}

catch (FormatException ex)
{
    Console.WriteLine("Некорректный формат ввода! Ошибка: " + ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("Ошибка: " + ex.Message);
}

static int[] GenerateRandomArray(int num)
{

    int[] arr = new int[num];
    Random rand = new Random();

    for (int i = 0; i < arr.Length; i++)
    {
                arr[i] = rand.Next(1, 50);
    }
    return arr;
}
