using _GAME.Scripts.Events;
using Ambrosia.EventBus;
using Ambrosia.StateMachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _GAME.Scripts.States
{
    public class TextAdventureState : State
    {
        [SerializeField] private GameObject TextCanvas;
        [SerializeField] private GameObject textAdventure;

        [SerializeField] private StickmanAdventureState _stickmanAdventureState;


        protected override void OnEnter()
        {
            textAdventure.SetActive(true);
            EventBus<TextGameWinEvent>.AddListener(OnTextGameWin);
            EventBus<GameLoseEvent>.AddListener(OnGameLose);
        }

        protected override void OnExit()
        {
            textAdventure.SetActive(false);
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
            StateMachine.TransitionTo(_stickmanAdventureState);
        }
    }
}