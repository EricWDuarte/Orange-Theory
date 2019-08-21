using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeRotation : MonoBehaviour {

    public static float rot = 0;

    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, rot * Time.deltaTime) ;
	}


}
