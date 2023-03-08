using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IsWater : MonoBehaviour
{
    [SerializeField] private GameObject puddlePrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<GroundTile>())
        {
            GameObject newPuddle = Instantiate(puddlePrefab);
            newPuddle.transform.position = transform.position;
            newPuddle.transform.position += new Vector3(0, 1.1f - newPuddle.transform.position.y, 0);
            Destroy(this.gameObject);
        }
    }
    //private float LifeTimer = 5;

    //// Update is called once per frame
    //void Update()
    //{
    //    LifeTimer -= Time.deltaTime;
    //    if(LifeTimer <= 0)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
}
