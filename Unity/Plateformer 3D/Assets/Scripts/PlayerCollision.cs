using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public GameObject pickupEffect;
    public GameObject mobEffect;
    private bool canInstantiate = true;
    private bool isInvincible = false;
    public GameObject cam1;
    public GameObject cam2;
    public AudioClip hitSound;
    AudioSource audioSource;
    public SkinnedMeshRenderer rend;
    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin") //on a touché une pièce
        {
            audioSource.PlayOneShot(hitSound);
            PlayerInfos.pi.GetCoins();
            Instantiate(pickupEffect, other.transform.position, Quaternion.identity); //Instancier l'effet de particule sur la pièce
            Destroy(other.gameObject);  //Enlever la pièce de l'écran
        }

        if(other.gameObject.name == "FinNiveau") //On touche le cube de fin de niveau
        {
            print("Score final :" + PlayerInfos.pi.GetScore());
        }

        if (other.gameObject.tag == "Cam1") //on a touché la hitbox de la caméra 1
        {
            cam1.SetActive(true); //Donc on active la caméra 1
        }
        
        if (other.gameObject.tag == "Cam2") //on a touché la hitbox de la caméra 2
        {
            cam2.SetActive(true);
        }

        if (other.gameObject.tag == "fall")
        {
            //Faire une fonction respawn OU
            SceneManager.LoadScene(0); //Le numéro de la scène selon le build settings dans Unity
            //SceneManager.LoadScene("Level1") (le nom de la scène)
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //On recharge complètement la scène du début

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cam1") //on sort de la hitbox de la caméra 1
        {
            cam1.SetActive(false);
        }
        
        if (other.gameObject.tag == "Cam2") //on sort de la hitbox de la caméra 2
        {
            cam2.SetActive(false);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        //Si le monstre me touche
        if(collision.gameObject.tag == "Hurt" && !isInvincible)
        {
            print("Aie");
            isInvincible = true;
            PlayerInfos.pi.SetHealth(-1);
            StartCoroutine("ResetInvincible");
        }
        //Si je saute sur le monstre
        if (collision.gameObject.tag == "Mob" && canInstantiate)
        {
            canInstantiate = false;
            audioSource.PlayOneShot(hitSound);
            Instantiate(mobEffect, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject.transform.parent.gameObject, 0.1f);
            StartCoroutine("ResetInstantiate"); //Méthode pour appeler un IEnumerator
        }    
    }

    IEnumerator ResetInstantiate() //Permet d'éviter d'écraser un monstre X fois d'affilé
    {
        yield return new WaitForSeconds(0.8f);
        canInstantiate = true;
    }
    IEnumerator ResetInvincible() //Permet de rendre invincible et de faire clignoter le personnage
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.2f);
            rend.enabled = !rend.enabled;
        }
        yield return new WaitForSeconds(0.2f);
        rend.enabled = true;
        isInvincible = false;
    }
}
