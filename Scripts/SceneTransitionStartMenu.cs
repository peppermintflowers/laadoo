using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionStartMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When user presses play button
    public void OnStart()
    {
        print("Loading play");
        SceneManager.LoadScene(5);
    }

    //When user chooses to exit
    public void OnQuit()
    {
        Application.Quit();
    }
    
    //This loads the credits scene
    public void OnInfo()
    {
        SceneManager.LoadScene(6);
    }
}