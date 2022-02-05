using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{
    private void OnMouseDown()
    {
      //  BattleManager.OnBattleStateChanged += BattleManagerChangeState;
        BattleManager.Instance.UpdateBattleState(BattleState.Move);
    }

    private void BattleManagerChangeState(BattleState state)
    {
        Debug.Log(2);
        BattleManager.Instance.UpdateBattleState(BattleState.Move);
    }
}
