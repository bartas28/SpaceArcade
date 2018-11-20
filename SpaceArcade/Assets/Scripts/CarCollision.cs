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
            _player.collideEnemy();
            Debug.Log("you died");
        }
        else if (col.CompareTag("Fuel"))
        {
            _player.refuel((float)col.gameObject.transform.parent.gameObject.transform.parent.GetComponent<SpawnConfigs>().FuelSize / 100 * GameConstants.FUEL_MAX);
            Destroy(col.gameObject);
        }
        else if (col.CompareTag("Magnet")){
            _player.collectMagnet();
            Destroy(col.transform.parent.gameObject);
        }
        else if (col.CompareTag("Shield"))
        {
            _player.collectShield();
            Destroy(col.gameObject);
        }
        else if (col.CompareTag("Clock"))
        {
            _player.collectClock();
            Destroy(col.transform.parent.gameObject);
        }
    }

}
