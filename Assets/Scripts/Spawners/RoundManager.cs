using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoundManager : MonoBehaviour, IGameEndListener
{
    [SerializeField] private Leaderboard leaderboardManager;
    [SerializeField] private Transform player;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform leaderboard;
    
    [Header("Clock")]
    [SerializeField] private float _roundTime;
    [SerializeField] private TMP_Text _timerText;
    private float _timeRemaining;
    private int _currentRound;
    
    [Header("Round")]
    [SerializeField] private TMP_Text _roundText;
    
    [Header("Flags")]
    private bool _isRoundEnded = false;
    
    [Header("Spawner")]
    [SerializeField] private List<GameObject> _seats = new List<GameObject>();
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private List<Enemy> enemies = new List<Enemy>();
    private List<GameObject> _spawnedEnemies = new List<GameObject>();
    private int _enemiesToSpawn = 5;

    private void Awake()
    {
        _timeRemaining = _roundTime;
        GameLoopManager.Instance.RegisterListener(this);
    }

    void Start()
    {
        SpawnEnemies();
        leaderboard.gameObject.SetActive(false);
    }

    private void Update()
    {
        CountdownTimer();
        Debug.Log(GameLoopManager.Instance.Satisfaction);
    }

    private void CountdownTimer()
    {
        if(_timeRemaining > 0)
            _timeRemaining -= Time.deltaTime;

        if (_timeRemaining <= 0 && !_isRoundEnded)
            StartCoroutine(ResetRound());
        
        int minutes = Mathf.FloorToInt(_timeRemaining / 60);
        int seconds = Mathf.FloorToInt(_timeRemaining % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
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
            int randomEnemy  = Random.Range(0, enemies.Count);
            enemy.GetComponent<Enemy1>().enemySO = enemies[randomEnemy];
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
        _enemiesToSpawn += 2;
    }

    private void MovePlayerToSpawn()
    {
        player.position = spawnPoint.position;
    }

    private IEnumerator ResetRound()
    {
        _isRoundEnded = true;
        IncreaseEnemiesToSpawn();
        ClearSpawnedEnemies();
        _roundText.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(2f);
        
        _roundText.gameObject.SetActive(false);
        GameLoopManager.Instance.Satisfaction = 50;
        GameLoopManager.Instance.Score++;
        MovePlayerToSpawn();
        SpawnEnemies();
        _timeRemaining = _roundTime;
        _isRoundEnded = false;
    }

    public void OnGameEnd()
    {
        leaderboardManager.SetLeaderboardEntry(GameLoopManager.Instance.PlayerName, GameLoopManager.Instance.Score);
        leaderboard.gameObject.SetActive(true);
    }
}
