using NUnit.Framework;
using System.Buffers;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shot : MonoBehaviour
{
    public InputAction shootAction;
    public InputAction reloadAction;

    public AudioClip gunshoot;
    public AudioClip empty;
    public AudioClip relase;
    public AudioClip reloade;
    private AudioSource audioSource;

    public float moveSpeed = 5f;
    bool relasesound = true;
    bool relodsound = false;
    float waitrelase = -1;
    float waitreload = -1;
    public int mag = 6;
    bool OneShootFlag = true;
    bool check = true;
    bool check1 = true;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        
        audioSource.playOnAwake = false; // Prevent the sound from playing on start

    }


    // Reference to the player's input action


    private void OnEnable()
    {
        // Enable the move action
        shootAction.Enable();
        reloadAction.Enable();
    }

    private void OnDisable()
    {
        // Disable the move action
        shootAction.Disable();
        reloadAction.Disable();
    }

    void Update()
    {   
        //Strza³ dodac wykonywanie on shootAction input
        Vector2 shootInput1;
        shootInput1 = shootAction.ReadValue<Vector2>();
        if (!OneShootFlag && shootInput1.x == 0.0)
        {
            OneShootFlag = true;
        }
        if(shootInput1.x < 0 && OneShootFlag && relasesound) 
        {
            OneShootFlag = false;
            if(mag > 0)
            {
                mag = mag - 1;
                audioSource.PlayOneShot(gunshoot);
            }
            else
            {
                audioSource.PlayOneShot(empty);
            }
        }

        //Reload to samo co wy¿ej
        float dpad = reloadAction.ReadValue<float>();

        if(relasesound && dpad > 0.5f)
        {

            relasesound = false;
            check1 = false;
            audioSource.PlayOneShot(relase);
            waitrelase = relase.length;
        }
        if (!check1)
        {
            waitrelase -= Time.deltaTime;
        }
        if (waitrelase < 0.0f && !check1)
        {
            relodsound = true;
            check1 = true;
            waitrelase = 1;
        }
        if (relodsound)
        {
            audioSource.PlayOneShot(reloade);
            waitreload = reloade.length;
            relodsound = false;
            check = false;
        }
        if (!check)
        {
            waitreload -= Time.deltaTime;
        }


        if(waitreload < 0.0f && !check)
        {
            relasesound = true;
            waitreload = 1;
            check = true;
            mag = 6;
        }



    }
}

