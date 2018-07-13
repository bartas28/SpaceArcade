using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawn : MonoBehaviour {

    private int _LASER_COUNT_INIT = 2;
    private int _laserCount = 0;
    private int _cycles = 0;
    private List<GameObject> _lasers;

    private Transform _donutModel;

    public GameObject laserPrefab;

    private int _CYCLING_SPEED = 2;  //higher = less frequently adding new lasers

	// Use this for initialization
	void Start () {
        _donutModel = GameObject.Find("donut_model").GetComponent<Transform>();
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
        foreach(GameObject laser in _lasers)
        {
            Destroy(laser);
        }
        _lasers.Clear();
        for(int i=0; i<_laserCount; ++i)
        {
            _lasers.Add(Instantiate(laserPrefab, _donutModel));
            Transform transform = _lasers[i].GetComponent<Transform>();
            float randomAngle = Random.Range(0, 359);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, randomAngle);
            //transform.position = _donutModel.position;
        }

    }

}
