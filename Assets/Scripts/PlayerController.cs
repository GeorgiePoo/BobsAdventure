using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
private Rigidbody playerRb;
public float jumpForce;
public float gravityModifier;
public bool isOnGround = true;
public bool gameOver = false;
public GameObject laserPrefab;
public GameObject firePoint;
private Animator playerAnim;
public AudioClip laserSound;
private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && gameOver == false)
        {
            Instantiate(laserPrefab, firePoint.transform.position, laserPrefab.transform.rotation);
            playerAudio.PlayOneShot(laserSound, 1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            gameOver=true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Dead", true);
        }
    }
}
