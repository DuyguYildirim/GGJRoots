using Ambrosia.EventBus;
using Ambrosia.StateMachine;
using UnityEngine;

namespace _GAME.Scripts.States
{
    public class TextAdventureState : State
    {
        [SerializeField] private GameObject TextCanvas;

        protected override void OnEnter()
        {
            EventBus<PlayStickmanStateEvent>.AddListener(OnPlayStickmanState);
        }

        protected override void OnExit()
        {
            EventBus<PlayStickmanStateEvent>.RemoveListener(OnPlayStickmanState);
        }

        private void OnPlayStickmanState(object sender, PlayStickmanStateEvent @event)
        {
            TextCanvas.SetActive(false);
            StateMachine.TransitionToNextState();
        }
    }
}