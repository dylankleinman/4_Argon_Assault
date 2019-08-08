using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int remainingHits = 8;

    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider NonTriggerBoxCollider = gameObject.AddComponent<BoxCollider>();
        NonTriggerBoxCollider.isTrigger = false;
    }

    void OnParticleCollision()
    {
        //print("Particles Collided with enemy " + gameObject.name);
        // todo consider adding hit fx
        remainingHits--;
        if(remainingHits <= 1)
        {
            KillEnemy();
        }
        scoreBoard.ScoreHit(scorePerHit);
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFx, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
