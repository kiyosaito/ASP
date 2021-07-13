using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float timer = 10f;
    float timerCount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timerCount);
        timerCount++;
        if (timerCount < timer / 2)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (timerCount < timer)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else
        {
            timerCount = 0;
        }
    }


}
