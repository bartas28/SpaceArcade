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
    private float _MAX_ROTATION = 25f;

    private float _rotationY = 0;
    private float _rotationSpeed = 5f;
    private float _MIN_ANGLE = 0.5f;  //minimum angle of car in Y axis

    void Start () {
        _donut = GameObject.FindGameObjectWithTag("Donut").GetComponent<Donut>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        moveStraight(_speedVer);
        if (Input.GetAxis("Horizontal") != 0)
        {
            moveSide(Input.GetAxis("Horizontal"));
        }
        else if(_rotationY != 0){
            straightenCar();
        }
    }

    private void moveSide(float hor)
    {
        _rotationY += _rotationSpeed * hor;
        _rotationY = Mathf.Clamp(_rotationY, -_MAX_ROTATION, _MAX_ROTATION);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, _rotationY, transform.localEulerAngles.z);
        float accelerationFactor = Mathf.Abs(_rotationY / _MAX_ROTATION);
        _donut.RotateHorizontal(Time.deltaTime * hor * _speedHor * accelerationFactor);
    }

    private void moveStraight(float speed)
    {
        _donut.RotateVertical(Time.deltaTime * speed);
    }

    private void straightenCar()
    {
        if(Mathf.Abs(_rotationY) < _MIN_ANGLE)
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
