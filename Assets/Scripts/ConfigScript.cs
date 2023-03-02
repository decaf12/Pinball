using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigScript : MonoBehaviour
{
    private static ConfigScript _instance;
    private static float DefaultBoost = 20f;
    private static float BoostMultiplier = 1f;
    public static ConfigScript instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<ConfigScript>();
            }
            return _instance;
        }
    }

    public float GetBoostMultiplier
    {
        get
        {
            return DefaultBoost * BoostMultiplier;
        }
    }

    public void SetBoostMultiplier(float newMultiplier)
    {
        BoostMultiplier = newMultiplier;
    }
}