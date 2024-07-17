using UnityEngine;

[CreateAssetMenu(fileName = "AOEAttackPattern", menuName = "AttackPattern/AOE")]
public class AOEAttackPattern : ScriptableObject
{
    public enum AttackType { Circle, Cone, Rectangle }
    public AttackType attackType;
    public float radius;
    public float angle; // for cone
    public Vector2 size; // for rectangle
}
