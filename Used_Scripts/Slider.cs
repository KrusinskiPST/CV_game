using System.Collections.Generic;
using UnityEngine;

public class ChangeMainSprite : MonoBehaviour
{
    public GameObject objectToChange; // Obiekt, którego sprite ma być zmieniany
    public Collider2D arrow1Collider; // Collider dla pierwszej strzałki
    public Collider2D arrow2Collider; // Collider dla drugiej strzałki

    public List<Sprite> forwardSprites; // Lista sprite'ów do przewijania do przodu
    public List<Sprite> backwardSprites; // Lista sprite'ów do cofania

    private SpriteRenderer spriteRenderer; // Referencja do komponentu SpriteRenderer
    private int spriteIndex = 0; // Indeks aktualnie wyświetlanego sprite'a

    void Start()
    {
        // Pobranie komponentu SpriteRenderer z obiektu do zmiany
        spriteRenderer = objectToChange.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Sprawdzenie kliknięć na strzałki
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(worldPoint);

            if (hitCollider != null)
            {
                if (hitCollider == arrow1Collider)
                {
                    ChangeForward();
                }
                else if (hitCollider == arrow2Collider)
                {
                    ChangeBackward();
                }
            }
        }
    }

    void ChangeForward()
    {
        spriteIndex = (spriteIndex + 1) % forwardSprites.Count;
        spriteRenderer.sprite = forwardSprites[spriteIndex];
    }

    void ChangeBackward()
    {
        spriteIndex = (spriteIndex - 1 + backwardSprites.Count) % backwardSprites.Count;
        spriteRenderer.sprite = backwardSprites[spriteIndex];
    }
}
