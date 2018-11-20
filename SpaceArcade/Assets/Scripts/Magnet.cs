using UnityEngine;

public class Magnet : TriggerableObject {

    [SerializeField]
    private GameObject _object;

    new void Start()
    {
        base.Start();
        _duration = GameConstants.MAGNET_DURATION;
    }

    protected override void activate_effect()
    {
        _object.SetActive(true);
        base.activate_effect();
    }

    protected override void deactivate_effect()
    {
        _object.SetActive(false);
        base.deactivate_effect();
    }

}
