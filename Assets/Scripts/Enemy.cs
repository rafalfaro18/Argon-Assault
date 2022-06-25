using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 10;
    
    ScoreBoard scoreBoard; // Not serialized because there's only one.
    GameObject parentGameObject;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>(); // Only one score board, the first result.
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidBody();
    }

    void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        //rb.constraints = RigidbodyConstraints.FreezeAll; // Not in the course. Otherwise enemies float.
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints < 1) {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        hitPoints--;
        scoreBoard.IncreaseScore(scorePerHit);
    }

    private void KillEnemy()
    {
            GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = parentGameObject.transform;
            Destroy(gameObject);
    }

}
