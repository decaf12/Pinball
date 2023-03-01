using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject BallPrefab;
    void Update()
    {
        if (!Field.instance.HasBall)
        {
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        Instantiate(BallPrefab, Field.instance.Spawn);
    }
}
