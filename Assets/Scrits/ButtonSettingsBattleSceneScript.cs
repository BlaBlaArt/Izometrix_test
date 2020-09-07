using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSettingsBattleSceneScript : MonoBehaviour
{
    public Canvas MainScene;
    public Canvas AttackScene;

    public void AttackEnabled()
    {
        MainScene.enabled = false;
        AttackScene.enabled = true;
    }

    public void AttackDisabled()
    {
        MainScene.enabled = true;
        AttackScene.enabled = false;
    }
}
