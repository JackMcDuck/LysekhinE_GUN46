using FinalTask.Dices;

namespace FinalTask.Games
{
    public class DiceGame : CasinoGameBase
    {
        private readonly List<Dice> _dice = new();

        public DiceGame(int diceCount, int min, int max) : base (CheckDiceCount(diceCount), min, max)
        {
        }

        public override void PlayGame()
        {
            List<int> player = RollDice();
            List<int> computer = RollDice();

            int playerScore = player.Sum();
            int computerScore = computer.Sum();

            ShowDiceScore(player, playerScore, computer, computerScore);

            if(playerScore > computerScore)
            {
                OnWinInvoke();
            }
            else if (computerScore > playerScore)
            {
                OnLooseInvoke();
            }
            else
            {
                OnDrawInvoke();
            }
        }

        protected override void FactoryMethod()
        {
            for (int i = 0; i < Settings[0]; i++)
            {
                _dice.Add(new Dice(Settings[1], Settings[2]));
            }
        }

        private static int CheckDiceCount(int diceCount)
        {
            if(diceCount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(diceCount), "Dice must be greater than 1");
            }
            return diceCount;
        }

        private List<int> RollDice()
        {
            return _dice.Select(dice => dice.Number).ToList();
        }

        private void ShowDiceScore(List<int> player, int playerScore, List<int> computer, int computerScore)
        {
            Console.WriteLine($"Your score: {string.Join("+ ", player)} = {playerScore}");
            Console.WriteLine($"Computer score: {string.Join("+ ", computer)} = {computerScore}");
        }
    }
}