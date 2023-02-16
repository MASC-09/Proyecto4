using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject player;
    private Vector3 move; //Vector3 tiene eje 'x', 'y' y 'z'

    void Start()
    {
        move = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + move;

    }
}
