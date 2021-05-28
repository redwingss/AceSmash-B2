using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public string mainGameScene;
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(mainGameScene);
    }

    // Update is called once per frame
    public void Stop()
    {
        Application.Quit();
    }
}
