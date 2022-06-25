using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake() {
        // Singleton Pattern: Only 1 instance of MusicPlayer.
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if(numMusicPlayers > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject); // Keep the existing MusicPlayer.
        }
    }
}
