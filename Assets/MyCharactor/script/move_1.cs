using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
// https://stackoverflow.com/questions/62030512/cs0104-ambiguous-reference-between-system-numerics-vector3-and-unityengine-v
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;
using System;

public class move_1 : MonoBehaviour
{
    Animator anim;
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public float force = 700.0f;
    public float jumpForce = 700.0f;
    public float gravity = 20.0f;

    public bool isGrounded = false;

    public bool is_def = false;
    public bool is_dance = false;
    public bool is_walk = false;

    CharacterController controller;

    Vector3 inputDirection = Vector3.zero;
    Vector3 targetDirection = Vector3.zero;
    Vector3 moveDirection = Vector3.zero;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Animation Controller parameters for the character
        anim.SetBool("is_def", false);
        anim.SetBool("is_dance", false);
        anim.SetBool("is_walk", false);
        //Time to start the animation
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //get the input from the keyboard
        float x = -(Input.GetAxis("Vertical"));
        float z = Input.GetAxis("Horizontal");
        inputDirection = new Vector3(x, 0, z);

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("is_def", true);
            anim.SetBool("is_walk", true);
            Debug.Log("W key is pressed: " + is_walk);
        }
        else if (Input.GetKey(KeyCode.S))
        {

            anim.SetBool("is_def", true);
            anim.SetBool("is_walk", false);
            anim.SetBool("is_dance", false);
            Debug.Log("S key is pressed: " + is_def);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("is_def", true);
            anim.SetBool("is_dance", true);
            Debug.Log("D key is pressed: " + is_dance);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("is_dance", true);
            anim.SetBool("is_def", false);
            anim.SetBool("is_walk", false);
            Debug.Log("A key is pressed: " + is_dance);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            anim.SetBool("is_dance", false);
            anim.SetBool("is_walk", true);
            anim.SetBool("is_def", false);
            Debug.Log("Space key is pressed: " + is_walk);
        }
    }
}