namespace GuessFruitBasketWeight.Players
{
    public class ThoroughPlayer : Player
    {
        private int startNumber;

        public ThoroughPlayer(int startNumber)
        {
            this.startNumber = startNumber;
        }

        public override int Guess() => startNumber++;
    }
}