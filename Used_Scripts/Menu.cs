using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnClick : MonoBehaviour
{
    public string sceneName; // nazwa sceny do załadowania

    void OnMouseDown()
    {
        SceneManager.LoadScene(sceneName); // załaduj określoną scenę po naciśnięciu
    }
}
