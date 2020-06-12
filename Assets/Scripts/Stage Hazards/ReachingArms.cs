using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReachingArms : MonoBehaviour
{
    [SerializeField] private List<Transform> _reachingArmSpawnPoints = new List<Transform>();
    [SerializeField] private GameObject _reachingArmsPrefab;

    [SerializeField] private float _spawnDuration = 2f;

    private bool isSpawningReachingArms = true;

    void Start()
    {
        StartCoroutine(SpawnReachingArms());
    }

    private void Update()
    {
        
    }

    IEnumerator SpawnReachingArms()
    {
        while (isSpawningReachingArms)
        {
            int spawnPositionIndex = Random.Range(0, _reachingArmSpawnPoints.Count); // or Count can't remember right, anyway the length of the array list
            GameObject spawnedReachingArms = Instantiate(_reachingArmsPrefab, _reachingArmSpawnPoints[spawnPositionIndex].position, _reachingArmSpawnPoints[spawnPositionIndex].rotation);
            yield return new WaitForSeconds(_spawnDuration);
            Destroy(spawnedReachingArms);
        }

    }

}