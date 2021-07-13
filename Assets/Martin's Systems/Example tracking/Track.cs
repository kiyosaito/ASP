using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    float speed = 5f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 newDir = Vector3.RotateTowards(transform.forward, player.transform.position, speed * Time.deltaTime, 0.0f);

        Debug.DrawRay(transform.position, newDir, Color.red);

        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
