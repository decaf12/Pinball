using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject BallPrefab;
    void Update()
    {
        if (!BallList.instance.HasBalls())
        {
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        GameObject newBall = Instantiate(BallPrefab, Field.instance.Spawn);
        BallList.instance.Add(newBall.GetComponent<BallScript>());
    }
}
