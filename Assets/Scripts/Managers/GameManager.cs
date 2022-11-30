using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private bool gameEnded = false;
        public static bool isPaused { get; private set; }
        [SerializeField]
        static Manager[] managers;

        public GameManager()
        {
            managers = new Manager[]
            {
                new ActorManager()
            };
        }

        public static void Pause()
        {
            isPaused = !isPaused;

            for (int i = 0; i < managers.Length; i++)
                managers[i].Pause();
        }

        private void Update()
        {
            if (gameEnded)
                return;

            if (PlayerStats.Lives <= 0)
            {
                EndGame();
            }
        }

        private void Start()
        {
            for (int i = 0; i < managers.Length; i++)
                managers[i].Start();
        }

        void EndGame()
        {
            gameEnded = true;
            Debug.Log("GAMEOVER!");
        }
    }

    public enum Layer
    {
        Enemies = 8,
        Nodes = 10,
    }
}
