using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoundManager : MonoBehaviour
{
    [Header("Clock")]
    [SerializeField] private float _roundTime;
    [SerializeField] private TMP_Text _timerText;
    private float _timeRemaining;
    private int _currentRound;
    
    [Header("Round")]
    [SerializeField] private TMP_Text _roundText;
    
    [Header("Flags")]
    private bool _isRoundEnded = false;
    
    [SerializeField] private List<GameObject> _seats = new List<GameObject>();
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();
    [SerializeField] private GameObject _enemyPrefab;
    private List<GameObject> _spawnedEnemies = new List<GameObject>();
    private int _enemiesToSpawn = 5;

    private void Awake()
    {
        _timeRemaining = _roundTime;
    }

    void Start()
    {
        SpawnEnemies();
    }

    private void Update()
    {
        CountdownTimer();
    }

    private void CountdownTimer()
    {
        if(_timeRemaining > 0)
            _timeRemaining -= Time.deltaTime;

        if (_timeRemaining <= 0 && !_isRoundEnded)
            StartCoroutine(ResetRound());
        
        _timerText.text = _timeRemaining.ToString("0.0");
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
            GameObject enemy = Instantiate(_enemyPrefab, _seats[index].transform.position, Quaternion.identity);
            _spawnedEnemies.Add(enemy);
        }
    }

    private void ClearSpawnedEnemies()
    {
        foreach (GameObject enemy in _spawnedEnemies)
        {
            Destroy(enemy);
        }
        _spawnedEnemies.Clear(); 
    }
    
    private void IncreaseEnemiesToSpawn()
    {
        _enemiesToSpawn += 3;
    }

    private IEnumerator ResetRound()
    {
        _isRoundEnded = true;
        IncreaseEnemiesToSpawn();
        ClearSpawnedEnemies();
        _roundText.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(2f);
        
        _roundText.gameObject.SetActive(false);
        SpawnEnemies();
        _timeRemaining = _roundTime;
        _isRoundEnded = false;
    }
}
