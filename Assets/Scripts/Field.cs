using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private static Field _instance;
    public Transform Spawn;
    private List<BallScript> Balls = new List<BallScript>();
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
    

    public bool HasBall
    {
        get => GameObject.FindWithTag("Ball");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Balls.Add(other.GetComponent<BallScript>());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ball")
        {
            BallScript ball = other.gameObject.GetComponent<BallScript>();
            GetComponent<AudioSource>().PlayOneShot(ball.DeathJingle);
            Balls.Remove(ball);
            Destroy(other.gameObject);
        }
    }

    public void ResetGame()
    {
        Balls.ForEach(ball => Destroy(ball.gameObject));
        Balls.Clear();
    }
}
