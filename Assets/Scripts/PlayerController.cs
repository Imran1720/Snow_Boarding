using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField]
    float _torque;
    [SerializeField]
    ParticleSystem DustParticle;

    [SerializeField]
    float boostSpeed = 30;
    [SerializeField]
    float BaseSpeed;

    SurfaceEffector2D SurfaceEffector;

    Rigidbody2D rb2d;

    public bool _leftturn, _rightturn, _isBoosting;
    bool _canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        _leftturn = false;
        _rightturn = false;
        _isBoosting = false;
        _canMove = true;
        rb2d = GetComponent<Rigidbody2D>();
        SurfaceEffector = FindObjectOfType<SurfaceEffector2D>();

    }

    private void FixedUpdate()
    {
        if (_canMove)
        {
            RotatePlayer();
        }
    }
    // Up
    // date is called once per frame
    void Update()
    {
        if (_canMove)
        {

            Boost();

        }
    }

    public void DisableControls()
    {
        _canMove = false;
    }
    private void Boost()
    {
        if (Input.GetKey(KeyCode.LeftShift) || _isBoosting)
        {

            SurfaceEffector.speed = boostSpeed;
        }
        else
        {
            SurfaceEffector.speed = BaseSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || _leftturn)
        {
            rb2d.AddTorque(_torque * 2);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || _rightturn)
        {
            rb2d.AddTorque(-_torque * 2);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            DustParticle.Stop();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            DustParticle.Play();
        }
    }

}
