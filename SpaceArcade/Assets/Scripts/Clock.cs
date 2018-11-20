using UnityEngine;

public class Clock : TriggerableObject
{

    new void Start()
    {
        base.Start();
        _duration = GameConstants.CLOCK_DURATION;
    }

    protected override void activate_effect()
    {
        Time.timeScale = GameConstants.CLOCK_TIME_SCALE;
        Debug.Log("CLOCK");
        base.activate_effect();
    }

    protected override void deactivate_effect()
    {
        Time.timeScale = GameConstants.NORMAL_TIME_SCALE;
        Debug.Log("CLOCK");
        base.deactivate_effect();
    }

}
