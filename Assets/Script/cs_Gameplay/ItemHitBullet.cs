using UnityEngine;

public class ItemHitByBullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet")) //destroy after hit bullet
        {
            if (CompareTag("Collectible"))
            {
                GameManager.Instance.AddScore(1);
                //FlashScreen(Color.green); //not work
            }
            else if (CompareTag("Uncollectible"))
            {
                GameManager.Instance.ReduceHP(1);
                //FlashScreen(Color.red); //not work
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        else if (other.CompareTag("Ground")) //destroy after hit ground
        {
            Destroy(gameObject);
        }
    }



}


