/*
class Unit
{
    private float _health;

    public string Name { get; }
    public float Health => _health;
    public int Damage { get; }
    public float Armor { get; }

    public Unit(string name)
    {
        Name = name;
        Damage = 5;
        Armor = 0.6f;
        _health = 100f;
    }

    public Unit() : this("Unknown Unit")
    {
    }

    public float GetRealHealth()
    {
        return Health * (1f + Armor);
    }

    public bool SetDamage(float value)
    {
        _health -= - value * Armor;
        return _health <= 0f;
    }
}
*/

class Weapon
{
    public string Name { get; }
    public int MinDamage { get; private set; }
    public int MaxDamage { get; private set; }
    public float Durability { get; }

    public Weapon(string name)
    {
        Name = name;
        Durability = 1;
    }

    public Weapon(string name, int minDamage, int maxDamage) : this(name)
    {
        SetDamageParams(minDamage, maxDamage);
    }

    public void SetDamageParams(int minDamage, int maxDamage)
    {
        if (minDamage > maxDamage)
        {
            int temp = minDamage;
            minDamage = maxDamage;
            maxDamage = temp;
            Console.WriteLine($"Значения урона для {Name} заданы некорректно.");
        }

        if(minDamage < 1)
        {
            minDamage = 1; //я не понял, что значит "задается значением f"
            Console.WriteLine("Минимальное значение задано принудительно: 1.");
        }
        if(maxDamage <= 1)
        {
            maxDamage = 10;
            Console.WriteLine("Максимальное значение задано принудительно: 10.");
        }

        MinDamage = minDamage;
        MaxDamage = maxDamage;
    }

    public int GetDamage()
    {
        return (MinDamage + MaxDamage) / 2;
    }
}