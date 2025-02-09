using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemies", order = 1)]
public class Enemy : ScriptableObject
{
    public Sprite npcDefaultSprite;
    public List<Sprite> npcNeutralActionSprites;
    public List<Sprite> npcWrongActionSprites;

    public List<AudioClip> sounds;

    [Range(0f, 100f)] public float wrongActionChance;
}
