using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float waitedTime;
    public float waitTimeToAttack = 3;
    public Animator animator;
    public GameObject bulletPrefab;
    public Transform launchSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        waitedTime = waitTimeToAttack;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitedTime <= 0)
        {
            waitedTime = 0;
            animator.Play("Attack");
            Invoke("LaunchBullet", 0.5f);
        }
        else
        {
            waitedTime -= Time.deltaTime;

        }
    }

    void LaunchBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(bulletPrefab, launchSpawnPoint.position, launchSpawnPoint.rotation);
    }
}
