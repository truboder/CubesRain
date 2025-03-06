using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private float _spawnDelay = 1.0f;
    [SerializeField] private Vector3 _spawnPosition;

    private void Start()
    {
        StartCoroutine(SpawningCubes());
    }

    private IEnumerator SpawningCubes()
    {
        var delay = new WaitForSeconds(_spawnDelay);

        while (true)
        {          
            yield return delay;

            Vector3 randomPosition = new Vector3(Random.Range(transform.position.x + _spawnPosition.x, transform.position.x - _spawnPosition.x), transform.position.y, Random.Range(transform.position.z + _spawnPosition.z, transform.position.z - _spawnPosition.z));

            Cube cube = _cubePool.Get();

            cube.transform.position = randomPosition;
        }
    }
}
