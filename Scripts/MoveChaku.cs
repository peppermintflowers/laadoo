using UnityEngine;
//this class controls the kid in stage SERVE
public class MoveChaku : MonoBehaviour
{
    Vector3 leftpos= new Vector3(9, 88, 56);
    Vector3 rightpos= new Vector3(109, 88, 56);
    public GameObject smallChaku;

    public GameObject timeKeeper;
    MoveSmallChaku moveSmallChaku;
    TimeOut timeOut;
    bool positioned = false;
    Vector3 og = new Vector3(-199, 88, 56);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position=og;
        timeOut=timeKeeper.GetComponent<TimeOut>();
        moveSmallChaku=smallChaku.GetComponent<MoveSmallChaku>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeOut.mode==2){
            if(moveSmallChaku.side==1 && positioned==false){
                transform.position=leftpos;

            }
            else if(moveSmallChaku.side==2 && positioned==false){
                transform.position=rightpos;
            }
        }
        else{
            transform.position=og;
            positioned=false;
        }
    }

}
