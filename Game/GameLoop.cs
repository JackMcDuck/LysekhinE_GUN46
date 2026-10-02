using GamePrototype.Combat;
using GamePrototype.Dungeon;
using GamePrototype.Units;
using GamePrototype.Utils;

public enum Difficulty
{
    Easy = 1,
    Hard
}

namespace GamePrototype.Game
{
    public sealed class GameLoop
    {
        private Unit _player;
        private DungeonRoom _dungeon;
        private readonly CombatManager _combatManager = new CombatManager();
        
        public void StartGame() 
        {
            Initialize();
            Console.WriteLine("Entering the dungeon");
            StartGameLoop();
        }

        #region Game Loop

        private void Initialize()
        {
            Console.WriteLine("Welcome, player! Choose your difficulty:\n1 - Easy, 2 - Hard: ");
            Difficulty difficulty = 0;
            UnitFactoryDemo factory;
            DungeonBuilder builder;

            while (difficulty == 0)
            {
                if(int.TryParse(Console.ReadLine(), out int input))
                {
                    switch (input)
                    {
                        case 1:
                            difficulty = Difficulty.Easy;
                            break;
                        case 2:
                            difficulty = Difficulty.Hard;
                            break;
                        default:
                            Console.WriteLine("Unknown commad. Try Again.  Choose your difficulty:\n1 - Easy, 2 - Hard: ");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Use 1 to choose Easy or 2 to choose Hard");
                }
            }
            if(difficulty == Difficulty.Easy)
            {
                factory = new EasyUnitFactory();
                builder = new EasyDungeonBuilder(factory);
            }
            else
            {
                factory = new HardUnitFactory();
                builder = new HardDungeonBuilder(factory);
            }
            _dungeon = builder.BuildDungeon();
            Console.WriteLine("Enter your name");
            _player = factory.CreatePlayer(Console.ReadLine());
            Console.WriteLine($"Hello {_player.Name}");
        }

        private void StartGameLoop()
        {
            var currentRoom = _dungeon;
            
            while (currentRoom.IsFinal == false) 
            {
                StartRoomEncounter(currentRoom, out var success);
                if (!success) 
                {
                    Console.WriteLine("Game over!");
                    return;
                }
                DisplayRouteOptions(currentRoom);
                while (true) 
                {
                    if (Enum.TryParse<Direction>(Console.ReadLine(), out var direction) ) 
                    {
                        currentRoom = currentRoom.Rooms[direction];
                        break;
                    }
                    else 
                    {
                        Console.WriteLine("Wrong direction!");
                    }
                }
            }
            Console.WriteLine($"Congratulations, {_player.Name}");
            Console.WriteLine("Result: ");
            Console.WriteLine(_player.ToString());
        }

        private void StartRoomEncounter(DungeonRoom currentRoom, out bool success)
        {
            success = true;
            if (currentRoom.Loot != null) 
            {
                Console.WriteLine($"You found {currentRoom.Loot.Name}!");
                _player.AddItemToInventory(currentRoom.Loot);
            }
            if (currentRoom.Enemy != null) 
            {
                if (_combatManager.StartCombat(_player, currentRoom.Enemy) == _player)
                {
                    _player.HandleCombatComplete();
                    LootEnemy(currentRoom.Enemy);
                }
                else 
                {
                    success = false;
                }
            }

            void LootEnemy(Unit enemy)
            {
                _player.AddItemsFromUnitToInventory(enemy);
            }
        }

        private void DisplayRouteOptions(DungeonRoom currentRoom)
        {
            Console.WriteLine("Where to go?");
            foreach (var room in currentRoom.Rooms)
            {
                Console.Write($"{room.Key} - {(int) room.Key}\t");
            }
        }

        
        #endregion
    }
}
