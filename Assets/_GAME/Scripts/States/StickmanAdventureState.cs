using _GAME.Scripts.Events;
using _GAME.Scripts.States;
using Ambrosia.EventBus;
using Ambrosia.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StickmanAdventureState : State
{
    [SerializeField] private TextAdventureState _textAdventureState;
    [SerializeField] private GameObject stickmanAdventure;

    protected override void OnEnter()
    {
        EventBus<GameLoseEvent>.AddListener(OnGameLose);
        stickmanAdventure.SetActive(true);
    }

    protected override void OnExit()
    {
        EventBus<GameLoseEvent>.RemoveListener(OnGameLose);
        stickmanAdventure.SetActive(false);
    }

    private void OnGameLose(object sender, GameLoseEvent @event)
    {
        StateMachine.TransitionTo(_textAdventureState);
    }
}