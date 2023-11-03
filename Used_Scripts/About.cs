using UnityEngine;

public class EndCredits : MonoBehaviour
{
    public float speed = 2f; // prędkość zjazdu obiektu
    public GameObject creditsObject; // referencja do obiektu 2D

    void Update()
    {
        // Przesunięcie obiektu w dół
        creditsObject.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
