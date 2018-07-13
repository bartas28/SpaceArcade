using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    [SerializeField]
    public float fuel; //fuel in percents
    private float _fuelUsage = 4f;
    private float _fuelUsageDelay = 1f;
    private float _currentFuelUsage;
    private const float _FUEL_MAX = 100f;

	// Use this for initialization
	void Start () {
        fuel = 100f;
        _currentFuelUsage = _fuelUsage;
        StartCoroutine(useFuel());
    }
	
    public void die()
    {
        SceneManager.LoadScene(0);
    }

    public void refuel(float tank)
    {
        fuel += tank;
        if(fuel > _FUEL_MAX)
        {
            fuel = _FUEL_MAX;
        }
    }

    private IEnumerator useFuel()
    {
        while (true)
        {
            fuel -= _currentFuelUsage;
            if (fuel <= 0f)
            {
                die();
            }
            _currentFuelUsage = _fuelUsage;
            yield return new WaitForSeconds(_fuelUsageDelay);
        }
    }

}
