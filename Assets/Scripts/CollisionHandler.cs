using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) {
        Debug.Log(name + "--Collided with--" + other.gameObject.name);
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log($"{name} **Triggered by** {other.gameObject.name}");
    }
}
