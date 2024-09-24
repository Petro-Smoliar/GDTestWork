using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Data/Waves")]
[Serializable]
public class Wave : ScriptableObject
{
    public int countEnemy;
    public int countBigEnemy;
}
