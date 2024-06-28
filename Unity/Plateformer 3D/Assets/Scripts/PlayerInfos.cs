using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; //utiliser des éléments d'interface

public class PlayerInfos : MonoBehaviour
{
    public static PlayerInfos pi;
    public int nbCoins = 0;
    public int playerHealth = 3;
    public int scoreFinal;
    public Image[] hearts;
    public TextMeshProUGUI coinsTxt;
    public TextMeshProUGUI scoreTxt;
    public CheckpointManager checkPoint;

    private void Awake()
    {
        pi = this;
    }

    public void SetHealth(int val)
    {
        playerHealth += val;
        if (playerHealth > 3)
        {
            playerHealth = 3;
        }
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            checkPoint.Respawn();
        }
        SetHealthBar();
    }

    public void SetHealthBar() 
    {
        foreach(Image img in hearts) //On vide la barre de vie
        {
            img.enabled = false;
        }

        for (int i=0; i<playerHealth; i++) //On met le bon nombre de coeurs
        {
            hearts[i].enabled = true;
        }
    }

    public void GetCoins()
    {
        nbCoins++;
        coinsTxt.text = nbCoins.ToString(); //ou coinsTxt.text = ""+nbCoins;
    }

    public int GetScore()
    {
        scoreFinal = (nbCoins * 1000) + (playerHealth * 10000);

        scoreTxt.text = "Score final : " + scoreFinal;
        return scoreFinal;
    }
}
