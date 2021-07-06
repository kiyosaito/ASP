using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{

    private Dictionary<GameObject, float> bgLayers;

    void Awake()
    {

        bgLayers = new Dictionary<GameObject, float>
        {
            { GameObject.FindGameObjectWithTag("BGNebula1"), 0.3f },
            { GameObject.FindGameObjectWithTag("BGNebula2"), 0.3f },
            { GameObject.FindGameObjectWithTag("BGStarsSmall1"), 1f },
            { GameObject.FindGameObjectWithTag("BGStarsSmall2"), 1f },
            { GameObject.FindGameObjectWithTag("BGStarsBig1"), 3f },
            { GameObject.FindGameObjectWithTag("BGStarsBig2"), 3f }
        };

    }

    void Update()
    {
        foreach (var item in bgLayers)
        {
            item.Key.transform.Translate(Vector3.down * Time.deltaTime * item.Value);
            if (item.Key.transform.position.y < -item.Key.GetComponent<SpriteRenderer>().size.y)
            {
                item.Key.transform.position = new Vector3(0, item.Key.transform.position.y + item.Key.GetComponent<SpriteRenderer>().size.y * 2);
            }
        }
    }
}
