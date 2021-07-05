using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{

    private void Start()
    {
        Debug.Log("Test camera");
        Camera cam = FindObjectOfType<Camera>();
        Debug.Log("Height: " + 2f * cam.orthographicSize);
        Debug.Log("Width: " + 2f * cam.orthographicSize * cam.aspect);
    }

    public IEnumerator Shake(float dur, float mag)
    {
        Vector3 pos = transform.position;

        float elapsed = 0f;

        while (elapsed < dur)
        {

            float x = Random.Range(-1f, 1f) * mag;
            float y = Random.Range(-1f, 1f) * mag;

            transform.position = new Vector3(x, y, -10f);
            elapsed += Time.deltaTime;
            yield return 0;
        }

        transform.position = pos;
    }
}
