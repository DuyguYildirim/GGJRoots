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
    protected override void OnEnter()
    {
        marioGame.SetActive(true);
        EventBus<GameLoseEvent>.AddListener(OnGameLose);
    }

    protected override void OnExit()
    {
        marioGame.SetActive(false);
        EventBus<GameLoseEvent>.RemoveListener(OnGameLose);
    }

    private void OnGameLose(object sender, GameLoseEvent @event)
    {
        StateMachine.TransitionTo(_textAdventureState);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}