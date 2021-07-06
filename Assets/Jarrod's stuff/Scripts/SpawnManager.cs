using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefabEnemy;
    [SerializeField]
    private GameObject _prefabVGroup;
    [SerializeField]
    private GameObject _prefabLineGroup;
    [SerializeField]
    private GameObject _prefabEnemyShipTracking;
    [SerializeField]
    private GameObject _prefabEnemyShipStatic;

    [SerializeField]
    private GameObject _enemyContainer;


    [SerializeField]
    private float _spawnRate;

    private float height;
    private float width;

    void Start()
    {
        CameraViewSize cSize = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraViewSize>();
        height = cSize.GetHeight();
        width = cSize.GetWidth();

        Invoke(nameof(StartGenerating), 3);
    }

    private void StartGenerating()
    {
        GameObject[] _enemyList = new GameObject[5];
        _enemyList[0] = _prefabEnemy;
        _enemyList[1] = _prefabVGroup;
        _enemyList[2] = _prefabLineGroup;
        _enemyList[3] = _prefabEnemyShipTracking;
        _enemyList[4] = _prefabEnemyShipStatic;

        //Weights must add up to 100
        int[] _enemyWeightList = new int[5];
        _enemyWeightList[0] = 50;
        _enemyWeightList[1] = 1;
        _enemyWeightList[2] = 1;
        _enemyWeightList[3] = 1;
        _enemyWeightList[4] = 47;

        StartCoroutine(RandomEnemy(_enemyList, _enemyWeightList));
    }

    private IEnumerator RandomEnemy(GameObject[] enemyList, int[] weightList)
    {
        for (int i = 1; i < weightList.Length; i++)
        {
            weightList[i] = weightList[i - 1] + weightList[i];
        }
        while (true)
        {
            int r = Random.Range(1, 101);
            Debug.Log("Random number generated: " + r);
            for (int i = 0; i < weightList.Length; i++)
            {
                Debug.Log("Checking weight: " + weightList[i]);
                if (r <= weightList[i])
                {
                    Spawn(enemyList[i]);
                    break;
                }
            }
            yield return new WaitForSeconds(_spawnRate);
        }
    }

    private void Spawn(GameObject enemy)
    {
        Instantiate(enemy, new Vector3(Random.Range(-width / 2f + 1f, width / 2f - 1f), height / 2f + 1f), Quaternion.identity, _enemyContainer.transform);
    }

    private void Spawn2(GameObject enemy, float pos, float delayTime)
    {
        //GameObject newEnemy = Instantiate(enemy, new Vector3()
    }

}
