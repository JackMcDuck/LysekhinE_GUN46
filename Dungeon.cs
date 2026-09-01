namespace Homework
{
    class Dungeon
    {
        private Room[] _rooms;

        public Dungeon()
        {
            _rooms = new Room[]
            {
                new Room (new Unit("Knight"), new Weapon("Sword")),
                new Room (new Unit("Archer"), new Weapon("Bow")),
                new Room (new Unit("Skeleton"), new Weapon("Bone"))
            };
        }

        public void ShowRooms()
        {
            for (int i = 0; i < _rooms.Length; i++)
            {
                var room = _rooms[i];
                Console.WriteLine("Unit of room " + room.NewUnit.Name);
                Console.WriteLine("Weapon of room " + room.NewWeapon.Name);
                Console.WriteLine("-");
            }
        }

    }
}