﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;

public class HandAnimationController : MonoBehaviour {

    public HandRole handRole;
    Animator animator;
    public enum AnimationState { Rest, SphereGrab, StickGrab, PinchGrab }
    AnimationState state;

	void Start () {
        animator = GetComponent<Animator>();
        state = AnimationState.Rest;
    }
	
	// Update is called once per frame
	void Update ()
    {
        SetHandAnimation();
    }

    private void SetHandAnimation()
    {
        if (ViveInput.GetPress(handRole, ControllerButton.Trigger))
        {
            state = AnimationState.StickGrab;
        }
        else if (ViveInput.GetPress(handRole, ControllerButton.Grip))
        {
            state = AnimationState.SphereGrab;
        }
        else if (ViveInput.GetPress(handRole, ControllerButton.Pad))
        {
            state = AnimationState.PinchGrab;
        }
        else
        {
            state = AnimationState.Rest;
        }

        animator.SetInteger("AnimationState", (int)state);
    }
}
