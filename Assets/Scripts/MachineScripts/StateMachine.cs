using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState;
    [SerializeField] private MovementPince movementScript;
    [SerializeField] private stretchingPince stretchingScript;
    [SerializeField] private AnimationBall animationBallScript;
    [SerializeField] private PlayerStats playerStatsScript;
    [SerializeField] private ObjectToPickUp objectToPickUpScript;
    [SerializeField] private BallSpawner ballSpawnerScript;

    private GameObject ballPicked;
    [SerializeField] private GameObject buttonCoin;
    [SerializeField] private GameObject bigButton;

    private bool isFirstBallInstanciated = false;

    public enum State
    {
        WaitingForCoin,
        Moving,
        Grabbing,
        CheckingReward
    }

    public void Update()
    {
        switch (currentState)
        {
            case State.WaitingForCoin:

                movementScript.enabled = false;
                stretchingScript.enabled = false;
                objectToPickUpScript.isAttached = false;
                stretchingScript.isDown = false;
                if (isFirstBallInstanciated == false)
                {
                    ballSpawnerScript.SpawnBall(new Vector3(-4, 1, 0));
                    ballSpawnerScript.SpawnBall(new Vector3(0, 1, 0));
                    ballSpawnerScript.SpawnBall(new Vector3(4, 1, 0));

                    isFirstBallInstanciated = true;
                }
                
                
                if (buttonCoin.GetComponent<ButtonState>().IsPressed)
                {
                    Debug.Log("Coin inserted, moving to Moving state");
                    playerStatsScript.RemoveCoins(1);
                    currentState = State.Moving;
                }

                break;

            case State.Moving:

                movementScript.enabled = true;
                stretchingScript.enabled = true;

                if (bigButton.GetComponent<ButtonState>().IsPressed)
                {
                    currentState = State.Grabbing;
                    stretchingScript.StartDescente();
                }

                break;

            case State.Grabbing:
                movementScript.enabled = false;
                if (stretchingScript.isDown == true)
                {
                    currentState = State.CheckingReward;
                }

                break;

            case State.CheckingReward:


                ballPicked = objectToPickUpScript.ballPick;

                animationBallScript.StartAnimation();

                if (animationBallScript.isAnimationFinished == true)
                {

                    animationBallScript.PriceBall(ballPicked);
                    ballSpawnerScript.SpawnBall();
                    currentState = State.WaitingForCoin;

                }



                break;
        }
    }
}
