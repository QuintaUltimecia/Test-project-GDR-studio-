using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public void RestartCurrentScene()
    {
        int current = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(current);
    }
}
