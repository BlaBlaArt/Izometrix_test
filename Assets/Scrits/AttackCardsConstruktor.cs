using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackCardsConstruktor : MonoBehaviour
{
    public Image CartPref, AttackImage;

    public Text AttackDamageText, StaminaText, CartText, CoolDownText;


    int atk;
   public int AttackDamage
    {
        set
        {
            atk = value;
            AttackDamageText.text = atk.ToString();
        }
        get
        {
            return atk;
        }
    }

    int cldn;
    public int TimeCoolDown
    {
        set
        {
            cldn = value;
            CoolDownText.text = cldn.ToString();
        }
        get
        {
            return cldn;
        }
    }

    int stam;
    public int StaminaNeeds
    {
        set
        {
            stam = value;
            StaminaText.text = stam.ToString();
        }
        get
        {
            return stam;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("boom");
    }
}
