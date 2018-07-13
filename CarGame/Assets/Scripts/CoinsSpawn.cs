using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawn : MonoBehaviour {

    private float _spawnDelay = 1f;
    private Queue<GameObject> coins;

    private Transform _donutModel;
    public GameObject coinPrefab;

    private const float _RADIUS_BIG = 1f;
    private const float _RADIUS_SMALL = 0.37f;

    private const int _coinsMax = 5;

    public GameObject coin;
    public GameObject coinRotator;
    public GameObject coinModel;

    // Use this for initialization
    void Start ()
    {
        _donutModel = GameObject.Find("donut_model").GetComponent<Transform>();
        coins = new Queue<GameObject>();
        StartCoroutine(SpawnCoins());
        StartCoroutine(DestroyCoins());
	}
	
	// Update is called once per frame
	void Update () {
	    	
	}

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            coin = Instantiate(coinPrefab, _donutModel);
            coinRotator = coin.transform.Find("rotator").gameObject;
            coinModel = coinRotator.transform.Find("model").gameObject;
            float coinModelAngle = Random.Range(0, 359);
            coinModel.transform.Rotate(new Vector3(0, coinModelAngle, 0));
            coinModelAngle = coinModelAngle / 180f * Mathf.PI;
            float x = Mathf.Sin(coinModelAngle);
            float z = Mathf.Cos(coinModelAngle);
            coinModel.transform.localPosition = new Vector3(x * _RADIUS_SMALL, 0, z * _RADIUS_SMALL);
            coinRotator.transform.localPosition = new Vector3(_RADIUS_BIG, 0, 0);
            float coinAngle = Random.Range(0, 359);
            coin.transform.Rotate(0, 0, coinAngle);
            coins.Enqueue(coin);
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private IEnumerator DestroyCoins()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);
            if (coins.Count > _coinsMax)
            {
                GameObject coin = coins.Dequeue();
                Destroy(coin);
            }
        }
    }

}
