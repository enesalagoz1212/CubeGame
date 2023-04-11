using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed;
    public float xSpeed;
    public Vector3 startPosition;
    private TextMeshProUGUI skor_txt;
    int skor = 0;
    private void Start()
    {
        skor_txt = GameObject.Find("Canvas/tmpro").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        ForwardSpeed();
        HorizontalSpeed();
   
    }

    public void ForwardSpeed()
    {
        transform.position += Vector3.forward * Time.deltaTime * speed;
       
    }
    public void HorizontalSpeed()
    {
        Vector3 xPosition = new Vector3(1, 0, 0);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += xPosition * xSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += xPosition * xSpeed * Time.deltaTime * -1;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Barrier")
        {
            Invoke("OnLevelReset", 0.5f);
            
        }
        if (collision.gameObject.tag=="Gold")
        {
            Destroy(collision.gameObject);
            skor += 5;
            skor_txt.text = "Skor: " + skor.ToString();
        }
        if (collision.gameObject.tag == "Finish")
        {
            OnLevelReset();
        }
    }
   
    public void OnLevelReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
