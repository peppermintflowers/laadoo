using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Instr : MonoBehaviour
{
    public Image instruction;
    public Sprite[] instructionSlides;
    public Button nextButton;
    public Button backButton;

    private int currentIndex=0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowSlide(currentIndex);
        backButton.onClick.AddListener(PrevSlide);
        nextButton.onClick.AddListener(NextSlide);
    }

    // moving back through thre instruction slides
    private void PrevSlide()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            ShowSlide(currentIndex);
        }
    }

    // moving forward through the instruction slides
    private void NextSlide()
    {
        if (currentIndex < instructionSlides.Length - 1)
        {
            currentIndex++;
            ShowSlide(currentIndex);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    //update the slide displayed on screen
    private void ShowSlide(int currentIndex)
    {
        instruction.sprite = instructionSlides[currentIndex];
        backButton.interactable = currentIndex > 0;
    }

    
}
