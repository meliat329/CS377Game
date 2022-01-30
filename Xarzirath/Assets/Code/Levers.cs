using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levers : MonoBehaviour
{
    //lever active or not 
    private bool up;

    //i dont know if this needs a rigid body or would be better as a trigger

    //whatever the lever is controll. I'm not sure if gameobject is the best
    //but it should work, i think the traps/doors being affected by the lever
    //will also need a script, but ther is probably another way just not sure if
    //thats easier or harder

    public GameObject controlled;

    //optional extra object linked to whatever, ie lever opens door but activates trap
    public bool double_lever;
    public GameObject controlled2;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
