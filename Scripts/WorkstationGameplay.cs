using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

//this class handles implementation of each stage of the game for the player, as well as launch and stun mechanisms
public class WorkstationGameplay : MonoBehaviour
{   public AudioSource stunnedSound;
    public AudioSource eating;
    public GameObject timeKeeper;
    bool newOrder =true;
    public GameObject oneCyl, twoCyl, threeCyl, fourCyl, fiveCyl, sixCyl, sevenCyl, eightCyl;
    public GameObject spatula;
    List<GameObject> collideWith;

    int laadoos=0;
    GameObject activeGameObject;

    public GameObject smallChaku;
    public GameObject laadoo1;
    public GameObject laadoo2;
    public GameObject laadoo3;
    public GameObject laadoo4;

    public GameObject small1;
    public GameObject small2;
    public GameObject small3;
    public GameObject small4;
    public GameObject roasting;
    public Vector3 targetPos;
    List<Transform> boondis;

    public Material unroasted;
    public Material slightly_roasted;
    public Material roasted;
    public Material done;
    
    public GameObject chaku;
    Vector3 laadoo1pos;
    Vector3 laadoo2pos;
    Vector3 laadoo3pos;
    Vector3 laadoo4pos;

    bool madeLaadoos=false;
    bool flourAdded = false;
    public int cumulativePoints=0;

    TimeOut script; 

    public bool stunned=false;
    public float stunnedTime=0;

    MoveSmallChaku moveSmallChaku;

    public GameObject s2;

    WorkstationGameplay p2;

    public GameObject stun;

    public TextMeshProUGUI points;

    public KeyCode upKey;

    public KeyCode oppKey;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
        script = timeKeeper.GetComponent<TimeOut>();
        moveSmallChaku = smallChaku.GetComponent<MoveSmallChaku>();
        p2=s2.GetComponent<WorkstationGameplay>();

        laadoo1.SetActive(false);
        laadoo2.SetActive(false);
        laadoo3.SetActive(false);
        laadoo4.SetActive(false);
        roasting.SetActive(false);
        small1.SetActive(false);
        small2.SetActive(false);
        small3.SetActive(false);
        small4.SetActive(false);

        laadoo1pos =laadoo1.transform.position;
        laadoo2pos =laadoo2.transform.position;
        laadoo3pos =laadoo3.transform.position;
        laadoo4pos =laadoo4.transform.position;
        print(laadoo1pos);
        print(laadoo2pos);
        print(laadoo3pos);
        print(laadoo4pos);
        laadoo1.SetActive(false);
        laadoo2.SetActive(false);
        laadoo3.SetActive(false);
        laadoo4.SetActive(false);
        roasting.SetActive(false);
        DOTween.SetTweensCapacity(3125,780);

