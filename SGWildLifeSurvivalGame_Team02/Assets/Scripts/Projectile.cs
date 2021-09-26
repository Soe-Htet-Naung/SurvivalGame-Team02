using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] AudioClip projectileDesSFX;

    public int damage = 20;
    private void OnCollisionEnter(Collision collision)
    {
            if (collision.transform.CompareTag("Player"))
            {
                collision.transform.GetComponent<SurvivalScript>().currentHealth -= damage;
            }

        
        AudioSource.PlayClipAtPoint(projectileDesSFX, transform.position);
        Destroy(gameObject);
    }
    public void SetAttributes(int _damage)
    {
        damage = _damage;
    }
}
