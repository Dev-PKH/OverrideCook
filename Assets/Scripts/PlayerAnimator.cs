using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerAnimator : NetworkBehaviour

{
    private const string IS_WALKING = "IsWalking";

    [SerializeField] private Player player;
    
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsOwner)
        {
            return;
        }

        anim.SetBool(IS_WALKING, player.IsWalking());
    }
}
