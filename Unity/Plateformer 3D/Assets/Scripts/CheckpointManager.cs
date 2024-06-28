using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Vector3 lastPoint;  

    void Start()
    {
        lastPoint = transform.position; //Le joueur apparaitra au dernier checkpoint sauvegardé
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "checkpoint")
        {
            lastPoint = transform.position; //On sauvegarde la position du joueur au moment d'activer le checkpoint
            other.gameObject.GetComponent<PieceAnimation>().enabled = true; //On fait tourner le crystal
        }
    }

    public void Respawn()
    {
        transform.position = lastPoint; //On attribue la valeur du checkpoint au respawn
        PlayerInfos.pi.SetHealth(3); //On remet la vie du joueur au max
    }
}
