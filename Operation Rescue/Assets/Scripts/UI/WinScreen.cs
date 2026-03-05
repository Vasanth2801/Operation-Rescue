using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            winScreen.SetActive(true);
        }
    }
}