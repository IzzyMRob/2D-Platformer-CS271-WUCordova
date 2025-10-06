using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject mouseImage;

    void Start()
    {
        mouseImage.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.mouse += 1;
            Destroy(gameObject);
            mouseImage.SetActive(true);
        }
    }
}
