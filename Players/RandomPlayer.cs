using GuessFruitBasketWeight.Game;

namespace GuessFruitBasketWeight.Players
{
    public class RandomPlayer : Player
    {
        private readonly IGameSettings gameSettings;
        private readonly Random random;

        public RandomPlayer(IGameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
            random = new Random();
        }

        public override int Guess()
        {
            return random.Next(gameSettings.LowerLimit, gameSettings.UpperLimit);
        }
    }
}
