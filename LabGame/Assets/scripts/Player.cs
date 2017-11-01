using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Text time;
    public float timer = 10f;
    public GameObject loose;
    public GameObject win;
    public float speed = 1f;
    private Rigidbody2D rb;
    private bool control = true;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        //time = GetComponent<Text>();
        //Display();
        time.text = "TIME : ";
    }
	
	// Update is called once per frame
	void Update () {

        if (timer <= 0)
        {
            loose.SetActive(true);
            Debug.Log("Perdu !");
            control = false;
        }
        if (control)
        {
            timer -= Time.deltaTime;
            Display();
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
	}


    private void OnCollisionEnter2D(Collision2D col)
    {
        LayerMask lay = col.gameObject.layer;

        if (lay == LayerMask.NameToLayer("Exit"))
        {
            Debug.Log("Gagné !");
            win.SetActive(true);
            control = false;
        }
    }

    private void Display()
    {
        time.text = "TIME : " + Mathf.Round(timer);
    }

}
