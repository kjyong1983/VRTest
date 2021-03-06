﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWoman : MonoBehaviour {

    public float speed = 1.0f;
    public float damping = 3.0f;
    public GameObject fire;
    private Transform point;  

    private Animator anim;
    public bool isRun = false;
    public bool isRotating = true;

    public AudioSource audio;
    public bool isAudioPlayed = false;

    // Use this for initialization
    void Start () {
        point = GameObject.Find("Waypoints2").GetComponent<Transform>();
        anim = GetComponent<Animator>();
	}

    private void Update()
    {
        if (isRun)
        {
            Run();

        }

    }

    public void Run()
    {
        anim.SetBool("Run", true);
        if (!isAudioPlayed)
        {
            audio.Play();
            isAudioPlayed = true;
        }
        //Debug.Log("run");
        Vector3 direction = point.position - transform.position;

        if (direction.magnitude < 1f)
        {
            anim.SetBool("Run", false);
            Destroy(fire);

        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("woman ontriggerenter");
        if (other.CompareTag("WAY_POINT"))
        {
            anim.SetBool("Run", false);
            Destroy(fire);
        }
    }
}
