using UnityEngine;
//this class manages the spatula object in the game
public class MoveSpatula : MonoBehaviour
{
   float x,z;
   public float moveThroughFlour=0.01f;

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;

   Vector3 potCenter;
   Vector2 potRadius = new Vector2(24, 20);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {    
         potCenter = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
      x=0;
      z=0;
      if(Input.GetKeyDown(leftKey)){
        x =-moveThroughFlour;
      }
      else if(Input.GetKeyDown(rightKey)){
        x=moveThroughFlour;
      }
      if(Input.GetKeyDown(upKey)){
        z=moveThroughFlour;
      }
      else if(Input.GetKeyDown(downKey)){
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
