using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnLockExtrasTracker : MonoBehaviour
{
    [SerializeField] private bool canDoubleJump, canDash, canEnterBallMode, canDropBombs;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerExtrasTracker playerExtrasTracker;
    
    private void Start()
    {
        player = GameObject.Find("Player");
        playerExtrasTracker = player.GetComponent<PlayerExtrasTracker>();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SetTracker();
            Destroy(gameObject);
        }
    }

    private void SetTracker()
    {
        if (canDoubleJump) playerExtrasTracker.CanDoubleJump = true;
        if (canDash) playerExtrasTracker.CanDash = true;
        if (canEnterBallMode) playerExtrasTracker.CanEnterBallMode = true;
        if (canDropBombs) playerExtrasTracker.CanDropBombs = true;
    }
}
