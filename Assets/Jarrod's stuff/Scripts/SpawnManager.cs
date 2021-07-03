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

    void Start()
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
                    Spawner(enemyList[i]);
                    break;
                }
            }
            yield return new WaitForSeconds(_spawnRate);
        }
    }

    private void Spawner(GameObject enemyToSpawn)
    {
        GameObject newEnemy = Instantiate(enemyToSpawn, new Vector3(Random.Range(-8f, 8f), 6f), Quaternion.identity);
        newEnemy.transform.parent = _enemyContainer.transform;
    }

}
