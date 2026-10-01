using UnityEngine;

[CreateAssetMenu(fileName = "Enemy_Data_Template", menuName = "Scriptable Objects/Enemy_Data_Template")]
public class Enemy_Data_Template : ScriptableObject
{
    //EnemyHealth ref
    public int MaxHealth;
    public float SinkSpeed;
    public int ScoreValue;

    //EnemyAttack ref
    public float AttackSpeed;
    public int AttackDamage;

}
