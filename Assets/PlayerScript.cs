using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;
    private float moveSpeed = 10.0f;
    private float cameraSpeed = 10.0f;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        //前に進む
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * moveSpeed);
            animator.SetBool("Walk", true);
        }
        //後ろに進む
        else if(Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * moveSpeed);
            animator.SetBool("Walk", true);
        }
        //右に進む
        else if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * moveSpeed);
            animator.SetBool("Walk", true);
        }
        //左に進む
        else if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * moveSpeed);
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
    }

    void Update()
    {
       if(Input.GetKeyUp(KeyCode.W)||
          Input.GetKeyUp(KeyCode.S)||
          Input.GetKeyUp(KeyCode.D)||
          Input.GetKeyUp(KeyCode.A))
       {
            rb.velocity = Vector3.zero;
       }

        //マウスでのカメラ操作処理
        if(Input.GetMouseButton(0))
        {
            float x = Input.GetAxis("Mouse X") * cameraSpeed;
            if(Mathf.Abs(x)>0.1f)
            {
                transform.RotateAround(transform.position, Vector3.up, x);
            }
        }
    }
}
