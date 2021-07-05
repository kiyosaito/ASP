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
    private TempVariables tp = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Y Screen Border: " + tp.yScreenBorder);
        _yMoveDistance = Random.Range(1, tp.yScreenBorder / 2);
        Debug.Log("Y distance: " + _yMoveDistance);
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
        //Debug.Log("Tracking player");
        //Vector3 target = _player.transform.position - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(target, Vector3.up);
        //transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }
}
