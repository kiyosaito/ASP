using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{

    [SerializeField]
    private float _speed = 4f;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 4f)
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }
        else
        {
            if (_player.transform.position.x > transform.position.x + 0.15f)
            {
                transform.Translate(Vector3.right * _speed * Time.deltaTime);
            }
            else if (_player.transform.position.x < transform.position.x - 0.15f)
            {
                transform.Translate(Vector3.left * _speed * Time.deltaTime);
            }
        }
    }
}
