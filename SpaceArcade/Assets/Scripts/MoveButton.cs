using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour {

    [SerializeField]
    private float _horizontal;
    private float _horizontalDelta;
    private float _BASE_HORIZONTAL = 0.05f;
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
        StartCoroutine(PointerRelease());
    }

    private IEnumerator PointerHold(string direction)
    {
        if (direction == "left")
        {
            _horizontalDelta = -_BASE_HORIZONTAL;
        }
        else if (direction == "right")
        {
            _horizontalDelta = _BASE_HORIZONTAL;
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

    private IEnumerator PointerRelease()
    {
        _horizontalDelta = -Mathf.Sign(_horizontal) * _BASE_HORIZONTAL;
        while (!_hold && _horizontal != 0)
        {
            if(_horizontal < _BASE_HORIZONTAL && _horizontal > -_BASE_HORIZONTAL)
            {
                _horizontal = 0f;
            }
            else
            {
                _horizontal *= 0.6f;
            }
            yield return new WaitForSeconds(_HOLD_DELAY);
        }
    }

}
