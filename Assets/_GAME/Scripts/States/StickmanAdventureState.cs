using _GAME.Scripts.Events;
using Ambrosia.EventBus;
using Ambrosia.StateMachine;
using UnityEngine.SceneManagement;

public class StickmanAdventureState : State
{
    protected override void OnEnter()
    {
       EventBus<GameLoseEvent>.AddListener(OnGameLose);
    }

    protected override void OnExit()
    {
        EventBus<GameLoseEvent>.RemoveListener(OnGameLose);
    }

    private void OnGameLose(object sender, GameLoseEvent @event)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}