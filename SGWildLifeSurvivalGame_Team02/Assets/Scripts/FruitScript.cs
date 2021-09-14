using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    public float lifeTime = 60f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime); //Rotate 'cuz it looks cool and make the fruit more noticable by the player

        if(lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
            //Did player eat me or should I suicide ?
            if (lifeTime <= 0)
            {
                Destroy(this.gameObject);
            }
        }

    }
}
