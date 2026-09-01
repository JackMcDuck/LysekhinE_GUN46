namespace Homework
{
    class Weapon
    {
        public string Name { get; }
        public Interval DamageInterval { get; private set; }
        public float Durability { get; }

        public Weapon(string name)
        {
            Name = name;
            Durability = 1;
        }

        public Weapon(string name, int minDamage, int maxDamage) : this(name)
        {
            DamageInterval = new Interval(minDamage, maxDamage);
        }

        // public void SetDamageParams(int minDamage, int maxDamage)
        // {
        //     if (minDamage > maxDamage)
        //     {
        //         int temp = minDamage;
        //         minDamage = maxDamage;
        //         maxDamage = temp;
        //         Console.WriteLine($"Значения урона для {Name} заданы некорректно.");
        //     }

        //     if(minDamage < 1)
        //     {
        //         minDamage = 1; //я не понял, что значит "задается значением f"
        //         Console.WriteLine("Минимальное значение задано принудительно: 1.");
        //     }
        //     if(maxDamage <= 1)
        //     {
        //         maxDamage = 10;
        //         Console.WriteLine("Максимальное значение задано принудительно: 10.");
        //     }

        //     MinDamage = minDamage;
        //     MaxDamage = maxDamage;
        // }

        public int GetDamage()
        {
            return (DamageInterval.Min + DamageInterval.Max) / 2;
        }
    }
}