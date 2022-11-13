using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
	public bool playerCanPass = true,isInAction; //if forwhatever reason we don't want the player to proceed
	[SerializeField]
	GameObject yoTarget;
	[SerializeField]
	float cameraSpeed=.1f, yoWind=10f, yoWindDec =.01f, attackOffset =1f, windSpeed = .01f, maxWind = 100;
	void decrementWind(){
		yoWind -= yoWindDec;
		isInAction = false;
	}
	void windYoYo(){
		yoWind++;
	}
	void baseAttack(){
		if(yoTarget==null){
			yoTarget = this.gameObject.transform.GetChild(0).gameObject;
		}
		if(yoWind>=.1f){
			yoTarget.transform.position = transform.position + attackOffset*Vector3.right;
			isInAction = true;
			}
		else{
			yoTarget.transform.position = transform.position;
		}
	}
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
	void FixedUpdate(){
	}
    // Update is called once per frame
    void Update(){
		if (Input.GetKey(KeyCode.F)){
			baseAttack();
			decrementWind();
			isInAction = true;
		}
		else if (Input.GetKey(KeyCode.R)){
			windYoYo();
			isInAction = true;
		}
		else{
			isInAction = false;
			if(yoTarget !=null){
				yoTarget.transform.position = transform.position;
			}
		}
		if(yoWind>maxWind){
			yoWind = maxWind;
		}

		Vector2 newPos = move();
		if(SafeFrameCheck(newPos)){
			if(!isInAction)
				transform.position = move();
			Debug.Log("GOOD");
		}
		else{
			Debug.Log("BAD");
		}
        
    }

}
