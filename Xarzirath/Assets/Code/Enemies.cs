using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    ///do we want have movement types like pacing, moving across and off the screen
    ///or static? we coul;d probably fit them all in here using a public variable + if statments

    public int health;
    public int strength;
    private Rigidbody2D rigid;
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
