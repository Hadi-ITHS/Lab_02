using Lab_02.GameObjects;
using Lab_02.GameObjects.Enemies;

namespace Lab_02.Services
{
    internal class GameService
    {
        string endGameText;
        bool isGameRunning = true;
        bool isPlayerAlive = true;
        LevelData levelData = new LevelData();
        List<Enemy> updatableElements = new List<Enemy>();
        Player player;
        ConsoleKeyInfo input;

        private void Update(char input, Player player)
        {
            for (int i = 20; i < 27; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', Console.WindowWidth));
            }
            player.Update(input);
            foreach (var element in updatableElements)
                element.Update(player);
        }
        private void OnPlayerDead(object sender, object destroyer, int eventId)
        {
            var attacker = (Enemy)destroyer;
            Console.SetCursorPosition(0, 26);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Player is dead! The event id is {(EventIds)eventId}");
            Console.SetCursorPosition(player.positionX, player.positionY);
            Console.Write(' ');
            levelData.Element.Remove(player);
            endGameText = $"You are killed by {attacker.Name}";
            isPlayerAlive = false;
        }
        private void OnEnemyDead(object sender, object destroyer, int eventId)
        {
            var deadElement = (Enemy)sender;
            Console.SetCursorPosition(0, 26);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{deadElement.Name} is dead! The event id is {(EventIds)eventId}");
            Console.SetCursorPosition(deadElement.positionX, deadElement.positionY);
            Console.Write(' ');
            updatableElements.Remove(deadElement);
            levelData.Element.Remove(deadElement);
        }

        private void HandleVisionRange()
        {
            foreach (var item in levelData.Element)
            {
                if (item is not Player)
                {
                    double distanceToPlayer;
                    distanceToPlayer = Math.Round(Math.Sqrt(Math.Abs(player.positionY - item.positionY) * Math.Abs(player.positionY - item.positionY) + Math.Abs(player.positionX - item.positionX) * Math.Abs(player.positionX - item.positionX)));
                    if (distanceToPlayer > 6)
                    {
                        item.IsVisible = false;
                        item.ElementOutOfVisionRange();
                    }
                    else
                    {
                        item.IsVisible = true;
                        item.Draw();
                        item.IsDiscovered = true;
                    }
                }
            }
        }

        private void HandleCombat()
        {

        }

        public string StartGame()
        {
            //initializing the game
            Console.CursorVisible = false;
            levelData.Load("Level1.txt");
            foreach (var element in levelData.Element)
            {
                if (element is Player)
                {
                    this.player = (Player)element;
                    player.PlayerDead += OnPlayerDead; //Event subscription
                }

                else if (element is Enemy)
                {
                    updatableElements.Add((Enemy)element);
                }
            }
            foreach (var enemy in updatableElements)
            {
                player.PlayerAttacks += enemy.OnAttackRecieved; //Event subscription
                enemy.EnemyAttacks += player.OnAttackRecieved; //Event subscription
                enemy.EnemyDead += OnEnemyDead; //Event subscription
            }


            //game loop
            while (isGameRunning)
            {
                HandleVisionRange();
                input = Console.ReadKey(true);
                Update(input.KeyChar, player);
                if (!isPlayerAlive)
                {
                    Console.Clear();
                    return endGameText;
                }
            }
            Console.Clear();
            return endGameText;
        }
    }
}
