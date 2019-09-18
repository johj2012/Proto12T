using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Frog : Enemy
{


    // Start is called before the first frame update
    protected override void Start() 
    {
        base.Start();

        hp = 100.0f;
        speed = 3.0f;
        ad = 10.0f;
    }




    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        TargetChase();
    }
}
