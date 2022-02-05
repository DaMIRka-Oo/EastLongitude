using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{
    private void OnMouseDown()
    {
      //  BattleManager.OnBattleStateChanged += BattleManagerChangeState;
        if (BattleManager.Instance.State == BattleState.Move)
        {
            BattleManager.Instance.UpdateBattleState(BattleState.General);
        }
        else
        {
            BattleManager.Instance.UpdateBattleState(BattleState.Move);
        }
        
    }

    private void BattleManagerChangeState(BattleState state)
    {
        Debug.Log(2);
        BattleManager.Instance.UpdateBattleState(BattleState.Move);
    }
}
