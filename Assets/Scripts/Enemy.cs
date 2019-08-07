using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathFx;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        //print("Particles Collided with enemy " + gameObject.name);
        GameObject fx = Instantiate(deathFx, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
        scoreBoard.ScoreHit(scorePerHit);
    }
}
