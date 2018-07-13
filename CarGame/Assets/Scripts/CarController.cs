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
    private float _MAX_ROTATION = 70f;

    [SerializeField]
    private float _rotationZ = 0;
    private float _rotationSpeed = 5f;
    private float _straightenSpeed = 15f;
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
        else if (_rotationZ != 0)
        {
            straightenCar();
        }
        /*if(Input.GetAxis("Vertical") != 0)
        {
            _speedVer = 100 + Input.GetAxis("Vertical") * 30;
        }*/
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -_rotationZ);
    }

    private void moveSide(float hor)
    {
        _rotationZ += _rotationSpeed * hor;
        _rotationZ = Mathf.Clamp(_rotationZ, -_MAX_ROTATION, _MAX_ROTATION);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -_rotationZ);
        float accelerationFactor = Mathf.Abs(_rotationZ / _MAX_ROTATION);
        _donut.RotateHorizontal(Time.deltaTime * hor * _speedHor * accelerationFactor);
    }

    private void moveStraight(float speed)
    {
        _donut.RotateVertical(Time.deltaTime * speed);
    }

    private void straightenCar()
    {
        if(Mathf.Abs(_rotationZ) < _MIN_ANGLE)
        {
            _rotationZ = 0;
        }
        else
        {
            _rotationZ = _rotationZ + _straightenSpeed * (0 - _rotationZ) * Time.deltaTime;
        }
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -_rotationZ);
    }

}
