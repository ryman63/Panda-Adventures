using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private ThirdPersonMovement tpm;
    void Start()
    {
        animator = GetComponent<Animator>();
        tpm = GetComponent<ThirdPersonMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetFloat("Speed", tpm.InputVector.z * tpm.speed);

        //animator.SetFloat("Height", tpm.DistanceGround());
     
            
    }
}
