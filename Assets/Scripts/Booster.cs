using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    private static Booster _instance;
    public static Booster instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<Booster>();
            }
            return _instance;
        }
    }
}
