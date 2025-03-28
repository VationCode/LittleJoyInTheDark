using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Door : MonoBehaviour
{
    static public bool isOpen;
    public KeyObject.ID keyID;
    [SerializeField] Animator animator_Door;
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip sound_openFail;
    [SerializeField] AudioClip sound_opening;
    [SerializeField] AudioClip sound_Closing;

    public bool isUnlocked = true;
    public bool isOpened = false;

    public virtual void Open()
    {
        if (!isUnlocked)
        {
            audioSource.PlayOneShot(sound_openFail);
            isOpen = false;
            print("잠겨있음");
        } 
        else
        {
            isOpened = true;

            audioSource.PlayOneShot(sound_opening);
            //print($"Door Opened {keyID}");

            if (animator_Door)
            {
                animator_Door.SetTrigger("Open");
            }
        }
    }

    public virtual void Close()
    {
        isOpened = false;

        audioSource.PlayOneShot(sound_Closing);

        if (animator_Door)
        {
            animator_Door.SetTrigger("Close");
        }
    }

    public virtual void Unlock()
    {
        isUnlocked = true;
        //print($"Door Unlocked {keyID}");
    }
}
