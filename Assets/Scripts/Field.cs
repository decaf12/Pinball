using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private static Field _instance;
    public Transform Spawn;
    public static Field instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<Field>();
            }
            return _instance;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ball")
        {
            BallScript ball = other.gameObject.GetComponent<BallScript>();
            GetComponent<AudioSource>().PlayOneShot(ball.DeathJingle);
            BallList.instance.Remove(ball);
        }
    }

    public void ResetGame()
    {
        BallList.instance.RemoveAll();
    }
}
