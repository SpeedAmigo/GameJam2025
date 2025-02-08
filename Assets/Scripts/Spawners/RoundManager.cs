using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private float _roundTime = 5f;
    private float _timeRemaining;
    private int _currentRound;
    
    [SerializeField] private List<GameObject> _seats = new List<GameObject>();
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();
    [SerializeField] private GameObject _enemyPrefab;
    private List<GameObject> _spawnedEnemies = new List<GameObject>();
    private int _enemiesToSpawn = 5;

    void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        int enemiesToSpawn = Mathf.Min(_enemiesToSpawn, _seats.Count);
        
        List<int> randomIndices = new List<int>();
        while (randomIndices.Count < enemiesToSpawn)
        {
            int randomIndex = Random.Range(0, _seats.Count);
            if (!randomIndices.Contains(randomIndex))
            {
                randomIndices.Add(randomIndex);
            }
        }
        
        foreach (int index in randomIndices)
        {
            Instantiate(_enemyPrefab, _seats[index].transform.position, Quaternion.identity);
        }
    }
}
