using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
//this class manages the time for each round and stage
public class TimeOut : MonoBehaviour
{
    public float TargetTime = 84.0f;
    public TextMeshProUGUI timeRemaining;
    public GameObject floor;
    SpriteRenderer panelImage;
    public int mode = 0;
    public int level = 0;
    private float timeSinceLastUpdate = 0f; 

    Color bluey;
    Color redish;

   public GameObject s1;

   public GameObject s2;

   WorkstationGameplay p1;
   WorkstationGameplay p2;

    void Start()
    {panelImage=floor.GetComponentInChildren<SpriteRenderer>();
    ColorUtility.TryParseHtmlString("#6068E5", out bluey);
    ColorUtility.TryParseHtmlString("#E56094", out redish);
    p1=s1.GetComponent<WorkstationGameplay>();
    p2=s2.GetComponent<WorkstationGameplay>();
    
    }
    void Update()
    {
        timeSinceLastUpdate+=Time.deltaTime;
        //every second
        if (timeSinceLastUpdate >= 1f)
        {   //update time remaining in the round
            TargetTime -= 1;
            timeSinceLastUpdate = 0;
            //ROUND 1
            //stage MAKE
            if (TargetTime >= 74)
            {
                panelImage.color = Color.white;
                timeRemaining.text = (TargetTime - 74).ToString();
            }
            //stage TUG
            else if (TargetTime >= 68f)
            {
                panelImage.color = redish;
                timeRemaining.text = (TargetTime - 68).ToString();
                mode = 1;
            }
            //stage SERVE
            else if (TargetTime >= 58f)
            {
                panelImage.color = bluey;
                timeRemaining.text = (TargetTime - 58).ToString();
                mode = 2;
            }
            //ROUND 2
            //stage MAKE
            else if (TargetTime >= 50f)
            {
                panelImage.color = Color.white;
                timeRemaining.text = (TargetTime - 50).ToString();
                mode = 0;
            }
            //stage TUG
            else if (TargetTime >= 44f)
            {
                panelImage.color = redish;
                timeRemaining.text = (TargetTime - 44).ToString();
                mode = 1;
            }
            //stage SERVE
            else if (TargetTime >= 34f)
            {
                panelImage.color = bluey;
                timeRemaining.text = (TargetTime - 34).ToString();
                mode = 2;
            }
            //ROUND 3
            //stage MAKE
            else if (TargetTime >= 28f)
            {
                panelImage.color = Color.white;
                timeRemaining.text = (TargetTime - 28).ToString();
                mode = 0;
            }
            //stage TUG
            else if (TargetTime >= 24f)
            {
                panelImage.color = redish;
                timeRemaining.text = (TargetTime - 24).ToString();
                mode = 1;
            }
            //stage SERVE
            else if (TargetTime >= 16f)
            {
                panelImage.color = bluey;
                timeRemaining.text = (TargetTime - 16).ToString();
                mode = 2;
            }
            //ROUND 4
            //stage MAKE
            else if (TargetTime >= 12f)
            {
                panelImage.color = Color.white;
                timeRemaining.text = (TargetTime - 12).ToString();
                mode = 0;
            }
            //stage TUG
            else if (TargetTime >= 8f)
            {
                panelImage.color = redish;
                timeRemaining.text = (TargetTime - 8).ToString();
                mode = 1;
            }
            //stage SERVE
            else if (TargetTime >= 0f)
            {
                panelImage.color = bluey;
                timeRemaining.text = TargetTime.ToString();
                mode = 2;
            }
            //evaluate scores to pick winner
            else
            {
                //team pink wins
                if (p1.cumulativePoints > p2.cumulativePoints)
                {
                    SceneManager.LoadScene(2);
                }
                //team green wins
                else if (p2.cumulativePoints > p1.cumulativePoints)
                {
                    SceneManager.LoadScene(3);
                }
                //tie
                else
                {
                    SceneManager.LoadScene(4);
                }
            }
            //updating round/level value (0-4)
            if (TargetTime == 99)
            {
                level = 1;
            }
            else if (TargetTime == 63)
            {
                level = 2;
            }
            else if (TargetTime == 29)
            {
                level = 3;
            }
        }
        
    }
    public int getMode(){
        return mode;
    }
}
