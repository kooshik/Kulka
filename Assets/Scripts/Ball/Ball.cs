using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static bool constrainLeftRight = false;

    public float power = 2f;
    public float jumpMultiplier = 2f;
    public bool isActive;

    public GameObject Particles;

    protected Rigidbody myRigidbody;

    public delegate void BallEvent();
    public event BallEvent onJump;

    public void Reset()
    {
        constrainLeftRight = false;
    }

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        if (!isActive && IsGrounded())
            isActive = true;
    }

    protected bool IsGrounded()
    {
        int layerMask = ~(1 << 9);
        Collider[] colliders = Physics.OverlapSphere(transform.position + Vector3.down * 0.12f, 0.8f * (transform.localScale.y / 2), layerMask);

        for (int n = 0; n < colliders.Length; n++)
            if (!colliders[n].isTrigger)
                return true;

        return false;
    }

    virtual protected void FixedUpdate()
    {
        FixedUpdateEsc();

        if (isActive)
        {
            FixedUpdateUpDown();
            FixedUpdateLeftRight();
        }
    }

    protected void FixedUpdateEsc()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 0)
                Application.Quit();
            else
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    protected void FixedUpdateUpDown()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && IsGrounded())
        {
            Vector3 vel = GetComponent<Rigidbody>().velocity;
            vel.y = 0;
            GetComponent<Rigidbody>().velocity = vel;

            GetComponent<Rigidbody>().AddForce(Vector3.up * power * jumpMultiplier * myRigidbody.mass, ForceMode.Force);

            onJump?.Invoke();
        }

        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && IsGrounded())
            GetComponent<Rigidbody>().AddForce(Vector3.down * power * myRigidbody.mass, ForceMode.Force);
    }

    protected void FixedUpdateLeftRight()
    {
        if (!constrainLeftRight)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                GetComponent<Rigidbody>().AddForce(Vector3.left * power * myRigidbody.mass, ForceMode.Force);

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                GetComponent<Rigidbody>().AddForce(Vector3.right * power * myRigidbody.mass, ForceMode.Force);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        GetComponent<Rigidbody>().AddForce(Vector3.left * power * 5 * myRigidbody.mass, ForceMode.Force);
    }

    public void Boooom()
    {
        GameObject temp = Instantiate(Particles, transform.position, transform.rotation);
        Destroy(temp, 1);
    }
}