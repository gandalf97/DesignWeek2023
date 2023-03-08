using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsWater : MonoBehaviour
{
    private float LifeTimer = 5;

    // Update is called once per frame
    void Update()
    {
        LifeTimer -= Time.deltaTime;
        if(LifeTimer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
