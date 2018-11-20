using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour {

    [SerializeField]
    private Vector3 _rotationDirection;
    private float _rotationSpeed = 180f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(_rotationDirection.x * _rotationSpeed * Time.deltaTime, 
            _rotationDirection.y * _rotationSpeed * Time.deltaTime,
            _rotationDirection.z * _rotationSpeed * Time.deltaTime));
	}
}
