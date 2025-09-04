using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToMainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //On pressing the cross during gameplay load the main menu
    public void OnBack()
    {
        SceneManager.LoadScene(0);
    }
}
