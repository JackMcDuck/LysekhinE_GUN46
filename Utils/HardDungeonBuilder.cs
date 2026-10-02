using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;

namespace GamePrototype.Utils
{
    public  class HardDungeonBuilder: DungeonBuilder
    {
        public HardDungeonBuilder(UnitFactoryDemo unitFactory): base(unitFactory)
        {
        }

        public override DungeonRoom BuildDungeon()
        {
            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", UnitFactory.CreateEnemy());
            var monsterRoom2 = new DungeonRoom("Monster", UnitFactory.CreateEnemy());
            
            var weaponRoom = new DungeonRoom("Weapon", new RangeWeapon(20, 20, "Spear"));
            var lootRoom = new DungeonRoom("Loot1", new Gold());
            var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));
            var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

            enter.TrySetDirection(Direction.Right, monsterRoom);
            enter.TrySetDirection(Direction.Forward, monsterRoom);
            enter.TrySetDirection(Direction.Left, weaponRoom);

            monsterRoom.TrySetDirection(Direction.Right, monsterRoom2);
            monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
            monsterRoom.TrySetDirection(Direction.Left, weaponRoom);

            monsterRoom2.TrySetDirection(Direction.Left, lootRoom);
            monsterRoom2.TrySetDirection(Direction.Forward, lootStoneRoom);

            weaponRoom.TrySetDirection(Direction.Forward, lootStoneRoom);

            lootRoom.TrySetDirection(Direction.Forward, finalRoom);
            lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);

            return enter;
        }
    }
}