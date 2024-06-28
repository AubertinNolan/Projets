using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void Start()
    {
        offset = target.position - transform.position; //Calcule de la distance entre le joueur et la caméra
    }

    void Update()
    {
        transform.position = target.position - offset; //Permettre à la caméra de suivre le joueur;
    }
}
