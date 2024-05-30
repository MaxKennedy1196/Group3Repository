using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public int currentPickups;
    public int maxPickups;
    public bool levelComplete = false;

    public Text pickupText;

    public AudioSource[] audioSources;
    public float audioProximity = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LevelCompleteCheck();
        UpdateGUI();
        PlayAudioSamples();
    }

    public void LevelCompleteCheck(){

        if(currentPickups >= maxPickups)
            levelComplete = true;
        else
            levelComplete = false;
    }

    public void UpdateGUI(){
        pickupText.text = "Pickups: " + currentPickups + "/" + maxPickups;
    }
    
    public void PlayAudioSamples(){
        for(int i = 0; i < audioSources.Length; i++){
            if(Vector3.Distance(player.transform.position, audioSources[i].transform.position) <= audioProximity){
                if(!audioSources[i].isPlaying){
                    audioSources[i].Play();
                }
            }
        }
    }

}
