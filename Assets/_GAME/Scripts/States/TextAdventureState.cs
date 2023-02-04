using _GAME.Scripts.Events;
using Ambrosia.EventBus;
using Ambrosia.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _GAME.Scripts.States
{
    public class TextAdventureState : State
    {
        [SerializeField] private GameObject TextCanvas;

        protected override void OnEnter()
        {
            EventBus<TextGameWinEvent>.AddListener(OnTextGameWin);
            EventBus<GameLoseEvent>.AddListener(OnGameLose);
        }

        protected override void OnExit()
        {
            EventBus<TextGameWinEvent>.RemoveListener(OnTextGameWin);
            EventBus<GameLoseEvent>.RemoveListener(OnGameLose);
        }

        private void OnGameLose(object sender, GameLoseEvent @event)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void OnTextGameWin(object sender, TextGameWinEvent @event)
        {
            TextCanvas.SetActive(false);
            StateMachine.TransitionToNextState();
        }
    }
}