using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour {

    private Transform _rotatorX;
    private Transform _rotatorZ;

	// Use this for initialization
	void Start () {
        _rotatorX = GameObject.Find("donut_rotator_x").GetComponent<Transform>();
        _rotatorZ = GameObject.Find("donut_rotator_z").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RotateVertical(float x)
    {
        _rotatorX.Rotate(-x, 0, 0);
    }

    public void RotateHorizontal(float z)
    {
        _rotatorZ.Rotate(0, 0, z);
    }

}
