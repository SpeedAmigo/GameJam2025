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
        _timeRemaining = _roundTime;
        StartCoroutine(RoundTimer()); 
    }

    private void SpawnEnemies()
    {
        int enemiesToSpawn = Mathf.Min(_enemiesToSpawn, _seats.Count);
        
        List<int> randomIndices = new List<int>();
        
        while (_spawnedEnemies.Count < enemiesToSpawn)
        {
            int randomIndex = Random.Range(0, _seats.Count);
            if (!randomIndices.Contains(randomIndex))
            {
                randomIndices.Add(randomIndex);
            }
        }
        
        foreach (int index in randomIndices)
        {
            GameObject enemy = Instantiate(_enemyPrefab, _seats[index].transform.position, Quaternion.identity);
            _spawnedEnemies.Add(enemy);
        }
    }
    
    private IEnumerator RoundTimer()
    {
        while (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
            yield return null;  
        }
        
        RoundEnd();
    }
    
    public void RoundEnd()
    {
        Debug.Log("Runda " + GameLoopManager.Instance.CurrentRound + " zakończona!");
        
        foreach (GameObject enemy in _spawnedEnemies)
        {
            Destroy(enemy);  // Zniszczenie obiektu przeciwnika
        }
        _spawnedEnemies.Clear();
        
        _timeRemaining = _roundTime;
        IncreaseEnemiesToSpawn();
        StartCoroutine(RoundTimer());
        SpawnEnemies();
    }

    private void IncreaseEnemiesToSpawn()
    {
        _enemiesToSpawn++;
    }
    
}
