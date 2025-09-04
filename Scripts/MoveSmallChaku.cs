using UnityEngine;
//this class controls the kid in stage TUG
public class MoveSmallChaku : MonoBehaviour
{
    int extremeL=-70;
    int extremeR=190;
    bool moveLeft=false;
    bool moveRight=false;
    int x=0;
    WorkstationGameplay p1;

    WorkstationGameplay p2;

    TimeOut timeOut;

    public GameObject timeKeeper;
    public GameObject s1;
    public GameObject s2;
    bool positioned = false;

    public int side=0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p1= s1.GetComponent<WorkstationGameplay>();
        p2=s2.GetComponent<WorkstationGameplay>();
        timeOut=timeKeeper.GetComponent<TimeOut>();
    }
    // Update is called once per frame
    void Update()
    {

        if(timeOut.mode==1){
        if(!positioned){
            side=0;
            transform.position=new Vector3(60,88,26);
            positioned=true;
        }
        x=0;
        if(Input.GetKeyDown(KeyCode.A) && transform.position.x>extremeL){
                moveLeft=true;
        }
        if(Input.GetKeyDown(KeyCode.L) && transform.position.x<extremeR){
                moveRight=true;
        }
        if(moveLeft){
            if(p1.cumulativePoints>p2.cumulativePoints){
                x-=UnityEngine.Random.Range(13,15);
            }
           else{
            x-=UnityEngine.Random.Range(11,15);
           }
        }
        if(moveRight){
            if(p2.cumulativePoints>p1.cumulativePoints){
                x+=UnityEngine.Random.Range(13,15);
            }
            else{
                 x+=UnityEngine.Random.Range(11,15);
            }
        }
        transform.position+=new Vector3(x,0,0);
        if(transform.position.x<55){
            side=1;
        }
        else if(transform.position.x>65){
            side=2;
        }
        else{
            side=0;
        }
        moveLeft=false;
        moveRight=false;
        
    }
    else{
        transform.position=new Vector3(-199,88,26);
        positioned=false;
    }
    }
    
}
