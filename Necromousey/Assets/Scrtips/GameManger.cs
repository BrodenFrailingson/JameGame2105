using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject GameOverUi;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu ()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void startGame ()
    {
        SceneManager.LoadScene("Level");
    }
    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
        }
    }
    public void GameOverUI()
    {
        GameOverUi.SetActive(true);
    }

       public void quitGame()
    {
        Application.Quit();
    }
}
