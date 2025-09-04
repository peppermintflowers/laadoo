using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using NUnit.Framework;

public class TimeOut : MonoBehaviour
{
    public float TargetTime = 84.0f;
    public TextMeshProUGUI timeRemaining;
    public GameObject floor;
    SpriteRenderer panelImage;
    public int mode = 0;
    public int level = 0;
    private float timeSinceLastUpdate = 0f; 

    float levelTime = 39f;

    Color bluey;
    Color redish;

   public GameObject s1;

   public GameObject s2;

   RandomMovementGenerator p1;
   RandomMovementGenerator2 p2;

    void Start()
    {panelImage=floor.GetComponentInChildren<SpriteRenderer>();
    ColorUtility.TryParseHtmlString("#6068E5", out bluey);
    ColorUtility.TryParseHtmlString("#E56094", out redish);
    p1=s1.GetComponent<RandomMovementGenerator>();
    p2=s2.GetComponent<RandomMovementGenerator2>();
    
    }
    void Update()
    {
        timeSinceLastUpdate+=Time.deltaTime;
        if(timeSinceLastUpdate>=1f){
            TargetTime -= 1;
            timeSinceLastUpdate=0;
            
        if(TargetTime>=74){
            panelImage.color = Color.white;
            timeRemaining.text=(TargetTime-74).ToString();
        }
        else if(TargetTime>=68f){
            panelImage.color = redish;
            timeRemaining.text=(TargetTime-68).ToString();
            mode=1;
        }
        else if(TargetTime>=58f){
            panelImage.color=bluey;
            timeRemaining.text=(TargetTime-58).ToString();
            mode=2;
        }
        //end of round 1
        else if(TargetTime>=50f){
            panelImage.color=Color.white;
            timeRemaining.text=(TargetTime-50).ToString();
            mode=0;
        }
        else if(TargetTime>=44f){
            panelImage.color = redish;
            timeRemaining.text=(TargetTime-44).ToString();
            mode=1;
        }
        else if(TargetTime>=34f){
            panelImage.color=bluey;
            timeRemaining.text=(TargetTime-34).ToString();
            mode=2;
        }
        //end of round 2
        else if(TargetTime>=28f){
            panelImage.color = Color.white;
            timeRemaining.text=(TargetTime-28).ToString();
            mode=0;
        }
        else if(TargetTime>=24f){
            panelImage.color=redish;
            timeRemaining.text=(TargetTime-24).ToString();
            mode=1;
        }
        else if(TargetTime>=16f){
            panelImage.color=bluey;
            timeRemaining.text=(TargetTime-16).ToString();
            mode=2;
        }
        //end of round 3
        else if(TargetTime>=12f){
            panelImage.color=Color.white;
            timeRemaining.text=(TargetTime-12).ToString();
            mode=0;
        }
        else if(TargetTime>=8f){
            panelImage.color=redish;
            timeRemaining.text=(TargetTime-8).ToString();
            mode=1;
        }
        else if(TargetTime>=0f){
            panelImage.color=bluey;
            timeRemaining.text=TargetTime.ToString();
            mode=2;
        }
        //evaluate
        else{
            if(p1.cumulativePoints>p2.cumulativePoints){
                SceneManager.LoadScene(2);
            }
            else if(p2.cumulativePoints>p1.cumulativePoints){
                SceneManager.LoadScene(3);
            }
            else{
                SceneManager.LoadScene(4);
            }
        }
        if(TargetTime==99){
            level=1;
            levelTime=36f;
        }
        else if(TargetTime==63){
            level=2;
            levelTime=34f;
        }
        else if(TargetTime==29){
            level=3;
            levelTime=31f;
        }
        }
        
    }
    public int getMode(){
        return mode;
    }
}
