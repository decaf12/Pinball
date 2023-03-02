using UnityEngine;

public class BallScript : MonoBehaviour
{
    [Header("Booster Multiplier")]
    public float multiplier = 20f;

    [Header("Sound Effects")]
    public AudioClip CoinJingle;
    public AudioClip CollisionJingle;
    public AudioClip DeathJingle;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Booster>() != null)
        {
            Vector3 direction = other.contacts[0].point - transform.position;
            direction = -direction.normalized;
            GetComponent<Rigidbody>().AddForce(direction * ConfigScript.instance.GetBoostMultiplier);
            GetComponent<AudioSource>().PlayOneShot(CoinJingle);
        }
        else if (!other.gameObject.CompareTag("NoCollisionSound"))
        {
            GetComponent<AudioSource>().PlayOneShot(CollisionJingle);
        }
    }

    public void PlayDeathJingle()
    {
        GetComponent<AudioSource>().PlayOneShot(DeathJingle);
    }
}
