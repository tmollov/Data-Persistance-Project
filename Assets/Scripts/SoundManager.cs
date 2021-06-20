using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Sprite soundOn;
    public Sprite soundOff;
    public Image soundSwitcher;
    public bool isSoundEnabled = true;

    public static SoundManager Instance;

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void SwitchSound()
    {
        if (isSoundEnabled)
        {
            soundSwitcher.sprite = soundOff;
        }
        else
        {
            soundSwitcher.sprite = soundOn;
        }

        isSoundEnabled = !isSoundEnabled;
    }
}