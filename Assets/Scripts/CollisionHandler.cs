using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) {
        Debug.Log(name + "--Collided with--" + other.gameObject.name);
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log($"{name} **Triggered by** {other.gameObject.name}");
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
