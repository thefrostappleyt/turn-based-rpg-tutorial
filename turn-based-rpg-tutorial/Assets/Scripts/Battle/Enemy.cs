using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Battle/Enemy")]
public class Enemy : ScriptableObject
{
    public string enemyName;
    public Sprite enemySprite;
    public int enemyHealth;
    public int enemyMaxHealth;
    public int enemyMinAttack;
    public int enemyMaxAttack;

}
