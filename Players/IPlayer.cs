namespace GuessFruitBasketWeight.Players
{
    public interface IPlayer
    {
        string Name { get; }

        int Guess();
    }
}
