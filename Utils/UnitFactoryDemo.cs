using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public abstract class UnitFactoryDemo
    {
        // public static Unit CreatePlayer(string name)
        // {
        //     var player = new Player(name, 40, 40, 10);
        //     player.AddItemToInventory(new Weapon(10, 15, "Sword"));
        //     player.AddItemToInventory(new Armour(10, 15, "Armour"));
        //     player.AddItemToInventory(new HealthPotion("Potion"));
        //     player.AddItemToInventory(new Grindstone("Stone"));
        //     return player;
        // }

        // public static Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 30, 30, 15);
        public abstract Unit CreatePlayer(string name);
        public abstract Unit CreateEnemy();
    }
}
