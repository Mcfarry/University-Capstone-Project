using UnityEngine;

public abstract class RangerBaseState
{
    public abstract void EnterState(RangerStateManager ranger);
    public abstract void UpdateState(RangerStateManager ranger);
}
