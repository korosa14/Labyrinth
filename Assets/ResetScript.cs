using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    Rigidbody playerRB;
    Vector3 initPos;
    Quaternion initRot;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = this.gameObject.GetComponent<Rigidbody>();

        initPos = playerRB.transform.position;
        initRot = playerRB.transform.rotation;
    }

    public void OnClickReset()
    {
        playerRB.transform.position = initPos;
        playerRB.transform.rotation = initRot;

        playerRB.velocity = Vector3.zero;
        playerRB.angularVelocity = Vector3.zero;

        GameManager.countdownSeconds = 3 * 60;

        playerRB.ResetInertiaTensor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
