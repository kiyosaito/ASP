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
    private GameObject _enemyContainer;
    [SerializeField]
    private float _spawnRate;
    private enum SpawnType
    {
        Single,
        V,
        Line,
    }


    void Start()
    {
        StartCoroutine(SelectEnemy());
    }

    //Spawns a single enemy 80% of the time, something else 20%
    private IEnumerator SelectEnemy()
    {
        while (true)
        {
            switch (Random.Range(0, 5))
            {
                case 0:
                    SpawnSingle();
                    break;
                case 1:
                    SpawnSingle();
                    break;
                case 2:
                    SpawnSingle();
                    break;
                case 3:
                    SpawnSingle();
                    break;
                case 4:
                    SpawnGroup(Random.Range(1, System.Enum.GetNames(typeof(SpawnType)).Length));
                    break;
            }
            yield return new WaitForSeconds(_spawnRate);
        }
    }

    private void Spawner(GameObject enemyToSpawn)
    {
        GameObject newEnemy = Instantiate(enemyToSpawn, new Vector3(Random.Range(-8f, 8f), 6f), Quaternion.identity);
        newEnemy.transform.parent = _enemyContainer.transform;
    }

    private void SpawnSingle()
    {
        Spawner(_prefabEnemy);
    }

    private void SpawnGroup(int i)
    {
        switch (i)
        {
            case 1:
                Spawner(_prefabVGroup);
                Debug.Log("Spawning V Group");
                break;
            case 2:
                Spawner(_prefabLineGroup);
                Debug.Log("Spawning Line Group");
                break;
            default:
                Debug.Log("Spawning nothing");
                break;
        }
    }

}
