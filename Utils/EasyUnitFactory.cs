using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public class EasyUnitFactory: UnitFactoryDemo
    {
        public override Unit CreatePlayer(string name)
        {
            var player = new Player(name, 40, 40, 10);
            player.AddItemToInventory(new Weapon(10, 15, "Sword"));
            player.AddItemToInventory(new Armour(10, 15, "Armour"));
            player.AddItemToInventory(new HealthPotion("Potion"));
            player.AddItemToInventory(new Grindstone("Stone"));
            return player;
        }

        public override Unit CreateEnemy()
        {
            return new Goblin(GameConstants.Goblin, 20, 20, 5);
        }
    }
}