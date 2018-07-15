using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawn : MonoBehaviour {

    private int _LASER_COUNT_INIT = 2;
    private int _LASER_MAX = 10;
    private int _laserCount = 0;
    private int _cycles = 0;
    private List<GameObject> _lasers;
    private float _LASER_LENGTH = 0.35f;
    private float _SPHERE_RADIUS = 0.35f;

    private Transform _donutModel;

    public GameObject laserPrefab;

    private int _CYCLING_SPEED = 2;  //higher = less frequently adding new lasers

	// Use this for initialization
	void Start () {
        _donutModel = GameObject.Find("diamond_holder").GetComponent<Transform>();
        _lasers = new List<GameObject>();
        generateLasers();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void generateLasers()
    {
        _cycles++;
        _laserCount = _LASER_COUNT_INIT + _cycles / _CYCLING_SPEED;
        if(_laserCount > _LASER_MAX)
        {
            _laserCount = _LASER_MAX;
        }
        foreach(GameObject laser in _lasers)
        {
            Destroy(laser);
        }
        _lasers.Clear();
        for(int i=0; i<_laserCount; ++i)
        {
            _lasers.Add(generateLaser());
        }

    }
    public GameObject generateLaser()
    {
        float angle = Random.Range(0, 359);
        float angleRad = angle / 180 * Mathf.PI;
        Vector3 pos0, pos1;
        pos0 = new Vector3(Mathf.Sin(angleRad) * _SPHERE_RADIUS, 0, Mathf.Cos(angleRad) * _SPHERE_RADIUS);
        pos1 = new Vector3(pos0.x + Mathf.Sin(angleRad) * _LASER_LENGTH, 0, pos0.z + Mathf.Cos(angleRad) * _LASER_LENGTH);
        GameObject laser = Instantiate(laserPrefab, _donutModel);
        laser.transform.Rotate(0, angle,  0);
        GameObject holder = laser.transform.Find("laser_rotator").gameObject;
        return laser;
    }

}
