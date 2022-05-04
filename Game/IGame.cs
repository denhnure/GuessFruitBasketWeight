using GuessFruitBasketWeight.Players;

namespace GuessFruitBasketWeight.Game
{
    public interface IGame
    {
        void AddPlayer(IPlayer player);

        void Start();
    }
}
