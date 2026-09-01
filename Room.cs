namespace Homework
{
    struct Room
    {
        private Unit _unit;
        private Weapon _weapon;

        public Unit NewUnit => _unit;
        public Weapon NewWeapon => _weapon;


        public Room (Unit unit, Weapon weapon)
        {
            _unit = unit;
            _weapon = weapon;
        }
    }
}