namespace GuessFruitBasketWeight.Game
{
    public interface IGameHistory
    {
        // TODO: expose read only collection
        ICollection<int> Guesses { get; }

        void SaveGuess(int guess);
    }
}
