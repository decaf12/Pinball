using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallList : MonoBehaviour
{
    private static BallList _instance;
    private List<BallScript> list = new List<BallScript>();
    public static BallList instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<BallList>();
            }
            return _instance;
        }
    }
    
    public void Add(BallScript newBall)
    {
        list.Add(newBall);
    }

    public void RemoveAll()
    {
        Map(ball => Destroy(ball.gameObject));
        list.Clear();
    }

    public void Remove(BallScript killBall)
    {
        list.Remove(killBall);
        Destroy(killBall);
    }
    public bool HasMovingBalls()
    {
        return list.Any(ball => ball.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 0);
    }

    public bool HasBalls()
    {
        return list.Count > 0;
    }

    public void Map(Action<BallScript> action)
    {
        list.ForEach(action);
    }
}
