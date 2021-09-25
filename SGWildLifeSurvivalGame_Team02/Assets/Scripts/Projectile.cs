using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 target;
    public Transform Player;
    public float iniProjLifeTime = 5f;
    float projLifeTime;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(Player.position.x, Player.position.y);
        projLifeTime = iniProjLifeTime;
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
       if (transform.position.x == target.x && transform.position.y == target.y){
           DecayProjectileLifeTime();
       } 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
    void DecayProjectileLifeTime(){
        projLifeTime -= Time.deltaTime;
        if(projLifeTime <= 0)
        {
            Destroy(this.gameObject);
            projLifeTime -= iniProjLifeTime;
        }

    }
}

