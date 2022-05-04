namespace GuessFruitBasketWeight.Players
{
    public class MemorizingPlayer : NonRepetitivePlayer
    {
        public override string Name => $"Memorizing{Player.Name}";

        public MemorizingPlayer(IPlayer player)
            :base(player, new HashSet<int>())
        {
        }

        public override int Guess()
        {
            int guess = base.Guess();

            SaveGuess(guess);
            
            return guess;
        }

        private void SaveGuess(int guess) 
        {
            Guesses.Add(guess);
        }
    }
}
