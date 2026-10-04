using System.Text.Json;
using FinalTask.Games;
using FinalTask.Saving;

namespace FinalTask.Casinos
{
    public class Casino : IGame
    {
        private const int MaxBank = 1000000;
        private const int StartBank = 100;
        private const string ProfileId = "profile.txt";
        private const int standartCardsCount = 36;

        private readonly ISaveLoadService<string> _saveLoadService;
        private readonly Dictionary<int, CasinoGameBase> _games;
        private PlayerProfile _profile;
        private int _bet;

        public Casino(ISaveLoadService<string> saveLoadService)
        {
            if(saveLoadService == null)
            {
                throw new ArgumentNullException(nameof(saveLoadService));
            }
            _saveLoadService = saveLoadService;

            _games = new Dictionary<int, CasinoGameBase>
            {
                { 1, new BlackjackGame(standartCardsCount)},
                { 2, new DiceGame(2, 1, 6)}
            };

            foreach(CasinoGameBase game in _games.Values)
            {
                game.OnWin += HandleWin;
                game.OnLoose += HandleLoose;
                game.OnDraw += HandleDraw;
            }
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to casino!");
            LoadProfile();

            CasinoGameBase game = ChooseGame();

            if(_profile.Bank <= 0)
            {
                Console.WriteLine("No money? Kicked!");
            }
            else
            {
                _bet = AskBet();
                game.PlayGame();
            }
            Console.WriteLine($"Goodbye, {_profile.Name}. Your bank account: {_profile.Bank}");
            SaveProfile();
            
        }

        private void LoadProfile()
        {
            string data = _saveLoadService.LoadData(ProfileId);

            if (string.IsNullOrWhiteSpace(data))
            {
                CreateProfile();
                return;
            }

            _profile = JsonSerializer.Deserialize<PlayerProfile>(data);
            Console.WriteLine($"Welcome back, {_profile.Name}! Your bank is {_profile.Bank}");

            if (_profile.Bank > MaxBank)
            {
                _profile.Bank /= 2;
                Console.WriteLine("You wasted half of your bank money in casino’s bar");
            }
        }

        private void CreateProfile()
        {
            Console.Write("Type your name to create profile: ");
            string name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Name must be at least one character long. What is your name? ");
                name = Console.ReadLine();
            }

            _profile = new PlayerProfile
            {
                Name = name.Trim(),
                Bank = StartBank
            };
            Console.WriteLine($"Hello, {_profile.Name}! Your bank is {_profile.Bank}");
        }

        private void SaveProfile()
        {
            _saveLoadService.SaveData(JsonSerializer.Serialize(_profile), ProfileId);
        }

        private CasinoGameBase ChooseGame()
        {
            Console.WriteLine("Choose a game: 1 - Blackjack, 2 - Dice");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice) && _games.TryGetValue(choice, out CasinoGameBase game))
                {
                    return game;
                }

                Console.WriteLine("Unknown command. Type 1 to play Blackjack or 2 to play Dice");
            }
        }

        private int AskBet()
        {
            Console.WriteLine($"Your bank account: {_profile.Bank}. What is your bet? ");

            while (true)
            {
                if(int.TryParse(Console.ReadLine(), out int bet) && bet >= 1 && bet <= _profile.Bank)
                {
                    return bet;
                }

                Console.WriteLine($"Your bet must be between 1 and {_profile.Bank}");
            }
        }

        private void HandleWin()
        {
            long total = (long)_profile.Bank + _bet;
            Console.WriteLine($"You win {_bet}!");

            if (total > MaxBank)
            {
                long remainder = total - MaxBank;
                Console.WriteLine($"Casino is bankrupt and will be required to pay you ${remainder}. A new casino will be open shortly");
            }
            else
            {
                _profile.Bank = (int)total;
            }
        }

        private void HandleLoose()
        {
            _profile.Bank -= _bet;
            Console.WriteLine($"You lose {_bet}");
        }

        private void HandleDraw()
        {
            Console.WriteLine("Draw! Your bet is returned to your bank");
        }
    }
}