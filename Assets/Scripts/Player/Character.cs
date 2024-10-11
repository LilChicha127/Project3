using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    private Rigidbody rb;
    
    public bool isGround;
    public int Health = 3;
    public float cd = 10;
    private GameObject loseSc;
    
    public float slowdownFactor = 20;
    private void Start()
    {
        Tempik.currentScene = SceneManager.GetActiveScene().buildIndex;
        rb = GetComponent<Rigidbody>();
        loseSc = GameObject.Find("LoseScene"); 
        loseSc.SetActive(false);
        Time.timeScale = 1f;
        
    }
    public void Jump(int power)
    {
        if (isGround)
        {
            rb.AddForce(Vector3.up * power);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
            // rb.velocity = Vector3.zero;
            rb.AddForce(-rb.velocity * slowdownFactor, ForceMode.Acceleration);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Win")
        {
            if (Tempik.currentScene+1 >= Tempik.tempScene)
            {
                Tempik.tempScene = Tempik.currentScene;
                Tempik.maxOpenScene = Tempik.tempScene;
                PlayerPrefs.SetInt("maxScene", Tempik.maxOpenScene);
                PlayerPrefs.SetInt("currentScene", Tempik.currentScene);
                PlayerPrefs.SetInt("tempScene", Tempik.tempScene);
                
            }
            else
            {
                Debug.Log("nit");
            }
            
            //Tempik.maxOpenScene = Tempik.tempScene;
            Tempik.currentScene = SceneManager.GetActiveScene().buildIndex;
            



            
            Win(1);
        }
        if (other.gameObject.tag == "lose")
        {
            Tempik.currentScene = SceneManager.GetActiveScene().buildIndex;
            loseSc.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        if (other.gameObject.tag == "Final")
        {
            Win(1);
        }
    }
    public void Move(int Speed)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
     transform.Translate(movement * Speed * Time.deltaTime);
        //rb.MovePosition(transform.position + movement * Speed * Time.deltaTime);
        
      
    }
    
    public void Lose()
    {
        if(Health > 1)
        {
            Health -= 1;
        }
        else
        {
            //GameObject.Find("LoseScene").SetActive(true);
            loseSc.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }
    
    public void Win(int nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }
}
