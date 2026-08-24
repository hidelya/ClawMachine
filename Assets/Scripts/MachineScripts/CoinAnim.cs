using System.Collections;
using UnityEngine;

public class CoinAnim : MonoBehaviour
{
    [SerializeField] GameObject coin;
    //[SerializeField] float speed;
    //[SerializeField] float positionx;

    public void AnimCoin()
    {
        coin.SetActive(true);
        StartCoroutine(StopAnimCoin(coin));

    }

    IEnumerator StopAnimCoin(GameObject coin)
    {
        yield return new WaitForSeconds(1.5f);
        coin.SetActive(false);
    }
}
