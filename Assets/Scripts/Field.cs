using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private static Field _instance;
    private List<Rigidbody> Balls = new List<Rigidbody>();
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
    
    public Transform Spawn;

    public bool HasBall
    {
        get => Balls.Count > 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Balls.Add(other.GetComponent<Rigidbody>());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ball")
        {
            Balls.Remove(other.GetComponent<Rigidbody>());
            Destroy(other.gameObject);
        }
    }
}
