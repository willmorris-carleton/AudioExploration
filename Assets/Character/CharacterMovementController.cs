using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class CharacterMovementController : MonoBehaviour
{

    public float speed = 1.0f;
    
    Rigidbody2D rb;
    EventInstance footstepsInstance;
    Animator animator;
    SpriteRenderer spriteRenderer;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        footstepsInstance = AudioManager.Instance.CreateEventInstance(AudioManager.Instance.footsteps);
    }

    void Update()
    {
        Vector3 movementDir = Vector3.zero;
        if (Input.GetKey(KeyCode.A)) movementDir += Vector3.left;
        if (Input.GetKey(KeyCode.D)) movementDir += Vector3.right;
        if (Input.GetKey(KeyCode.W)) movementDir += Vector3.up;
        if (Input.GetKey(KeyCode.S)) movementDir += Vector3.down;

        rb.velocity = speed*movementDir;

        bool isMoving = Vector3.SqrMagnitude(movementDir) > 0.0f;
        
        UpdateSound(isMoving);
        UpdateAnimation(isMoving);
        UpdateSprite(movementDir);
    }

    void UpdateSprite(Vector3 movementDir) {
        if (movementDir.x > 0.1f) {
            spriteRenderer.flipX = false;
        }
        else if (movementDir.x < -0.1f) {
            spriteRenderer.flipX = true;
        }
    }

    void UpdateSound(bool isMoving) {
        PLAYBACK_STATE playbackState;
        footstepsInstance.getPlaybackState(out playbackState);
        
        if (isMoving) {
            if (playbackState == PLAYBACK_STATE.STOPPED) {
                footstepsInstance.start();
            }
        }
        else {
            footstepsInstance.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }

    void UpdateAnimation(bool isMoving) {
        if (isMoving) {
            animator.SetBool("isMoving", true);
        }
        else {
            
            animator.SetBool("isMoving", false);
        }
    }
}
