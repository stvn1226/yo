using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
	public bool playerCanPass = true; //if forwhatever reason we don't want the player to proceed
	[SerializeField]
	float cameraSpeed=.1f;
	override public   Vector2 move(){
		float y = Input.GetAxis("Vertical");
		float x = Input.GetAxis("Horizontal");
		Vector2 newPos = new Vector2(transform.position.x+x*speed,transform.position.y+y*speed);
		return newPos;
		}
	 bool SafeFrameCheck(Vector3 newPlayerPos){
                 
		Vector3 screenPos = Camera.main.WorldToScreenPoint(newPlayerPos);
		float ratioHeight = screenPos.y / Camera.main.pixelHeight;
		float ratio_y = screenPos.y / Camera.main.pixelHeight;
		float ratio_x = screenPos.x / Camera.main.pixelWidth;

         //the last check is temporary
         if(ratio_y < 0f||ratio_y>=.99f ||ratio_x<0f||(!playerCanPass&&ratio_x>.99f)) // if we're below our safe frame
             return false;
		else if((playerCanPass&&ratio_x>.99f)){
			Camera.main.transform.position = new Vector3(Camera.main.transform.position.x+cameraSpeed,0,Camera.main.transform.position.z);
		}
         return true;      // we're inside our safe frame.
     }		
    // Update is called once per frame
    void Update(){
		Vector2 newPos = move();
		if(SafeFrameCheck(newPos)){
			transform.position = move();
			Debug.Log("GOOD");
		}
		else{
			Debug.Log("BAD");
		}
        
    }
}
