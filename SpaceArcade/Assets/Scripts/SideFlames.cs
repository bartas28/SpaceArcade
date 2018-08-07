using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideFlames : MonoBehaviour {

    [SerializeField]
    private Transform _leftFlame;

    [SerializeField]
    private Transform _rightFlame;

    // Use this for initialization
    void Start () {
        _leftFlame = gameObject.transform.Find("flame_left").GetComponent<Transform>();
        _rightFlame = gameObject.transform.Find("flame_right").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void moveSide(float delta)
    {
        float l = 1 + 0.5f * delta * (1 - Mathf.Sign(delta)) / 2;
        float r = 1 - 0.5f * delta * (1 + Mathf.Sign(delta)) / 2;
        _leftFlame.localScale = new Vector3(l, l, l);
        _rightFlame.localScale = new Vector3(r, r, r);
    }

}
