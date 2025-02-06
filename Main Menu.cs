using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This method will be triggered when the Play button is clicked
    public void OnPlayButtonClicked()
    {
        // Load the Level Selection Scene
        SceneManager.LoadScene("Level Selection");
    }
}
