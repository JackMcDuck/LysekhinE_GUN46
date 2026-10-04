namespace FinalTask.Games
{
    public abstract class CasinoGameBase
    {
        protected int[] Settings {get; }

        protected CasinoGameBase(params int[] settings)
        {
            Settings = settings;
            FactoryMethod();
        }

        public event Action OnWin;
        public event Action OnLoose;
        public event Action OnDraw;

        public abstract void PlayGame();

        protected abstract void FactoryMethod();

        protected void OnWinInvoke()
        {
            OnWin?.Invoke();
        }
        protected void OnLooseInvoke()
        {
            OnLoose?.Invoke();
        }
        protected void OnDrawInvoke()
        {
            OnDraw?.Invoke();
        }
    }
}