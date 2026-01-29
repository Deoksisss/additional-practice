namespace additional_practice;

public static class Input
{
    // так как ввод пользователя не обязателен,
    // этот хрен будет просто считывать путь где взять исходный файл
    
    public static string GetInputFile()
    {
        Console.WriteLine("Enter input file path:");
        return Console.ReadLine()!;
    }
}