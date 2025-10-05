// See https://aka.ms/new-console-template for more information
using Lab_02.GameObjects;

Console.WriteLine("Hello, World!");
LevelData levelData = new LevelData();
levelData.Load("Level1.txt");
levelData.WritePlayerDetails();
Console.ReadLine();
