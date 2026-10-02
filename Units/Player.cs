using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
using System.Text;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {            
        }

        public override uint GetUnitDamage()
        {
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon && weapon.Durability > 0) 
            {
                weapon.ReduceDurability(1);
                Console.WriteLine($"Durability of your weapon was reduced. Current durability: {weapon.Durability}");
                return BaseDamage + weapon.Damage; 
            }
            return BaseDamage;
        }

        public override void HandleCombatComplete()
        {
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                if (items[i] is EconomicItem economicItem) 
                {
                    if (UseEconomicItem(economicItem))
                    {
                        if (Inventory.TryRemove(items[i]))
                        {
                            i--;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        public override void AddItemToInventory(Item item)
        {
            if (item is EquipItem equipItem) 
            {
                if(_equipment.TryAdd(equipItem.Slot, equipItem))
                {
                    // Item was equipped
                    return;
                }
                else
                {
                    _equipment.TryGetValue(equipItem.Slot, out var oldItem);
                    Console.WriteLine($"Your slot already has {oldItem.Name}. Do you still want to equip {item.Name}? Type \"yes\" to equip. ");
                    string userInput = Console.ReadLine().ToLower();
                    if(userInput == "yes")
                    {
                        if (!Inventory.TryAdd(oldItem))
                        {
                            Console.WriteLine("Inventory is full");
                            return;
                        }
                        _equipment[equipItem.Slot] = equipItem;
                        Console.WriteLine($"You equiped {equipItem.Name}");
                        return;
                    }
                }
            }
            base.AddItemToInventory(item);
        }

        private bool UseEconomicItem(EconomicItem economicItem)
        {
            if (economicItem is HealthPotion healthPotion) 
            {
                Console.WriteLine($"{economicItem.Name} was used. You restored {healthPotion.HealthRestore} health.");
                Health += healthPotion.HealthRestore;
                if(Health > MaxHealth)
                {
                    Health = MaxHealth;
                }
                return true;
            }
            else if (economicItem is Grindstone grindstone) 
            {
                if(_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon && weapon.Durability < weapon.MaxDurability)
                {
                    Console.WriteLine("Your weapon was repaired");
                    weapon.Repair(15);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        protected override uint CalculateAppliedDamage(uint damage)
        {
            if (_equipment.TryGetValue(EquipSlot.Armour, out var item) && item is Armour armour) 
            {
                if(armour.Durability > 0)
                {
                    damage -= (uint)(damage * (armour.Defence / 100f));
                    item.ReduceDurability(1);
                    Console.WriteLine($"Durability of your armor was reduced. Current durability: {armour.Durability}");
                }
                   
            }
            if (_equipment.TryGetValue(EquipSlot.Helmet, out var item2) && item2 is Helmet helmet) 
            {
                if(helmet.Durability > 0)
                {
                    damage -= (uint)(damage * (helmet.Defence / 100f));
                    item2.ReduceDurability(1);
                    Console.WriteLine($"Durability of your armor was reduced. Current durability: {helmet.Durability}");
                }
            }
            
            return damage;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Name);
            builder.AppendLine($"Health {Health}/{MaxHealth}");
            builder.AppendLine("Loot:");
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                builder.AppendLine($"[{items[i].Name}] : {items[i].Amount}");
            }
            return builder.ToString();
        }
    }
}
