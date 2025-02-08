using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy1 : MonoBehaviour, IInteractable
{
    private SpriteRenderer _spriteRenderer;
    public Enemy enemySO;
    
    public Vector2Int startActionIntervalRange;
    public Vector2Int actionIntervalRange;
    public float actionDuration;

    public bool wrongAction;
    
    private int _actionInterval;
    private int _startActionInterval;
    
    [SerializeField] private int _satisfactionIncrease;

    private void Awake()
    {
        startActionIntervalRange = new Vector2Int(2, 6);
        actionIntervalRange = new Vector2Int(2, 6);
        actionDuration = 2f;
    }

    public void NormalInteract()
    {
        GameLoopManager.Instance.Satisfaction += _satisfactionIncrease;
    }

    public void HardInteract()
    {
        GameLoopManager.Instance.Satisfaction += _satisfactionIncrease;
    }
    
    private IEnumerator InteractionsStarter()
    {
        yield return new WaitForSeconds(_startActionInterval);
        StartCoroutine(CustomerActions());
    }

    private IEnumerator CustomerActions()
    {
        while (true)
        {
            yield return new WaitForSeconds(_actionInterval);
        
            _actionInterval = Random.Range(actionIntervalRange.x, actionIntervalRange.y + 1);
            StartCoroutine(PerformAction());
        }
    }
    
    private IEnumerator PerformAction()
    {
        List<Sprite> selectedList;
        bool isWrongAction = Random.Range(0f, 100f) < enemySO.wrongActionChance;
        wrongAction = false;

        if (isWrongAction)
        {
            selectedList = enemySO.npcWrongActionSprites;
        }
        else
        {
            selectedList = enemySO.npcNeutralActionSprites;
        }

        if (selectedList.Count > 0)
        {
            int index = Random.Range(0, selectedList.Count);
            _spriteRenderer.sprite = selectedList[index];

            if (isWrongAction)
            {
                wrongAction = true;
                yield return new WaitForSeconds(actionDuration);
            }
            else
            {
                float elapsedTime = 0f;
                while (elapsedTime < actionDuration)
                {
                    yield return new WaitForSeconds(actionDuration * 0.5f);
                    index = Random.Range(0, selectedList.Count);
                    _spriteRenderer.sprite = selectedList[index];

                    elapsedTime += 0.5f;
                }
            }
        }
        
        _spriteRenderer.sprite = enemySO.npcDefaultSprite;
        wrongAction = false;
    }
    
    private void Start()
    {
        StartCoroutine(InteractionsStarter());
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteRenderer.sprite = enemySO.npcDefaultSprite;
        transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
    }
    
    private void OnEnable()
    {
        _actionInterval = Random.Range(actionIntervalRange.x, actionIntervalRange.y + 1);
        _startActionInterval = Random.Range(startActionIntervalRange.x, startActionIntervalRange.y + 1);
    }
}
