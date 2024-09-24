using UnityEngine;

public class EnemiesFactory : MonoBehaviour {
    public float multiplier = 1.5f;
    [SerializeField]
    private GameObject enemy;

    public void SpawnEnemy(Vector3 pos)
    {
        Instantiate(enemy, pos, Quaternion.identity);
    }

    public void SpawnBigEnemy(Vector3 pos)
    {
        GameObject bigEnemy = Instantiate(enemy, pos, Quaternion.identity);
        bigEnemy.GetComponent<Enemie>().IsBig = true;
        bigEnemy.transform.localScale *= multiplier;
        Enemie enemie = bigEnemy.GetComponent<Enemie>();
        EnemyAttackController attackController = bigEnemy.GetComponent<EnemyAttackController>();
        enemie.Hp *= multiplier;
        attackController.Damage *= multiplier;
    }

    public void SpawnSmallEnemy(Vector3 pos)
    {
        GameObject smallEnemy = Instantiate(enemy, pos, Quaternion.identity);
        smallEnemy.transform.localScale /= 1.2f;
        Enemie enemie = smallEnemy.GetComponent<Enemie>();
        EnemyAttackController attackController = smallEnemy.GetComponent<EnemyAttackController>();
        enemie.Hp /= multiplier;
        attackController.Damage /= multiplier;
    }
}