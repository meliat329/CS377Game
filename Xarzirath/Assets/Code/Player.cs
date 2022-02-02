using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public int health = 100;
    //

    //we can use ints to differentiate between weapons
    //for ex, if they upgrade the weapon it will be assigned a new value
    //and we change the sprite +figthing skill based off of that
    //i think that means that these variables will need to be public
    //we can do the same for armour
    public int sword;
    public int armour;
    //

    //i usually keep these public so i can adjust them easy but we can change
    //them to private if desired
    public float jump;
    public float speed;
    //

    private bool attack = false;
    private bool grounded = true;
    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        grounded = true;
        HealthKeeper.UpdateHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid.position += Vector2.right * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid.position += Vector2.left * Time.deltaTime * speed;
        }
        //this is copied from old code and was to fix a weird bug
        //feel free to redo whatever
        else
        {
            rigid.velocity *= new Vector2(0, 1);
        }

        //jump, prevetn double jump
        if (grounded && Input.GetKey(KeyCode.Space))
        {
            rigid.velocity += Vector2.up * jump;
            grounded = false;
        }

        //attack, i just choose f bc that seems like a comfy hand position but
        //we can change it to whatever
        //should we be able to attack wihtout a sword (i.e sword == 0)?
        if (Input.GetKey(KeyCode.F))
        {
            attack = true;
            Invoke("end_attack", 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        if (collision.collider.gameObject.tag == "Enemy")
        {
            Enemies e = collision.collider.GetComponent<Enemies>();

            //we need some sort of bubble where we can hit without actively touching the
            //enemy, making the box collider bigger would not work as the enemy could then
            //damage you without looking like they touched you
            if (attack)
            {
                print("work");
                //strength of weapon determines 
                e.hit(sword);
            }
            //jump to kill
            else if (collision.collider.bounds.center.y <= collision.otherCollider.bounds.min.y)
            {
                e.hit(1);
            }
            else
            {
                //reduce health, integrate shield component how?
                health -= e.strength;
                HealthKeeper.UpdateHealth(health);
                //if health is low enough we die
            }
        }
    }

    private void end_attack()
    {
        attack = false;
    }
}

