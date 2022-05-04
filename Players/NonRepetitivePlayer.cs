namespace GuessFruitBasketWeight.Players
{
    public abstract class NonRepetitivePlayer : Player
    {
        protected IPlayer Player { get; private set; }

        protected ICollection<int> Guesses { get; private set; }

        protected NonRepetitivePlayer(IPlayer player, ICollection<int> guesses)
        {
            Player = player;
            Guesses = guesses;
        }

        public override int Guess()
        {
            int guess;

            do 
            {
                guess = Player.Guess();
            }
            while(Guesses.Contains(guess));
            
            return guess;
        }
    }
}
