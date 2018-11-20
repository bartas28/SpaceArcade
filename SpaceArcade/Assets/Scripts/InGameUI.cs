using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour {

    public Image fuelBar;
    private Player _player;

	// Use this for initialization
	void Start () {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        fuelBar.rectTransform.localScale = new Vector2(_player.fuel / GameConstants.FUEL_MAX, fuelBar.rectTransform.localScale.y);
    }
}
