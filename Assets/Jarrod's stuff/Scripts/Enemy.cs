using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float _speed = 3f;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        CameraViewSize cSize = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraViewSize>();
        height = cSize.GetHeight();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -height / 2 - 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();

            if (player != null)
            {
                player.Damage(1);
            }
            Destroy(gameObject);
        }
    }
}
