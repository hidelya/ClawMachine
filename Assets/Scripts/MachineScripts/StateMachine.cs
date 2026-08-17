using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState;
    [SerializeField] private MovementPince movementScript;
    [SerializeField] private stretchingPince stretchingScript;
    [SerializeField] private AnimationBall animationBallScript;

    public enum State
    {
        WaitingForCoin,
        Moving,
        Grabbing,
        CheckingReward
    }

    public void Update()
    {
        switch(currentState)
            {
                case State.WaitingForCoin:
                    movementScript.enabled = false;
                    stretchingScript.enabled = false;
                    animationBallScript.enabled = false;
                break;
                case State.Moving:
                    movementScript.enabled = true;
                    stretchingScript.enabled = true;
                break;
                case State.Grabbing:
                    movementScript.enabled = false;

                break;
                case State.CheckingReward:
                    
                    animationBallScript.enabled = true;
                break;
        }
    }
}
