using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlungerScript : MonoBehaviour
{
    private float power;
    private float minPower = 0f;
    public float maxPower = 100f;
    public Slider powerSlider;
    private bool ballReady;

    // Start is called before the first frame update
    void Start()
    {
        powerSlider.minValue = minPower;
        powerSlider.maxValue = maxPower;
    }

    // Update is called once per frame
    void Update()
    {
        ballReady = BallList.instance.HasBalls();
        powerSlider.gameObject.SetActive(ballReady && !BallList.instance.HasMovingBalls());
        
        powerSlider.value = power;

        if (ballReady)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (power <= maxPower)
                {
                    power += 50 * Time.deltaTime;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                BallList.instance.Map(r => r.GetComponent<Rigidbody>().AddForce(power * Vector3.forward));
            }

        }
        else
        {
            power = minPower;
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Ball"))
    //     {
    //         BallList.instance.Add(other.gameObject.GetComponent<BallScript>());
    //     }
    // }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            power = minPower;
        }
    }
}
