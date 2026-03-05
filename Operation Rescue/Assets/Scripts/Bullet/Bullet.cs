using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();
            if(ph != null)
            {
                ph.TakeDamage(10);
            }
        }

        if(collision.gameObject.tag == "Enemy")
        {
            EnemyHealth eh = collision.gameObject.GetComponent<EnemyHealth>();
            if(eh != null)
            {
                eh.TakeDamage(10);
            }
        }
        gameObject.SetActive(false);
    }
}