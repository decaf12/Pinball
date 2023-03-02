using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlungerScript : MonoBehaviour
{
    private float power;
    private float minPower = 0f;
    public float maxPower = 100f;
    public Slider PowerSlider;
    public AudioClip LaunchSound;
    private bool ballReady;

    // Start is called before the first frame update
    void Start()
    {
        PowerSlider.minValue = minPower;
        PowerSlider.maxValue = maxPower;
        gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ballReady = BallList.instance.HasBalls();
        PowerSlider.gameObject.SetActive(ballReady && !BallList.instance.HasMovingBalls());
        
        PowerSlider.value = power;

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
                GetComponent<AudioSource>().PlayOneShot(LaunchSound);
            }

        }
        else
        {
            power = minPower;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            power = minPower;
        }
    }
}
