using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    [SerializeField]
    public float fuel;
    private float _currentFuelUsage;
    private int _life;

    public int Life
    {
        get
        {
            return _life;
        }

        set
        {
            if (value > GameConstants.PLAYER_LIFE_MAX)
                value = GameConstants.PLAYER_LIFE_MAX;
            if (value <= 0)
                die();
            _life = value;
        }
    }
    
    private Magnet _magnetEffect;
    private Shield _shieldEffect;
    private Clock _clockEffect;

    // Use this for initialization
    void Start () {
        _magnetEffect = this.gameObject.GetComponent<Magnet>();
        _shieldEffect = this.gameObject.GetComponent<Shield>();
        _clockEffect = this.gameObject.GetComponent<Clock>();
        fuel = GameConstants.FUEL_MAX;
        Life = GameConstants.PLAYER_LIFE_MAX;
        _currentFuelUsage = GameConstants.FUEL_USAGE;
        StartCoroutine(useFuel());
    }
	
    private void getDamage(int damage = 1)
    {
        Life -= damage;
    }

    public void die()
    {
        Debug.Log("YOU DIED");
        SceneManager.LoadScene(0);
    }

    public void refuel(float tank)
    {
        fuel += tank;
        if(fuel > GameConstants.FUEL_MAX)
        {
            fuel = GameConstants.FUEL_MAX;
        }
    }

    private IEnumerator useFuel()
    {
        while (true)
        {
            fuel -= _currentFuelUsage;
            if (fuel <= 0f)
            {
                outOfFuel();
            }
            _currentFuelUsage = GameConstants.FUEL_USAGE;
            yield return new WaitForSeconds(GameConstants.FUEL_USAGE_DELAY);
        }
    }

    public void collideEnemy(int damage=1)
    {
        if (_shieldEffect.Active)
        {
            _shieldEffect.clear();
        }
        else
        {
            getDamage(damage);
        }
    }

    public void outOfFuel()
    {
        die();
    }

    public void collectShield()
    {
        StartCoroutine(_shieldEffect.trigger());
        _magnetEffect.clear();
        _clockEffect.clear();
        Debug.Log("Shield taken");
    }

    public void collectClock()
    {
        StartCoroutine(_clockEffect.trigger());
        _magnetEffect.clear();
        _shieldEffect.clear();
        Debug.Log("Clock taken");
    }

    public void collectMagnet()
    {
        StartCoroutine(_magnetEffect.trigger());
        _clockEffect.clear();
        _shieldEffect.clear();
        Debug.Log("Magnet taken");
    }

}
