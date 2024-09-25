using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.3f;
    [SerializeField] float moveSpeed = 18f;
    [SerializeField] float boostSpeed = 25f;
    [SerializeField] float bumpSpeed = 13f;
    [SerializeField] float boostDuration = 2f;
    [SerializeField] float bumpDuration = 1f;

    [SerializeField] float originalSpeed;
    private bool isBoosting;
    private bool isBumping;
    void Start()
    {
        originalSpeed = moveSpeed; 
    }
    void Update()
    {
        float movementAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;

        transform.Translate(0, movementAmount, 0);
        transform.Rotate(0, 0, -steerAmount);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag =="Bumps" && !isBumping && isBoosting)
            {
                StartCoroutine(BumpSpeedCoroutine());
            }    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="Boost" && !isBoosting)
        {
            StartCoroutine(BoostSpeedCoroutine()); 
        }
    }
    IEnumerator BoostSpeedCoroutine()
    {
        isBoosting = true;
        moveSpeed = boostSpeed;

        yield return new WaitForSeconds(boostDuration); 

        moveSpeed = originalSpeed; 
        isBoosting = false; 
    }
    IEnumerator BumpSpeedCoroutine()
    {
        isBumping = true;
        moveSpeed = bumpSpeed;

        yield return new WaitForSeconds(bumpDuration); 

        moveSpeed = originalSpeed; 
        isBumping = false; 
    }
}
