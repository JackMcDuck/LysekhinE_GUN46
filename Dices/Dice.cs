using FinalTask.Exceptions;

namespace FinalTask.Dices
{
    public readonly struct Dice
    {
        private static readonly Random random = new();

        private readonly int _min;
        private readonly int _max;

        public int Number => (int)random.NextInt64(_min, (long)_max + 1);

        public Dice(int min, int max)
        {
            if(min < 1 || max < min || max > int.MaxValue)
            {
                throw new WrongDiceNumberException("Wrong dice number.");
            }

            _min = min;
            _max = max;
        }
    }
}