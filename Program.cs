using FinalTask.Casinos;
using FinalTask.Saving;

namespace FinalTask
{
    class Program
    {
        static void Main()
        {
            IGame casino = new Casino(new FileSystemSaveLoadService("Saves"));
            casino .StartGame();
        }
    }
}