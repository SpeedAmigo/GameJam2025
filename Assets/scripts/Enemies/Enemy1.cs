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
    public float neutralActionDuration;
    public float wrongActionDuration;
    public float jamDuration;

    public bool wrongAction;
    
    private int _actionInterval;
    private int _startActionInterval;
    private bool _isJammed;
    
    
    [SerializeField] private int _satisfactionIncrease;

    public void OutcomeHandler()
    {
        if (wrongAction)
        {
            Debug.Log("Good eye!");
            _spriteRenderer.sprite = enemySO.npcDefaultSprite;
            wrongAction = false;
            
            StopCoroutine(CustomerActions());
            StartCoroutine(JamActions());
        }
        else
        {
            Debug.Log("Not your lucky day!");
        }
    }
    
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

    private IEnumerator JamActions()
    {
        _isJammed = true;
        yield return new WaitForSeconds(jamDuration);
        _isJammed = false;
        
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
                yield return new WaitForSeconds(wrongActionDuration);
            }
            else
            {
                float elapsedTime = 0f;
                while (elapsedTime < neutralActionDuration)
                {
                    yield return new WaitForSeconds(neutralActionDuration * 0.5f);
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
        transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
    }
    
    private void OnEnable()
    {
        _actionInterval = Random.Range(actionIntervalRange.x, actionIntervalRange.y + 1);
        _startActionInterval = Random.Range(startActionIntervalRange.x, startActionIntervalRange.y + 1);
    }
}
