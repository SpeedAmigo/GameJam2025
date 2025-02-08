using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemies", order = 1)]
public class Enemy : ScriptableObject
{
    public GameObject prefab;
    [Range(1, 50)] public float eventInterval;
}
