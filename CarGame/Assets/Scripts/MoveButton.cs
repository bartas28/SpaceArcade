using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour {

    [SerializeField]
    private float _horizontal;
    private float _horizontalDelta;
    [SerializeField]
    private float _HOLD_DELAY = 0.02f;
    private bool _hold;

    public float Horizontal
    {
        get
        {
            return _horizontal;
        }
    }

    // Use this for initialization
    void Start() {
        _horizontal = 0f;
        _hold = false;
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnPointerDown(string direction)
    {
        _hold = true;
        StartCoroutine(PointerHold(direction));
    }

    public void OnPointerUp()
    {
        _hold = false;
        _horizontal = 0f;
    }

    private IEnumerator PointerHold(string direction)
    {
        if (direction == "left")
        {
            _horizontalDelta = -0.05f;
        }
        else if (direction == "right")
        {
            _horizontalDelta = 0.05f;
        }
        else
        {
            _horizontal = 0f;
            Debug.Log("horizontal not assigned!");
        }
        while (_hold)
        {
            _horizontal += _horizontalDelta;
            if (_horizontal > 1f)
            {
                _horizontal = 1f;
            }
            else if (_horizontal < -1f)
            {
                _horizontal = -1f;
            }
            yield return new WaitForSeconds(_HOLD_DELAY);
        }
    }

}
