using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private KeyCode _changeColourButton;
    [SerializeField]
    private float _fireRate = 0.3f;
    private enum PlayerColour
    {
        White,
        Black
    }
    private PlayerColour playerState;
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private GameObject _prefabBullet;


    // Start is called before the first frame update
    void Start()
    {
        _changeColourButton = KeyCode.Space;
        playerState = PlayerColour.White;
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(AutoFire());
    }


    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown(_changeColourButton))
        {
            ChangeColour();
        }


    }


    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(_speed * Time.deltaTime * new Vector3(horizontalInput, verticalInput, 0));
    }

    IEnumerator AutoFire()
    {
        while(true)
        {
            yield return new WaitForSeconds(_fireRate);

            Instantiate(_prefabBullet, new Vector3(transform.position.x, transform.position.y + 0.5f, 0), Quaternion.identity);
        }
    }

    private void ChangeColour()
    {
        if (playerState == PlayerColour.White)
        {
            _spriteRenderer.color = Color.black;
            playerState = PlayerColour.Black;
        }
        else
        {
            _spriteRenderer.color = Color.white;
            playerState = PlayerColour.White;
        }
    }
}