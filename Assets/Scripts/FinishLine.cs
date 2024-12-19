using UnityEngine;
public class FinishLine : MonoBehaviour
{
    [SerializeField]
    float LoadDelay = 1f;
    [SerializeField]
    ParticleSystem FinishEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FinishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("Reload", LoadDelay);
        }
    }

    public void Reload()
    {
        GameManager.Instance.Win();
    }
}
