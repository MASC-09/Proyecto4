using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{

    private Rigidbody2D rb;
    public float velocidad = 1;
    // public Text texto;
    public GameObject Objetos;
    private int Oro = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }
    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 desplazamiento = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(desplazamiento * velocidad);
    }
}


