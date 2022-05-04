using GuessFruitBasketWeight.Game;

namespace GuessFruitBasketWeight.Players
{
    public class CheaterPlayer : NonRepetitivePlayer
    {
        public override string Name => base.Name + Player.Name;

        public CheaterPlayer(IPlayer player, IGameHistory gameHistory)
            :base(player, gameHistory.Guesses)
        {
        }
    }
}
