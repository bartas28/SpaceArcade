using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnConfigs : MonoBehaviour {

    [SerializeField]
    private float _lifeTime;

    public float LifeTime
    {
        get
        {
            return _lifeTime;
        }
    }
}
