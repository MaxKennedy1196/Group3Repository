using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject player;

    // Pickup and Level Completion Logic
    public int currentPickups = 0;
    public int maxPickups = 5;
    public bool levelComplete = false;

    public Text pickupText;

    // Audio Proximity Logic
    public AudioSource[] audioSources;
    public float audioProximity = 5.0f;

    void Start() {
        if (pickupText == null) {
            pickupText = GameObject.FindWithTag("PickupText").GetComponent<Text>();
            // Ensure your Text object has the tag "PickupText"
        }
    }

    // Update is called once per frame
    void Update() {
        LevelCompleteCheck();
        UpdateGUI();
        PlayAudioSamples();
    }

    private void LevelCompleteCheck() {
        if (currentPickups >= maxPickups)
            levelComplete = true;
        else
            levelComplete = false;
    }

    private void UpdateGUI() {
        if (pickupText != null) {
            pickupText.text = "Pickups: " + currentPickups + "/" + maxPickups;
        } else {
            Debug.LogError("Pickup Text is not assigned.");
        }
        Debug.Log("Updated GUI: " + currentPickups + "/" + maxPickups);
    }

    // Loop for playing audio proximity events - AudioSource based
    private void PlayAudioSamples() {
        for (int i = 0; i < audioSources.Length; i++) {
            if (Vector3.Distance(player.transform.position, audioSources[i].transform.position) <= audioProximity) {
                if (!audioSources[i].isPlaying) {
                    audioSources[i].Play();
                }
            }
        }
    }
}
