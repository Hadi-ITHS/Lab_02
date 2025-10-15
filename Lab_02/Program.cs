using Lab_02.Services;

GameService gs = new GameService();
string endGameText;

endGameText = gs.StartGame();

Console.WriteLine($"{endGameText}\nClose the program and open it again to play another round!");