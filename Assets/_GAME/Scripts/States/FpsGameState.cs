using System.Collections;
using _GAME.Scripts.Events;
using Ambrosia.EventBus;
using UnityEngine;
using UnityEngine.SceneManagement;
using State = Ambrosia.StateMachine.State;

namespace _GAME.Scripts.States
{
    public class FpsGameState : State
    {
        [SerializeField] private GameObject fpsGame;
        [SerializeField] private SkyrimAdventureState _skyrimAdventureState;
        [SerializeField] private TextAdventureState _textAdventureState;

        protected override void OnEnter()
        {
            fpsGame.SetActive(true);
            StartCoroutine(WaitAndPrint(600));
            EventBus<FpsGameWinEvent>.AddListener(OnFpsGameWin);
            EventBus<FpsGameLoseEvent>.AddListener(OnLose);
        }

        protected override void OnExit()
        {
            fpsGame.SetActive(false);
            EventBus<FpsGameWinEvent>.RemoveListener(OnFpsGameWin);
            EventBus<FpsGameLoseEvent>.RemoveListener(OnLose);
        }

        private void OnLose(object sender, FpsGameLoseEvent @event)
        {
            StateMachine.TransitionTo(_textAdventureState);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void OnFpsGameWin(object sender, FpsGameWinEvent @event)
        {
            StateMachine.TransitionTo(_skyrimAdventureState);
        }
        
        IEnumerator WaitAndPrint(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            StateMachine.TransitionTo(_skyrimAdventureState);
        }
    }
}