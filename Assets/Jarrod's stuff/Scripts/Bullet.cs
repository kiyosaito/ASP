using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private float _speed = 8f;
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
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if (transform.position.y > height / 2 + 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
