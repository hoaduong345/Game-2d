
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerManagement : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    private void Awake()
    {
        isGameOver = false;
    }
 

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Shared.scores = 0;
        
    }
}
