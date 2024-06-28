using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController cc;
    //Variables pour le d�placement
    public float moveSpeed;
    public float jumpForce;
    public float gravity;
    //Vecteur direction souhait�e
    private Vector3 moveDir;
    private Animator anim;
    bool IsWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calcul de la direction
        moveDir = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDir.y, Input.GetAxis("Vertical") * moveSpeed);

        //Application de la gravit� sur l'axe y 
        moveDir.y -= gravity * Time.deltaTime;

        //Check de la barre espace && est au sol (�viter saut infini)
        if (Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            //Saut
            moveDir.y = jumpForce;
        }

        //Si on se d�place (si mouvement diff�rent de 0)
        if(moveDir.x != 0 || moveDir.z != 0)
        {
            IsWalking = true; //Le personnage marche
                             
            //On tourne le personnage dans la bonne direction
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(moveDir.x, 0, moveDir.z)), 0.05f);
        }
        else
        {
            IsWalking = false; //Le personnage s'arr�te de marcher 
        }

        anim.SetBool("IsWalking", IsWalking); //On indique � l'animator si on marche

        //On applique le d�placement
        cc.Move(moveDir * Time.deltaTime);
    }
}