        stun.SetActive(false);
        
    }

    void Update()
    {
        if(script.mode==0){
            if(newOrder){
            laadoo1.transform.position=laadoo1pos;
            laadoo2.transform.position=laadoo2pos;
            laadoo3.transform.position=laadoo3pos;
            laadoo4.transform.position=laadoo4pos;
            laadoo1.SetActive(false);
            laadoo2.SetActive(false);
            laadoo3.SetActive(false);
            laadoo4.SetActive(false);
            small1.SetActive(false);
            small2.SetActive(false);
            small3.SetActive(false);
            small4.SetActive(false);
            laadoos=0;
            UpdateCollideWith(script.level);
            madeLaadoos=false;
            newOrder=false; 
            stunned=false;
            stunnedTime=0;
            stun.SetActive(false);
            }
            else if(!flourAdded){
                //Show D sprite
                if(Input.GetKeyDown(oppKey)){
                roasting.SetActive(true);
                flourAdded=true;
                //spatula.SetActive(true);
                Transform flour = roasting.transform.Find("Flour");
                boondis = new List<Transform>();
                foreach (Transform boondi in flour)
                {
                    if (boondi.name == "Sphere")
                            {
                             Renderer renderer = boondi.GetComponent<Renderer>();
                             renderer.material= unroasted;
                             boondis.Add(boondi);
                            }
                }
            }
        }
        else{
            MonitorOrder();
        }
                  
        }
        else if(script.mode==1){
            newOrder=true;
            DeactivateAll();
            if(flourAdded){
            roasting.SetActive(false);
            flourAdded=false;
            }
            SetSmallLaadoos();
        }
        else if(script.mode==2){
            if(stunned){
                stun.SetActive(true);
            }
            if(!madeLaadoos){
                MakeLaadoos();
                madeLaadoos=true;
                targetPos=chaku.transform.position;
            }
            else{
                if(!stunned){
                stun.SetActive(false);
                LaunchOrder();
                
            }
             else if(script.TargetTime==stunnedTime-2){
                    stunned=false;
                }
            }
            ResetLaadoos();
        }
        
    }

    private void SetSmallLaadoos()
    {
        if(laadoos>=1){
            small1.SetActive(true);
        }
        if(laadoos>=2){
            small2.SetActive(true);
        }
        if(laadoos>=3){
            small3.SetActive(true);
        }
        if(laadoos>=4){
            small4.SetActive(true);
        }
    }

    private void ResetLaadoos()
    {
        if(laadoo1.activeInHierarchy){
            if(laadoo1.GetComponent<Collider>().bounds.Intersects(chaku.GetComponent<Collider>().bounds)){
                laadoo1.transform.position=laadoo1pos;
                eating.Play();
                laadoo1.SetActive(false);
                if(moveSmallChaku.side==1){
                    cumulativePoints+=20;
                } 
                else{
                    cumulativePoints+=15;
                }  
            }
        }
        if(laadoo2.activeInHierarchy){
            if(laadoo2.GetComponent<Collider>().bounds.Intersects(chaku.GetComponent<Collider>().bounds)){
                laadoo2.transform.position=laadoo2pos;
                eating.Play();
                laadoo2.SetActive(false);
                if(moveSmallChaku.side==1){
                    cumulativePoints+=20;
                } 
                else{
                    cumulativePoints+=15;
                } 
                
            }
        }
         if(laadoo3.activeInHierarchy){
            if(laadoo3.GetComponent<Collider>().bounds.Intersects(chaku.GetComponent<Collider>().bounds)){
                laadoo3.transform.position=laadoo3pos;
                eating.Play();
                laadoo3.SetActive(false);
                if(moveSmallChaku.side==1){
                    cumulativePoints+=20;
                } 
                else{
                    cumulativePoints+=15;
                } 
                
            }
        }
        if(laadoo4.activeInHierarchy){
            if(laadoo4.GetComponent<Collider>().bounds.Intersects(chaku.GetComponent<Collider>().bounds)){
                laadoo4.transform.position=laadoo4pos;
                eating.Play();
                laadoo4.SetActive(false);
                if(moveSmallChaku.side==1){
                    cumulativePoints+=20;
                } 
                else{
                    cumulativePoints+=15;
                } 
            }
        }
        
        points.text = cumulativePoints.ToString();

    }

    private void LaunchOrder()
    {   
        if(moveSmallChaku.side==1){
            if(Input.GetKeyDown(oppKey) && !p2.stunned){
                Stun(20);
                
            }
            else if(Input.GetKeyDown(upKey)){
                Launch(0.5f);
            }   
        }
        if(moveSmallChaku.side==2){
            if(Input.GetKeyDown(upKey)){
                Launch(1f);
            }
            else if(Input.GetKeyDown(oppKey) && !p2.stunned){
                Stun(10);
            }
        }
        else{
            if(Input.GetKeyDown(oppKey) && !p2.stunned){
                Stun(10);
            }
        }  
        
    }

    private void Launch(float duration){
        if(laadoo4.activeSelf){
                    laadoo4.transform.DOJump(targetPos, jumpPower: 30, numJumps: 3, duration: duration);
                    small4.SetActive(false);
                }
                else if(laadoo3.activeSelf){
                    laadoo3.transform.DOJump(targetPos, jumpPower: 30, numJumps: 3, duration: duration);
                    small3.SetActive(false);
                }
                else if(laadoo2.activeSelf){
                    laadoo2.transform.DOJump(targetPos, jumpPower: 30, numJumps: 3, duration: duration);
                    small2.SetActive(false);
                }
                else if(laadoo1.activeSelf){
                    laadoo1.transform.DOJump(targetPos, jumpPower: 30, numJumps: 3, duration: duration);
                    small1.SetActive(false);
                }
    }
    private void Stun(int points){
                if((p2.stunnedTime==0||script.TargetTime<=p2.stunnedTime-4) && (laadoo4.activeSelf || laadoo3.activeSelf || laadoo2.activeSelf || laadoo1.activeSelf)){
                p2.stunned=true;
                stunnedSound.Play();
                p2.cumulativePoints-=points;
                p2.stunnedTime=script.TargetTime;
                if(laadoo4.activeSelf){
                    laadoo4.SetActive(false);
                    small4.SetActive(false);
                }
                else if(laadoo3.activeSelf){
                    laadoo3.SetActive(false);
                    small3.SetActive(false);
                }
                else if(laadoo2.activeSelf){
                    laadoo2.SetActive(false);
                    small2.SetActive(false);
                }
                else if(laadoo1.activeSelf){
                    laadoo1.SetActive(false);
                    small1.SetActive(false);
                }
                }
    }

   private void MakeLaadoos()
    {   
        if(laadoos>=1){
            laadoo1.SetActive(true);
        }
        if(laadoos>=2){
            laadoo2.SetActive(true);
        }
         if(laadoos>=3){
            laadoo3.SetActive(true);
        }
         if(laadoos==4){
            laadoo4.SetActive(true);
         }
         
    }

    private void UpdateCollideWith(int orderKey)
    {
        if(orderKey==0){
            collideWith=new List<GameObject>{oneCyl, twoCyl, threeCyl, fourCyl, fiveCyl, sixCyl, sevenCyl, eightCyl};
        }
        else if(orderKey==1){
            collideWith=new List<GameObject>{oneCyl, fiveCyl, twoCyl, sixCyl, threeCyl, sevenCyl, fourCyl, eightCyl};
        }
        else if(orderKey==2){
            collideWith=new List<GameObject>{eightCyl, sixCyl, twoCyl, fourCyl, oneCyl, fiveCyl, sevenCyl, threeCyl};
        }
        else{
            collideWith=new List<GameObject>{fourCyl, eightCyl, twoCyl, sixCyl, fiveCyl, sevenCyl, threeCyl, oneCyl};
        }
        DeactivateAll();
    }

    private void DeactivateAll()
    {
        oneCyl.SetActive(false);
        twoCyl.SetActive(false);
        threeCyl.SetActive(false);
        fourCyl.SetActive(false);
        fiveCyl.SetActive(false);
        sixCyl.SetActive(false);
        sevenCyl.SetActive(false);
        eightCyl.SetActive(false);
    }
    
    public void MonitorOrder(){
        if(collideWith.Count==0){
            laadoos=4;
            activeGameObject=null;
            roasting.SetActive(false);
            print(laadoos);   
        }
        else{
            activeGameObject=collideWith[0];
            activeGameObject.SetActive(true);
            
            if(activeGameObject.GetComponent<Collider>().bounds.Intersects(spatula.GetComponent<Collider>().bounds)){
                activeGameObject.SetActive(false);
                collideWith.RemoveAt(0);
            }
            
            if(collideWith.Count==6){
                laadoos=1;

                foreach (Transform boondi in boondis)
                {
                    Renderer renderer = boondi.GetComponent<Renderer>();
                    renderer.material= slightly_roasted;
                    
                }
                
            }
            else if(collideWith.Count==4){
                laadoos=2;
                foreach (Transform boondi in boondis)
                {
                    Renderer renderer = boondi.GetComponent<Renderer>();
                    renderer.material= roasted;
                    
                }
            }
            else if(collideWith.Count==2){
                laadoos=3;
                foreach (Transform boondi in boondis)
                {
                    Renderer renderer = boondi.GetComponent<Renderer>();
                    renderer.material= done;
                    
                }
            }
        }
    }
}
