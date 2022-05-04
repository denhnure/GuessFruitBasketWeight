using System.Collections.Concurrent;
using System.Diagnostics;
using GuessFruitBasketWeight.Players;

namespace GuessFruitBasketWeight.Game
{
    public class Game : IGame
    {
        private readonly IGameSettings gameSettings;
        private readonly IGameHistory gameHistory;
        private readonly ConcurrentQueue<IPlayer> players;
        private Stopwatch stopWatch;

        public Game(IGameSettings gameSettings, IGameHistory gameHistory)
        {
            this.gameSettings = gameSettings;
            this.gameHistory = gameHistory;
            players = new ConcurrentQueue<IPlayer>();
            stopWatch = new Stopwatch();
        }

        public void AddPlayer(IPlayer player)
        {
            players.Enqueue(player);
        }

        public void Start()
        {
            stopWatch.Start();

            while (true)
            {
                IPlayer? player;
                players.TryDequeue(out player);

                if (player == null)
                {
                    continue;
                }

                int guess = player.Guess();
                gameHistory.SaveGuess(guess);

                Console.WriteLine("{0} - {1}", player.Name, guess);

                if (guess == gameSettings.FruitBasketWeight)
                {
                    stopWatch.Stop();
                    Console.WriteLine("Winner is: {0}, elapsed milliseconds: {1}", player.Name, stopWatch.ElapsedMilliseconds);
                    break;
                }

                DelayPlayerTurn(player, Math.Abs(gameSettings.FruitBasketWeight - guess));
            }
        }

        private async void DelayPlayerTurn(IPlayer player, int milliseconds)
        {
            await Task.Delay(milliseconds);
            players.Enqueue(player);
        }
    }
}
