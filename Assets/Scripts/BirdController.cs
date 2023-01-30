using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public Rigidbody2D m_rigidBody;

    public float Velocity = 0.010f;



    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            m_rigidBody.AddForce(Vector2.up * 100.0f);
        }
    }


    private void FixedUpdate()
    {
        m_rigidBody.velocity = new Vector2(Velocity, m_rigidBody.velocity.y);

    }


}
