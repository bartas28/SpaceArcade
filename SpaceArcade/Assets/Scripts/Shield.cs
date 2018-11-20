using UnityEngine;

public class Shield : TriggerableObject {

    [SerializeField]
    private GameObject _object;

    new void Start()
    {
        base.Start();
        _duration = GameConstants.SHIELD_DURATION;
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
