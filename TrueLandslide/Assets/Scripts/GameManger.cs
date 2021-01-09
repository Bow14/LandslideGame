using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManger : MonoBehaviour
{
    private bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject completeLevelUI;

    public void Completelevel()
    {
        completeLevelUI.SetActive(true);
    }

    public  void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("End Game");
            //restart game
            Invoke("Restart", restartDelay);

        }
        
    }

  void Restart()
  {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
