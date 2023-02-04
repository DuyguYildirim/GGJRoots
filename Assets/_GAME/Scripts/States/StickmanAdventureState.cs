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
        stickmanAdventure.SetActive(true);
        EventBus<GameLoseEvent>.AddListener(OnGameLose);
    }

    protected override void OnExit()
    {
        stickmanAdventure.SetActive(false);
        EventBus<GameLoseEvent>.RemoveListener(OnGameLose);
    }

    private void OnGameLose(object sender, GameLoseEvent @event)
    {
        StateMachine.TransitionTo(_textAdventureState);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}