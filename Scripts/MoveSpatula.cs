using System.ComponentModel.Composition;
using Unity.Collections;
using UnityEngine;

public class MoveSpatula : MonoBehaviour
{
  // public float speedFactor = 15.0f;

   //public string imuName = "a";
   Rigidbody rb;
   float x,y,z;
   public float moveThroughFlour=0.01f;

   Vector3 targetPos;
   Vector3 move;
   Vector3 potCenter;
   Vector2 potRadius = new Vector2(15, 15);

   Vector3 offsetFromCenter; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {    rb = GetComponent<Rigidbody>();    
         potCenter = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
      x=0;
      z=0;
      //UduinoManager.Instance.OnDataReceived += ReadIMU;
      if(Input.GetKeyDown(KeyCode.A)){
        x =-moveThroughFlour;
      }
      else if(Input.GetKeyDown(KeyCode.D)){
        x=moveThroughFlour;
      }
      if(Input.GetKeyDown(KeyCode.W)){
        z=moveThroughFlour;
      }
      else if(Input.GetKeyDown(KeyCode.S)){
        z=-moveThroughFlour;
      }
      /*if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)){
        offsetFromCenter = transform.position+ new Vector3(x,0,0)-potCenter;
        if (offsetFromCenter.magnitude > potCenter.x)
        {
            offsetFromCenter = offsetFromCenter.normalized * potRadius.x;
        }
         transform.position+=offsetFromCenter+potCenter;
      }*/

      if (x != 0 || z != 0)
    {
        Vector3 move = new Vector3(x, 0, z);
        Vector3 proposedPosition = transform.position + move;

        Vector3 offset = proposedPosition - potCenter;

        // Clamp within circular boundary
        if (offset.magnitude > potRadius.x)
        {
            offset = offset.normalized * potRadius.x;
        }

        transform.position = potCenter + offset;
    }
     
        
    }

    /*public void ReadIMU (string data, UduinoDevice device) {
        Debug.Log(data);
        string[] values = data.Split('/');
        if (values.Length == 4 && values[0] == imuName) // Rotation of the first one 
        {   Debug.Log("Moving");
             //x = float.Parse(values[1])/4096f * 9.81f;
             //y = float.Parse(values[2])/4096f * 9.81f;
             //z = float.Parse(values[3])/4095f * 9.81f;
             x = float.Parse(values[1]);
             y = float.Parse(values[2]);
             z = float.Parse(values[3]);
             Debug.Log("Acceleration X:" + x + " Y:" + y + " Z:" + z);
             rb.linearVelocity=new Vector3(x,y,z);
             //Debug.Log("Updated velocity");
            //this.transform.localRotation = Quaternion.Lerp(this.transform.localRotation,  new Quaternion(w, y, x, z), Time.deltaTime * speedFactor);
        }
        else{
          Debug.Log("Stopped");
          rb.linearVelocity=Vector3.zero;

        }
       
        //this.transform.rotation = new Quaternion(w, x, y, z) * Quaternion.Inverse(rotOffset);
      //  Log.Debug("The new rotation is : " + transform.Find("IMU_Object").eulerAngles);
    }*/
}
