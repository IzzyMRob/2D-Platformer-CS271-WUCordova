using UnityEngine;

public class Restart : MonoBehaviour
{
    public void LoadCurrentScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1_Scene");
        Time.timeScale = 1;
    }
}
