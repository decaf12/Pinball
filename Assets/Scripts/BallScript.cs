using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float multiplier = 20f;
    public AudioClip DeathJingle;
    void OnCollisionEnter(Collision other)
    {
        Booster booster = other.gameObject.GetComponent<Booster>();

        if (booster != null)
        {
            Vector3 direction = other.contacts[0].point - transform.position;
            direction = -direction.normalized;
            GetComponent<Rigidbody>().AddForce(direction * booster.GetMultiplier);
        }
    }

    public void PlayDeathJingle()
    {
        GetComponent<AudioSource>().PlayOneShot(DeathJingle);
    }
}
