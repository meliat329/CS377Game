using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    ///do we want have movement types like pacing, moving across and off the screen
    ///or static? we coul;d probably fit them all in here using a public variable + if statments

    public int health;
    //damage
    public int strength;
    private Rigidbody2D rigid;
    private float starting;
    public float limit;
    public float speed;
    private float turned;
    private float wait = 0.2f;
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        starting = rigid.position.x;
        turned = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigid.position.x >= limit || rigid.position.x < starting)
        {
            if (Time.time - turned >= wait)
            {
                speed *= -1;
                turned = Time.time;
            }
        }

        transform.Translate(transform.right * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed *= -1;
    }


    public void hit(int attack)
    {
        health -= attack;
        if (health == 0)
        {
            this.DeathDrop();
        }
    }
    public void DeathDrop()
    {
        enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Invoke("Destruct", 0.3f);
    }
    void Destruct()
    {
        Destroy(this);
    }
}

