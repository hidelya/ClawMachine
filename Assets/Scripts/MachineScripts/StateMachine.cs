using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState;
    [SerializeField] private MovementPince movementScript;
    [SerializeField] private StretchingPince stretchingScript;
    [SerializeField] private AnimationBall animationBallScript;
    [SerializeField] private PlayerStats playerStatsScript;
    [SerializeField] private ObjectToPickUp objectToPickUpScript;
    [SerializeField] private BallSpawner ballSpawnerScript;
    [SerializeField] private CameraEffect cameraEffectScript;
    [SerializeField] private Card cardScript;
    [SerializeField] private CoinAnim coinAnimScript;
    private GameObject ballPicked;
    [SerializeField] private GameObject buttonCoin;
    [SerializeField] private GameObject bigButton;

    private bool isFirstBallInstanciated = false;

    public enum State
    {
        WaitingForCoin,
        Moving,
        Grabbing,
        CheckingReward,
        WaitChoice
    }

    public void Update()
    {
        switch (currentState)
        {
            case State.WaitingForCoin:

                cameraEffectScript.DezoomCamera();
                movementScript.enabled = false;
                stretchingScript.enabled = false;
                objectToPickUpScript.isAttached = false;
                stretchingScript.isDown = false;
                if (isFirstBallInstanciated == false)
                {
                    ballSpawnerScript.SpawnBall(new Vector3(-4, 3, 0));
                    ballSpawnerScript.SpawnBall(new Vector3(0, 3, 0));
                    ballSpawnerScript.SpawnBall(new Vector3(4, 3, 0));

                    isFirstBallInstanciated = true;
                }


                if (buttonCoin.GetComponent<ButtonState>().IsPressed)
                {
                    coinAnimScript.AnimCoin();
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
                    //stretchingScript.StartDescente();
                }

                break;

            case State.Grabbing:

                movementScript.enabled = false;
                if (stretchingScript.isDown == true)
                {
                    if (objectToPickUpScript.isAttached) { currentState = State.CheckingReward; }
                    else if (!objectToPickUpScript.isAttached) { currentState = State.Moving; }
                }
                break;

            case State.CheckingReward:

                ballPicked = objectToPickUpScript.ballPick;
                animationBallScript.StartAnimation();
                cameraEffectScript.ZoomCamera();

                if (animationBallScript.isAnimationFinished == true)
                {
                    ballSpawnerScript.SpawnBall();
                    cardScript.SpawnCard();
                    currentState = State.WaitChoice;
                }
                
                break;

            case State.WaitChoice:

                if (cardScript.cardIsActived == false)
                {
                    currentState = State.WaitingForCoin;
                }
                break;
        }
    }
}
