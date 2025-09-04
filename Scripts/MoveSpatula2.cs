using System.ComponentModel.Composition;
using Unity.Collections;
using UnityEngine;

public class MoveSpatula2 : MonoBehaviour
{
  // public float speedFactor = 15.0f;

   //public string imuName = "a";
   Rigidbody rb;
   float x,z;
   public float moveThroughFlour=0.0001f;

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
      if(Input.GetKeyDown(KeyCode.J)){
        x =-moveThroughFlour;
      }
      else if(Input.GetKeyDown(KeyCode.L)){
        x=moveThroughFlour;
      }
      if(Input.GetKeyDown(KeyCode.I)){
        z=moveThroughFlour;
      }
      else if(Input.GetKeyDown(KeyCode.K)){
        z=-moveThroughFlour;
      }

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
}
