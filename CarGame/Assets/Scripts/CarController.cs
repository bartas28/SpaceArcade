using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    private Donut _donut;

    [SerializeField]
    private float _speedHor = 100f;
    [SerializeField]
    private float _speedVer = 100f;

    [SerializeField]
    private float _maxRotation = 25f;

    private float _rotationY = 0;
    private float _rotationSpeed = 5f;
    private float minAngle = 0.5f;  //minimum angle of car in Y axis

    void Start () {
        _donut = GameObject.FindGameObjectWithTag("Donut").GetComponent<Donut>();

    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Horizontal") != 0)
        {
            moveStraight(Input.GetAxis("Horizontal"));
        }
        else if(_rotationY != 0){
            straightenCar();
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            //Debug.Log(Time.deltaTime * Input.GetAxis("Vertical") * speedVer);
            moveSide(Input.GetAxis("Vertical"));
        }
    }

    private void moveStraight(float hor)
    {
        _rotationY += _rotationSpeed * hor;
        _rotationY = Mathf.Clamp(_rotationY, -_maxRotation, _maxRotation);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, _rotationY, transform.localEulerAngles.z);
        _donut.RotateHorizontal(Time.deltaTime * hor * _speedHor);
    }

    private void moveSide(float ver)
    {
        _donut.RotateVertical(Time.deltaTime * ver * _speedVer);
    }

    private void straightenCar()
    {
        if(Mathf.Abs(_rotationY) < 0.5f)
        {
            _rotationY = 0;
        }
        else
        {
            _rotationY = _rotationY + _rotationSpeed * (0 - _rotationY) * Time.deltaTime;
        }
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, _rotationY, transform.localEulerAngles.z);
    }

}
