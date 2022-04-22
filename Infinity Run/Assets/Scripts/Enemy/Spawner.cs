using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : PoolObjects
{
    [SerializeField] private SpawnBox[] _spawnBox;
    [SerializeField] private GameObject _prefab;

    private float _durations = 10;
    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        Initialization(_prefab);

        _waitForSeconds = new WaitForSeconds(0.7f);

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {

        for (int i = 0; i < _durations; i++)
        {
           if(TryGetObject(out GameObject enemy))
            {
                int spawnPointsNumber = Random.Range(0,_spawnBox.Length);

                SetEnemy(enemy,_spawnBox[spawnPointsNumber].transform.position);

                _durations++;
            }

            yield return _waitForSeconds;
        }
    }
    
    private void SetEnemy(GameObject enemy,Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;    
    }
}
