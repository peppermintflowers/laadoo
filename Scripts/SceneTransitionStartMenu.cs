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

    public void OnStart()
    {
        print("Loading play");
        SceneManager.LoadScene(5);
    }

    public void OnQuit(){
        Application.Quit();
    }
    
    public void OnInfo(){
        SceneManager.LoadScene(6);
    }
}