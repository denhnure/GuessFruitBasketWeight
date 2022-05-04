namespace GuessFruitBasketWeight.Players
{
    public abstract class Player : IPlayer
    {
        public virtual string Name => GetType().Name;

        public abstract int Guess();
    }
}
