using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject BallPrefab;
    private static int BallCount = 0;

    void Update()
    {
        if (!Field.instance.HasBall)
        {
            print($"Spawning ball #{++BallCount}");
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        Instantiate(BallPrefab, Field.instance.Spawn);
    }
}
