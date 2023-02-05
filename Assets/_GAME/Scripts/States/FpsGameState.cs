using Ambrosia.StateMachine;
using UnityEngine;

namespace _GAME.Scripts.States
{
    public class FpsGameState : State
    {
        [SerializeField] private GameObject fpsGame;

        protected override void OnEnter()
        {
            fpsGame.SetActive(true);
        }

        protected override void OnExit()
        {
            fpsGame.SetActive(false);
        }
    }
}