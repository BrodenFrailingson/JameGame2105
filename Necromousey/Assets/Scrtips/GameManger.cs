using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    // Start is called before the first frame update
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
    public void gameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
