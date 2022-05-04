using System.Diagnostics;
using GuessFruitBasketWeight.Players;

namespace GuessFruitBasketWeight.Game
{
    public class Game : IGame
    {
        private readonly IGameSettings gameSettings;
        private readonly IGameHistory gameHistory;
        private readonly Queue<IPlayer> players;
        private bool isGameInProgress;
        private Stopwatch stopWatch;
        private object syncObject;

        public Game(IGameSettings gameSettings, IGameHistory gameHistory)
        {
            this.gameSettings = gameSettings;
            this.gameHistory = gameHistory;
            players = new Queue<IPlayer>();
            stopWatch = new Stopwatch();
            syncObject = new object();
        }

        public void AddPlayer(IPlayer player)
        {
            players.Enqueue(player);
        }

        public void Start()
        {
            stopWatch.Start();
            isGameInProgress = true;

            while(players.Count > 0 && isGameInProgress)
            {
                var player = players.Dequeue();
                int guess = player.Guess();
                gameHistory.SaveGuess(guess);
                
                Console.WriteLine("{0} - {1}", player.Name, guess);

                if(guess == gameSettings.FruitBasketWeight)
                {
                    isGameInProgress = false;
                    break;
                }

                DelayPlayerTurn(player, Math.Abs(gameSettings.FruitBasketWeight - guess));
            }
        }

        private async void DelayPlayerTurn(IPlayer player, int milliseconds)
        {
            await Task.Delay(milliseconds);

            lock(syncObject)
            {
                if (!isGameInProgress)
                {
                    return;
                }

                if(players.Count > 0)
                {
                    players.Enqueue(player);
                    return;
                }
                
                int guess = player.Guess();
                gameHistory.SaveGuess(guess);

                Console.WriteLine("{0} - {1}", player.Name, guess);

                if(guess == gameSettings.FruitBasketWeight)
                {
                    stopWatch.Stop();
                    isGameInProgress = false;
                    Console.WriteLine("Winner is: {0}, elapsed milliseconds: {1}", player.Name, stopWatch.ElapsedMilliseconds);
                }

                DelayPlayerTurn(player, Math.Abs(gameSettings.FruitBasketWeight - guess));
            }
        }
    }
}
