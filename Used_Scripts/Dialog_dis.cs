using UnityEngine;

public class ShowSpriteOnTrigger : MonoBehaviour
{
    public GameObject spriteObject;

    private void Start()
    {
        spriteObject.SetActive(false); // Ustawienie sprite'a jako nieaktywnego na starcie
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteObject.SetActive(true); // Aktywuj sprite, gdy gracz wejdzie w collider
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteObject.SetActive(false); // Wyłącz sprite, gdy gracz opuści collider
        }
    }
}
