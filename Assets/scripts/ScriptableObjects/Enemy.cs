using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemies", order = 1)]
public class Enemy : ScriptableObject
{
    public GameObject prefab;
    
    public Vector2Int actionIntervalRange;
    public Vector2Int startActionIntervalRange;
    
    private int _actionInterval;
    private int _startActionInterval;
    
    public int numberOfAlerts;
    
    private void OnEnable()
    {
        _actionInterval = Random.Range(actionIntervalRange.x, actionIntervalRange.y + 1);
        _startActionInterval = Random.Range(startActionIntervalRange.x, startActionIntervalRange.y + 1);
        
        Debug.Log("Start Interval" + _startActionInterval);
        Debug.Log("Event Interval" + _actionInterval);
    }
    
    public IEnumerator InteractionsStarter(MonoBehaviour owner)
    {
        yield return new WaitForSeconds(_startActionInterval);
        Debug.Log("Start being problematic");

        owner.StartCoroutine(CustomerActions());
    }

    private IEnumerator CustomerActions()
    {
        while (true)
        {
            yield return new WaitForSeconds(_actionInterval);
        
            _actionInterval = Random.Range(actionIntervalRange.x, actionIntervalRange.y + 1);
            Debug.Log("new event Interval:" + _actionInterval);
        }
    }
}
