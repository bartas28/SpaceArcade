using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour {

    private LaserSpawn _ls;

    void Start()
    {
        _ls = GameObject.FindGameObjectWithTag("Donut").GetComponent<LaserSpawn>();
    }

	void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Finish"))
        {
            _ls.generateLasers();
        }
    }

}
