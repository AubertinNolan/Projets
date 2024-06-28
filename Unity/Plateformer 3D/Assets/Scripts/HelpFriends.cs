using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HelpFriends : MonoBehaviour
{
    GameObject cage;
    public TextMeshProUGUI infoTxt;
    bool canOpen = false;
    public TextMeshProUGUI friendsLeft;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "cage")
        {
            canOpen = true;
            cage = other.gameObject;
            infoTxt.text = "Appuyer sur E pour ouvrir la cage";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "cage")
        {
            canOpen = false;
            cage = null;
            infoTxt.text = "";
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canOpen)
        {
            
            iTween.ShakeScale(cage, new Vector3(100, 100, 100), 1f);
            cage.transform.GetChild(0).gameObject.GetComponent<Canvas>().enabled = true;
            Destroy(cage.GetComponent<MeshRenderer>(), 1.2f);
            Destroy(cage.GetComponent<BoxCollider>(), 1.2f);
        }
    }
}
