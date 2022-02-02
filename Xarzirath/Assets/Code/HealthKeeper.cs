using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthKeeper : MonoBehaviour
{
    private static Image HeathBar;
   
    // Start is called before the first frame update
    void Start()
    {
        HeathBar = GetComponent<Image>();
    }

    //h is new heath, can be passed in by other parts of game
    public static void UpdateHealth(int h)
    {
        float toPercent = h / 100f;
        print(toPercent);
        HeathBar.fillAmount=toPercent;
    }
}
