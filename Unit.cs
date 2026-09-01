using Homework;

class Unit
{
    private float _health;

    public string Name { get; }
    public float Health => _health;
    public Interval Damage { get; }
    public float Armor { get; }

    public Unit (string name, int minDamage, int maxDamage)
    {
        Name = name;
        Damage = new Interval(minDamage, maxDamage);
    }

    public Unit(string name)
    {
        Name = name;
        Damage = new Interval(0, 10);
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
        _health -= value * Armor;
        return _health <= 0f;
    }
}

class Program
{
    static void Main()
    {
        Dungeon dungeon = new Dungeon();
        dungeon.ShowRooms();
    }
}