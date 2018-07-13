using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorusSpawn : MonoBehaviour {

    [SerializeField]
    private float _spawnDelay = 1f;
    private Queue<GameObject> objects;

    private Transform _donutModel;
    public GameObject objectPrefab;

    private const float _RADIUS_BIG = 1f;
    private const float _RADIUS_SMALL = 0.37f;

    [SerializeField]
    private const int _objectsMax = 5;

    [SerializeField]
    private bool _preSpawn;
    public GameObject preObjectPrefab;
    private float _preSpawnDelay = 2f;

    void Start ()
    {
        _donutModel = GameObject.Find("donut_model").GetComponent<Transform>();
        objects = new Queue<GameObject>();
        StartCoroutine(SpawnObjects());
        StartCoroutine(DestroyObjects());
	}	

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            float objectModelAngle = Random.Range(0, 359);
            float objectModelAngleRad = objectModelAngle / 180f * Mathf.PI;
            float x = Mathf.Sin(objectModelAngleRad);
            float z = Mathf.Cos(objectModelAngleRad);
            float objectAngle = Random.Range(0, 359);
            if (_preSpawn)
            {
                GameObject preObj = Instantiate(preObjectPrefab, _donutModel);
                GameObject preObjectRotator = preObj.transform.Find("rotator").gameObject;
                GameObject preObjectModel = preObjectRotator.transform.Find("model").gameObject;
                //rotation on small circle
                preObjectModel.transform.Rotate(new Vector3(0, objectModelAngle, 0));
                //position on small circle
                preObjectModel.transform.localPosition = new Vector3(x * _RADIUS_SMALL, 0, z * _RADIUS_SMALL);
                //rotation on big circle
                preObjectRotator.transform.localPosition = new Vector3(_RADIUS_BIG, 0, 0);
                preObj.transform.Rotate(0, 0, objectAngle);
                yield return new WaitForSeconds(_preSpawnDelay);
                Destroy(preObj);
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
            objects.Enqueue(obj);
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private IEnumerator DestroyObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);
            if (objects.Count > _objectsMax)
            {
                GameObject obj = objects.Dequeue();
                Destroy(obj);
            }
        }
    }

}
