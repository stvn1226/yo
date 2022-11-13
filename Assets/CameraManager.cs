using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	public static CameraManager theCam;
    // Start is called before the first frame update
    void Start()
    {
		if(theCam == null)
	        theCam = GetComponent<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
