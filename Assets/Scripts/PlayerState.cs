using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public UnityEngine.UI.Text hpText;
    public int hp = 5;

    public void DamageByEnemy()
    {
        --hp;

        if(hp > 0)
        {
            hpText.text = "HP : " + hp;
        }
        else
        {
            hpText.text = "YOU DIED.";
            hpText.color = Color.red;
        }
    }
}
