using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundIcon : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.Instance.SwitchSound();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SoundManager.Instance.SwitchSound();
        }
    }
}