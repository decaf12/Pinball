using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject BallPrefab;
    private static float Cooldown = 0f;

    void Update()
    {
        if (!Field.instance.HasBall)
        {
            Cooldown += 0.1f;
            if (Cooldown > 0.8f)
            {
                Cooldown = 0;
                SpawnBall();
            }
        }
    }

    private void SpawnBall()
    {
        Instantiate(BallPrefab, Field.instance.Spawn);
    }
}
