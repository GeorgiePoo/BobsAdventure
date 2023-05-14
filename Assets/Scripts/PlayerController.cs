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
public float fireRate;
float nextFire;
public int currentClip, maxClipSize = 10, currentAmmo, maxAmmoSize = 20;

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
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameOver == false)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && gameOver == false && Time.time > nextFire && currentClip > 0)
        {
            nextFire = Time.time + fireRate;
            Instantiate(laserPrefab, firePoint.transform.position, laserPrefab.transform.rotation);
            playerAudio.PlayOneShot(laserSound, 1.0f);
            currentClip--;
        }

        if(Input.GetKeyDown(KeyCode.R) && gameOver == false)
        {
            Reload();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Platform"))
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

    public void Reload()
    {
        int reloadAmount = maxClipSize - currentClip; //how many bullets to refill clip
        reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo;
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;
    }

    public void AddAmmo (int ammoAmount)
    {
        currentAmmo += ammoAmount;
        if(currentAmmo > maxAmmoSize)
        {
            currentAmmo = maxAmmoSize;
        }
    }
}
