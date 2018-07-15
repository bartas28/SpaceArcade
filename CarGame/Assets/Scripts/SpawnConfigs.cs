using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnConfigs : MonoBehaviour {

    [SerializeField]
    private float _lifeTime;
    [SerializeField]
    private int _objectsMax = 5;
    [SerializeField]
    private int _fuelSize = 0;
    [SerializeField]
    private float _spawnProbability = 1;

    public float LifeTime
    {
        get
        {
            return _lifeTime;
        }
    }

    public int ObjectsMax
    {
        get
        {
            return _objectsMax;
        }
    }

    public int FuelSize
    {
        get
        {
            return _fuelSize;
        }
    }

    public float SpawnProbability
    {
        get
        {
            return _spawnProbability;
        }
    }
}
