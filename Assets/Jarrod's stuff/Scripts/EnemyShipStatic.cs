using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipStatic : MonoBehaviour
{

    private float _initialYPos;
    private float _yMoveDistance;
    [SerializeField]
    private float _speed = 3f;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _yMoveDistance = Random.Range(2f, GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraViewSize>().GetHeight() / 2);
        _initialYPos = transform.position.y;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > _initialYPos - _yMoveDistance)
        {
            MoveDown();
        }
        else
        {
            TrackPlayer();
        }
    }

    private void MoveDown ()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }

    private void TrackPlayer ()
    {
        //float angle = Mathf.Atan2(_player.transform.position.y - transform.position.y, _player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        //Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 20f * Time.deltaTime);

        //Vector3 direction = (_player.transform.position - transform.position).normalized;
        Vector2 dir = _player.transform.position - transform.position;
        transform.right = dir;
    }
}
