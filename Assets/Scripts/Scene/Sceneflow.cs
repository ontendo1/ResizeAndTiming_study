using UnityEngine;
using UnityEngine.SceneManagement;
public class Sceneflow : MonoBehaviour
{
    public void OpenScene(int addition)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + addition);
        Time.timeScale = 1;
    }
}
