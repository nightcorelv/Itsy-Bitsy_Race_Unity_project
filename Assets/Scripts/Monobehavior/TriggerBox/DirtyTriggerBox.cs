using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyTriggerBox : MonoBehaviour
{

    public void changeDirtyLevel()
    {
        if (Core.PlayerDetails.player.GetComponent<Player>().dirtyLevel == DirtyLevelType.NoneDirt)
        {
            DirtyLevelType DirtyLevel = DirtyLevelType.HalfDirt;
            Core.PlayerDetails.ChangeDirtyLevel(DirtyLevel);
        }
        else if (Core.PlayerDetails.player.GetComponent<Player>().dirtyLevel == DirtyLevelType.HalfDirt)
        {
            DirtyLevelType DirtyLevel = DirtyLevelType.FullDirt;
            Core.PlayerDetails.ChangeDirtyLevel(DirtyLevel);
        }

    }
}
