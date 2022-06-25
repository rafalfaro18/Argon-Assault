using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent; // Because an empty object only has this.
    [SerializeField] int scorePerHit = 15;
    
    ScoreBoard scoreBoard; // Not serialized because there's only one.

    void Start() {
        scoreBoard = FindObjectOfType<ScoreBoard>(); // Only one score board, the first result.
    }
    
    void OnParticleCollision(GameObject other) {
        scoreBoard.IncreaseScore(scorePerHit);
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
