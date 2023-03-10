using _GAME.Scripts.Events;
using _GAME.Scripts.States;
using Ambrosia.EventBus;
using Ambrosia.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StickmanAdventureState : State
{
    [SerializeField] private TextAdventureState _textAdventureState;
    [SerializeField] private MarioAdventureState _marioAdventureState;
    [SerializeField] private GameObject stickmanAdventure;

    protected override void OnEnter()
    {
        stickmanAdventure.SetActive(true);
        EventBus<GameLoseEvent>.AddListener(OnGameLose);
        EventBus<StickManGameWinEvent>.AddListener(OnStickManGameWin);
    }

    protected override void OnExit()
    {
        stickmanAdventure.SetActive(false);
        EventBus<GameLoseEvent>.RemoveListener(OnGameLose);
        EventBus<StickManGameWinEvent>.RemoveListener(OnStickManGameWin);
    }

    private void OnStickManGameWin(object sender, StickManGameWinEvent @event)
    {
        StateMachine.TransitionTo(_marioAdventureState);
    }

    private void OnGameLose(object sender, GameLoseEvent @event)
    {
        StateMachine.TransitionTo(_textAdventureState);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}