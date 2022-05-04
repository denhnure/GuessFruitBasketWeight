namespace GuessFruitBasketWeight.Game
{
    public class GameHistory : IGameHistory
    {
        private HashSet<int> guesses;

        public ICollection<int> Guesses => guesses;

        public GameHistory() => guesses = new HashSet<int>();

        public void SaveGuess(int guess)
        {
            guesses.Add(guess);
        } 
    }
}
