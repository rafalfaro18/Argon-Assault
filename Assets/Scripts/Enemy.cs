using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent; // Because an empty object only has this.
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 30;
    
    ScoreBoard scoreBoard; // Not serialized because there's only one.

    void Start() {
        scoreBoard = FindObjectOfType<ScoreBoard>(); // Only one score board, the first result.
    }

    void Update () {
        GetComponent<MeshRenderer>().material.color = Color.white;
    }
    
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        KillEnemy();
    }

    private void ProcessHit()
    {
        scoreBoard.IncreaseScore(scorePerHit);
        GetComponent<MeshRenderer>().material.color = Color.magenta;
        hitPoints--;
    }

    private void KillEnemy()
    {
        if (hitPoints == 0) {
            GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = parent;
            Destroy(gameObject);
        }
    }

}
