using GuessFruitBasketWeight.Game;
using GuessFruitBasketWeight.Players;

var gameSettings = new GameSettings(90, 40, 140);
var gameHistory = new GameHistory();
var game = new Game(gameSettings, gameHistory);

game.AddPlayer(new RandomPlayer(gameSettings));
game.AddPlayer(new MemorizingPlayer(new RandomPlayer(gameSettings)));
game.AddPlayer(new ThoroughPlayer(gameSettings.LowerLimit));
game.AddPlayer(new CheaterPlayer(new RandomPlayer(gameSettings), gameHistory));
game.AddPlayer(new CheaterPlayer(new ThoroughPlayer(gameSettings.LowerLimit), gameHistory));

game.Start();

Console.Read();