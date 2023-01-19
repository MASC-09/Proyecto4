using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{

   public GameObject Jugador;
    private Vector3 movimiento;
    void Start()
    {
        movimiento = transform.position - Jugador.transform.position;
    }
    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = Jugador.transform.position + movimiento;
    }
}
