using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOnTime : MonoBehaviour {
    public float desTime = 2f;
	// Use this for initialization
	void Start () {
        Invoke("Dead", desTime);//2秒之后 调用Dead
	}
	
	// Update is called once per frame
	void Dead () {
        Destroy(gameObject);
		
	}
}
