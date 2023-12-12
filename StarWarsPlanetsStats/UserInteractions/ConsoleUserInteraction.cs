namespace StarWarsPlanetsStats.UserInteractions;

class ConsoleUserInteraction : IUserInteraction
{
    public void ShowMessage()
    {
        Console.WriteLine();
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public string? ReadFromUser()
    {
        return Console.ReadLine();
    }
}