namespace StarWarsPlanetsStats.UserInteractions;

interface IUserInteraction
{
    void ShowMessage();
    void ShowMessage(string message);
    string? ReadFromUser();
}