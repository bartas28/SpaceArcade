using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour {

    private LaserSpawn _ls;
    private Player _player;

    void Start()
    {
        _ls = GameObject.FindGameObjectWithTag("Donut").GetComponent<LaserSpawn>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

	void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Finish"))
        {
            _ls.generateLasers();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Good"))
        {
            //Debug.Log("good");
            Destroy(col.gameObject);
        }
        else if (col.CompareTag("Enemy"))
        {
            //_player.die();
            Debug.Log("you died");
        }
        else if (col.CompareTag("Fuel"))
        {
            _player.refuel(col.gameObject.transform.parent.gameObject.transform.parent.GetComponent<SpawnConfigs>().FuelSize);
            Destroy(col.gameObject);
        }
    }

}
