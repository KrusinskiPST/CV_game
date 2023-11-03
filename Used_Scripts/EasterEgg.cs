using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    public float newSpeed; // nowa prędkość gracza
    public Sprite newSprite; // nowy sprite gracza

    private SpriteRenderer colliderSpriteRenderer; // referencja do komponentu SpriteRenderer collidera

    private void Start()
    {
        colliderSpriteRenderer = GetComponent<SpriteRenderer>(); // pobranie komponentu SpriteRenderer dla collidera
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Sprawdzenie, czy obiekt, który wszedł w collider, to gracz
        {
            Player_WSAD playerScript = other.GetComponent<Player_WSAD>(); // pobranie skryptu Player_WSAD
            if (playerScript != null) // sprawdzenie, czy skrypt istnieje
            {
                playerScript.ChangeSpeed(newSpeed); // zmiana prędkości na nową
                if (colliderSpriteRenderer != null && newSprite != null) // sprawdzenie, czy komponent istnieje i czy nowy sprite nie jest pusty
                {
                    colliderSpriteRenderer.sprite = newSprite; // zmiana sprite'a collidera na nowy
                }
            }
        }
    }


}
