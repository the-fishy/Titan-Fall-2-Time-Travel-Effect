using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// STEP 3
using UnityEngine.Rendering;

public class TimeTravel : MonoBehaviour
{
    // STEP 1
    [SerializeField] GameObject present, past;
    [SerializeField] bool presentIsVisible = true;

    // STEP 2
    float timeToEffect = 0f;
    [SerializeField] float effectRatePerSecond = 1;

    // STEP 3
    [SerializeField] Volume effectVolume;
    [SerializeField] float transitionTime = 2f; // set to 0.2f

    void Start() {
        // STEP 1
        present.SetActive(presentIsVisible);
        past.SetActive(!presentIsVisible);
    }

    void Update()
    {
        // STEP 1 without time // step 2
        if (Input.GetButtonDown("Fire1") && Time.time >= timeToEffect){
            timeToEffect = Time.time + 1 / effectRatePerSecond;
            // STEP 1
            SwitchActiveLayers();
            // STEP 3
            PlayEffect();
        }
    }

    // STEP 1
    void SwitchActiveLayers(){
        presentIsVisible = !presentIsVisible;
        present.SetActive(!present.activeSelf);
        past.SetActive(!past.activeSelf);
    }

    // STEP 3
    void PlayEffect(){
        effectVolume.weight = 1;
        Invoke("TurnOffVolume", transitionTime);
    }

    // STEP 3
    void TurnOffVolume(){
        effectVolume.weight = 0;
    }
}
