using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public Rigidbody2D m_rigidBody;

    public float Velocity = 0.010f;

    private Vector3 birdRotation=new Vector3(0,0,30.0f);


    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) )
        {
            m_rigidBody.AddForce(Vector2.up * 30.0f);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //m_rigidBody.AddForce(Vector2.left * 100f);
            m_rigidBody.transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, 0).normalized * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 180 * Time.deltaTime * 100);
            Physics2D.gravity = new Vector2(0, 10f);
        }


        // ROTATION WHEN FALLING / RAISING
        if (m_rigidBody.velocity.y > 0) 
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0,0,30), Time.deltaTime * 400f);

        }
        if (m_rigidBody.velocity.y <= 0) 
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -30), Time.deltaTime * 150f);

        }



        // mechanics of falling down
        if ( m_rigidBody.transform.position.y < 0)
        {
            Physics2D.gravity = new Vector2(0, -25f);
        }
        else
            Physics2D.gravity = new Vector2(0, -9.8f);

    }

    // method independent from FPS(not like Update), use mostly to apply physical input
    private void FixedUpdate()
    {
        m_rigidBody.velocity = new Vector2(Velocity, m_rigidBody.velocity.y);

    }


}
