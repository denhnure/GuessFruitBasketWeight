namespace GuessFruitBasketWeight.Game
{
    public interface IGameSettings 
    {
        int FruitBasketWeight { get; set; }

        int LowerLimit { get; }

        int UpperLimit { get; }
    }
}
