using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    [SerializeField]
    float LoadDelay = .5f;
    [SerializeField]
    ParticleSystem CrashParticle;

    [SerializeField]
    AudioClip _audioClip;


    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            PlayerController.Instance.DisableControls();

            CrashParticle.Play();
            GetComponent<AudioSource>().PlayOneShot(_audioClip);

            Invoke("Reload", LoadDelay);
        }
    }

    public void Reload()
    {
        GameManager.Instance.Dead();
    }
}
