using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;

namespace GamePrototype.Utils
{
    public abstract class DungeonBuilder
    {
        protected UnitFactoryDemo UnitFactory { get; }

        protected DungeonBuilder(UnitFactoryDemo unitFactory)
        {
            UnitFactory = unitFactory;
        }

        public abstract DungeonRoom BuildDungeon();
    }
}
