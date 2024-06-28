using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMonsters : MonoBehaviour
{
    [Range(0.5f, 50)] //Permet d'augmenter grace a une jauge la distance de d�tection
    public float detectDistance = 3; //variable pour la d�tection du personnage
    public Transform[] points; //Tableau des diff�rents points de passage
    int destinationIndex = 0; //Permet de cr�er une routine des points attribu�s au monstre
    NavMeshAgent agent;
    Transform player;
    float runSpeed = 2f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        if (agent != null) 
        {
            agent.destination = points[destinationIndex].position; //On dit a l'agent (monstre) d'aller au point 
        }
    }
    private void Update()
    {
        Walk();
        SearchPlayer();
    }

    private void Walk()
    {
        float dist = agent.remainingDistance; //La distance restante entre le personnage et son point
        if (dist <= 0.05f) //Il n'est pas conseill� de mettre 0 pour �viter les bugs
        {
            destinationIndex++; //On passe au prochain point 
            if (destinationIndex > points.Length - 1) //Si on arrive au dernier point attribu� au monstre
            {
                destinationIndex = 0; //On reset le compteur de point pour revenir au 1er
            }
        }
        agent.destination = points[destinationIndex].position; //On dit au monstre d'y aller
    }

    private void SearchPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if(distanceToPlayer <= detectDistance)
        {
            agent.destination = player.position;
            agent.speed = runSpeed;
        }
        else
        {
            agent.destination = points[destinationIndex].position;
        }
    }

    private void OnDrawGizmosSelected() //Permet de dessiner la zone de d�tection du monstre (d�bug)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectDistance);
    }
}
