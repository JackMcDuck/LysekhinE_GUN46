using System.Security.Cryptography;
using FinalTask.Cards;

namespace FinalTask.Games
{
    public class BlackjackGame : CasinoGameBase
    {
        private const int StartHandCount = 2;
        private const int MinCardsCount = 8;
        private const int MaxCardsCount = 36;
        private const int TargetScore = 21;

        private readonly Random _random = new();
        private readonly List<Card> _cards = new();
        private readonly Queue<Card> _deck = new();

        public BlackjackGame(int cardsCount) : base(CheckCardsCount(cardsCount))
        {
        }

        public override void PlayGame()
        {
            Shuffle();

            List<Card> player = DrawCards(StartHandCount);
            List<Card> computer = DrawCards(StartHandCount);

            while (true)
            {
                int playerScore = CountScore(player);
                int computerScore = CountScore(computer);

                ShowHands(player, playerScore, computer, computerScore);

                if (playerScore == computerScore && playerScore < TargetScore)
                {
                    Console.WriteLine("Scores are equal. Draw one more card");
                    player.Add(DrawOneCard());
                    computer.Add(DrawOneCard());
                    continue;
                }

                if (playerScore <= TargetScore && (computerScore < playerScore || computerScore > TargetScore))
                {
                    OnWinInvoke();
                }
                else if (computerScore <= TargetScore && (playerScore < computerScore || playerScore > TargetScore))
                {
                    OnLooseInvoke();
                }
                else
                {
                    OnDrawInvoke();
                }

                return;
            }
        }

        private void Shuffle()
        {
            _deck.Clear();
            foreach (Card card in _cards.OrderBy(random => _random.Next()))
            {
                _deck.Enqueue(card);
            }
        }

        private List<Card> DrawCards(int count)
        {
           List<Card> hand = new();

           for (int i = 0; i < count; i++)
            {
                hand.Add(DrawOneCard());
            }

            return hand;
        }

        private Card DrawOneCard()
        {
            if (_deck.Count == 0)
            {
                Shuffle();
            }

            return _deck.Dequeue();
        }

        private int CountScore(List<Card> hand)
        {
            int score = 0;
            int aces = 0;

            foreach (Card card in hand)
            {
                switch (card.Rank)
                {
                    case Rank.Ace:
                        score += 11;
                        aces++;
                        break;
                    case Rank.Jack:
                    case Rank.Queen:
                    case Rank.King:
                        score += 10;
                        break;
                    default:
                        score += (int)card.Rank;
                        break;
                }
            }

            while (score > TargetScore && aces > 0)
            {
                score -= 10;
                aces--;
            }

            return score;
        }

        private void ShowHands(List<Card> player, int playerScore, List<Card> computer, int computerScore)
        {
            Console.WriteLine($"Your cards: {string.Join(", ", player)}= {playerScore}");
            Console.WriteLine($"Computer cards: {string.Join(", ", computer)}= {computerScore}");
        }

        protected override void FactoryMethod()
        {
            Suit[] suits = Enum.GetValues<Suit>();
            Rank[] ranks = Enum.GetValues<Rank>();

            for (int i = 0; i < Settings[0]; i++)
            {
                _cards.Add(new Card(suits[i % suits.Length], ranks[i / suits.Length % ranks.Length]));
            }
        }

        private static int CheckCardsCount(int cardsCount)
        {
            if(cardsCount < MinCardsCount || cardsCount > MaxCardsCount)
            {
                throw new ArgumentException(nameof(cardsCount), $"Cards count must be between {MinCardsCount} and {MaxCardsCount}");
            }
            return cardsCount;
        }
    }

}