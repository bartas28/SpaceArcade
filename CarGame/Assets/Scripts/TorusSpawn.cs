using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorusSpawn : MonoBehaviour {

    [SerializeField]
    private bool _preSpawn;

    private Transform _donutModel;
    public GameObject objectPrefab;
    public GameObject preObjectPrefab;

    private const float _RADIUS_BIG = 1f;
    private const float _RADIUS_SMALL = 0.37f;

    [SerializeField]
    private const int _objectsMax = 5;
    private int _objectsCount;

    private float _spawnDelay = 2f;

    void Start ()
    {
        _donutModel = GameObject.Find("donut_model").GetComponent<Transform>();
        _objectsCount = 0;
        StartCoroutine(ObjectsSpawner());
	}	

    private IEnumerator ObjectsSpawner()
    {
        while (true)
        {
            if(_objectsCount < _objectsMax)
            {
                StartCoroutine(SpawnObject());
            }
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private IEnumerator SpawnObject()
    {
        _objectsCount++;
        List<GameObject> stageObjects = new List<GameObject>();
        GameObject lastStage = null;
        if (_preSpawn)
        {
            stageObjects.Add(preObjectPrefab);
        }
        stageObjects.Add(objectPrefab);
        float objectModelAngle = Random.Range(0, 359);
        float objectModelAngleRad = objectModelAngle / 180f * Mathf.PI;
        float x = Mathf.Sin(objectModelAngleRad);
        float z = Mathf.Cos(objectModelAngleRad);
        float objectAngle = Random.Range(0, 359);
        foreach (GameObject objectPrefab in stageObjects)
        {
            if(lastStage != null)
            {
                Destroy(lastStage);
            }
            GameObject obj = Instantiate(objectPrefab, _donutModel);
            GameObject objectRotator = obj.transform.Find("rotator").gameObject;
            GameObject objectModel = objectRotator.transform.Find("model").gameObject;
            //rotation on small circle
            objectModel.transform.Rotate(new Vector3(0, objectModelAngle, 0));
            //position on small circle
            objectModel.transform.localPosition = new Vector3(x * _RADIUS_SMALL, 0, z * _RADIUS_SMALL);
            //rotation on big circle
            objectRotator.transform.localPosition = new Vector3(_RADIUS_BIG, 0, 0);
            obj.transform.Rotate(0, 0, objectAngle);
            //specific spawn time for each stage
            yield return new WaitForSeconds(objectPrefab.GetComponent<SpawnConfigs>().LifeTime);
            lastStage = obj;
        }
        _objectsCount--;
        Destroy(lastStage);
    }

}
