using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //use float for % so we can scale a health bar?
    public float health = 1;
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

    private bool grounded = true;
    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        grounded = true;
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
    }
}
