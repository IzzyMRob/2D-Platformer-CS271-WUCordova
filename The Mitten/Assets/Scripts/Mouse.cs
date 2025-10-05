using Unity.VisualScripting;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.mouse += 1;
            Destroy(gameObject);
        }
    }
}
