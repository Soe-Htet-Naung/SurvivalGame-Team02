using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    //bool isEaten = false;
    //public float selfDestoryTimer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime); //Rotate 'cuz it looks cool and make the fruit more noticable by the player

    //    selfDestoryTimer += Time.deltaTime;
    //    //Did player eat me or should I suicide ?
    //    if (isEaten == false && selfDestoryTimer >= 60)
    //    {
    //        Destroy(this.gameObject);
    //    }
    }
}
