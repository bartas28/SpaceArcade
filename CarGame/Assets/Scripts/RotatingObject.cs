using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour {

    [SerializeField]
    private Vector3 _rotationDirection;
    [SerializeField]
    private float _rotationSpeed = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per fra me
	void Update () {
        this.transform.Rotate(new Vector3(_rotationDirection.x * _rotationSpeed, _rotationDirection.y * _rotationSpeed, _rotationDirection.z * _rotationSpeed));
	}
}
