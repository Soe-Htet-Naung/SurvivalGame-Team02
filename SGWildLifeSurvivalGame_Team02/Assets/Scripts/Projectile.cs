using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private Vector2 target;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(Player.position.x, Player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
       if (transform.position.x == target.x && transform.position.y == target.y){
           DestroyProjectile();
       } 
    }
    void OnTriggerEnter3d(SphereCollider other){
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }
    void DestroyProjectile(){
        Destroy(gameObject);
    }
}

