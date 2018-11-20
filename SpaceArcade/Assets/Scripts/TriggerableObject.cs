using System.Collections;
using UnityEngine;

public class TriggerableObject : MonoBehaviour {

    protected float _duration;
    private int _self_counter;
    private bool _active;

    public bool Active
    {
        get { return _active; }
    }

    protected void Start()
    {
        deactivate_effect();
        _self_counter = 0;
    }

    public IEnumerator trigger() {
        activate();
        yield return new WaitForSeconds(_duration);
        deactivate();
    }

    public void clear()
    {
        deactivate(true);
    }

    private void activate()
    {
        _self_counter++;
        activate_effect();
    }

    private void deactivate(bool clear = false)
    {
        if (clear) _self_counter = 0;
        else _self_counter--;
        if (_self_counter <= 0)
        {
            _self_counter = 0;
            deactivate_effect();
        }
    }

    protected virtual void activate_effect()
    {
        _active = true;
    }

    protected virtual void deactivate_effect()
    {
        _active = false;
    }

}
