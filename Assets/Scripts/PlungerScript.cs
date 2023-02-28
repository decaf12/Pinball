using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlungerScript : MonoBehaviour
{
    private float power;
    private float minPower = 0f;
    public float maxPower = 100f;
    public Slider powerSlider;
    List<Rigidbody> ballList;
    private bool ballReady;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("printing test");
        powerSlider.minValue = minPower;
        powerSlider.maxValue = maxPower;
        ballList = new List<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ballReady = ballList.Count > 0;
        powerSlider.gameObject.SetActive(ballReady);
        
        powerSlider.value = power;

        if (ballReady)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (power <= maxPower)
                {
                    Debug.Log("Powering up");
                    power += 50 * Time.deltaTime;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                Debug.Log("Launch!");

                foreach (Rigidbody r in ballList)
                {
                    r.AddForce(power * Vector3.forward);
                }
            }

        }
        else
        {
            power = minPower;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"other: {other.ToString()}");
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Remove(other.gameObject.GetComponent<Rigidbody>());
            power = 0f;
        }
    }
}
