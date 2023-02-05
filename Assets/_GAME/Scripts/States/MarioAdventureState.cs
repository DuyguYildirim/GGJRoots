using System.Collections;
using System.Collections.Generic;
using _GAME.Scripts.Events;
using _GAME.Scripts.States;
using Ambrosia.EventBus;
using Ambrosia.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioAdventureState : State
{
    [SerializeField] private GameObject marioGame;
    [SerializeField] private TextAdventureState _textAdventureState;
    [SerializeField] private FpsGameState _fpsGame;
    protected override void OnEnter()
    {
        marioGame.SetActive(true);
        EventBus<GameLoseEvent>.AddListener(OnGameLose);
        EventBus<MarioWinEvent>.AddListener(OnMarioWin);
    }

    protected override void OnExit()
    {
        marioGame.SetActive(false);
        EventBus<GameLoseEvent>.RemoveListener(OnGameLose);
        EventBus<MarioWinEvent>.RemoveListener(OnMarioWin);
    }

    private void OnMarioWin(object sender, MarioWinEvent @event)
    {
        StateMachine.TransitionTo(_fpsGame);
    }

    private void OnGameLose(object sender, GameLoseEvent @event)
    {
        StateMachine.TransitionTo(_textAdventureState);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}