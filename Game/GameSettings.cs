namespace GuessFruitBasketWeight.Game
{
    public class GameSettings : IGameSettings
    {
        public int FruitBasketWeight { get; set; }

        public int LowerLimit { get; private set; }

        public int UpperLimit { get; private set; }

        public GameSettings(int fruitBasketWeight, int lowerLimit, int upperLimit)
        {
            FruitBasketWeight = fruitBasketWeight;
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }
    }
}
