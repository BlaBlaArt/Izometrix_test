using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSettingsBattleSceneScript : MonoBehaviour
{
    public Canvas MainScene;
    public Canvas AttackScene;

    public Image CardsPref;
    public CanvasRenderer ViewPortBattle;

    private void Start()
    {
        ViewPortBattle = GameObject.FindGameObjectWithTag("ViewPortAttack").GetComponent<CanvasRenderer>();

    }

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

    public void SpawnCards()
    {
        //AttackCardsConstruktor atackCard = new AttackCardsConstruktor();
        Image tmpCart = Instantiate<Image>(CardsPref);
        tmpCart.transform.SetParent(ViewPortBattle.transform);
        tmpCart.gameObject.GetComponent<AttackCardsConstruktor>().AttackDamage = 2;
        tmpCart.gameObject.GetComponent<AttackCardsConstruktor>().StaminaNeeds = 2;
        tmpCart.gameObject.GetComponent<AttackCardsConstruktor>().TimeCoolDown = 2;
    }
}
