namespace Homework
{
    struct Interval
    {
        private int _min;
        private int _max;
        private Random random = new Random();

        public int Min => _min;
        public int Max => _max;
        public int Get => random.Next(_min, _max);

        public Interval(int minValue, int maxValue)
        {
            if (minValue < 0)
            {
                minValue = 0;
            }
            if (maxValue < 0)
            {
                maxValue = 0;
            }
            if (minValue > maxValue)
            {
                int temp = minValue;
                minValue = maxValue;
                maxValue = temp;
                System.Console.WriteLine("Incorrect input. Maximum value must be greater than Minimal value");
            }
            if (minValue == maxValue)
            {
                maxValue += 10;
            }
            _min = minValue;
            _max = maxValue;
        }

    }
}