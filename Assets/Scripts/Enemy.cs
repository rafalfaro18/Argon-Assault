using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parent; // Because an empty object only has this.
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 10;
    
    ScoreBoard scoreBoard; // Not serialized because there's only one.

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>(); // Only one score board, the first result.
        AddRigidBody();
    }

    void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
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
        vfx.transform.parent = parent;
        hitPoints--;
        scoreBoard.IncreaseScore(scorePerHit);
    }

    private void KillEnemy()
    {
            GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = parent;
            Destroy(gameObject);
    }

}
