using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    // Methods to load specific levels
    public void OnLevel1ButtonClicked()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OnLevel2ButtonClicked()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void OnLevel3ButtonClicked()
    {
        SceneManager.LoadScene("Level 3");
    }
}
