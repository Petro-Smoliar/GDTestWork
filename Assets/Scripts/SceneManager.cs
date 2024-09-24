using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;
    
    public Player Player;
    public List<Enemie> Enemies;
    public GameObject Lose;
    public GameObject Win;
    public Button AttackButton;
    public EnemiesFactory EnemiesFactory;
    public Button SuperAttackButton;
    [SerializeField]
    private TMP_Text TextWave;

    private int currWave = 0;
    [SerializeField] private LevelConfig Config;

    public void Reset()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void AddEnemie(Enemie enemie)
    {
        Enemies.Add(enemie);
    }

    public void RemoveEnemie(Enemie enemie)
    {
        Enemies.Remove(enemie);
        if(Enemies.Count == 0)
        {
            SpawnWave();
        }
    }

    public void GameOver()
    {
        Lose.SetActive(true);
        Player.GetComponent<PlayerAttackController>().enabled = false;
        Player.GetComponent<PlayerMoveController>().enabled = false;
        AttackButton.gameObject.SetActive(false);
        SuperAttackButton.gameObject.SetActive(false);
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnWave();
        
    }

    private void SpawnWave()
    {
        if (currWave >= Config.Waves.Length)
        {
            Win.SetActive(true);
            return;
        }

        var wave = Config.Waves[currWave];
        for (int i = 0; i < wave.countEnemy; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            EnemiesFactory.SpawnEnemy(pos);
        }

        for (int i = 0; i < wave.countBigEnemy; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            EnemiesFactory.SpawnBigEnemy(pos);
        }

        UpdateTextWave();
        currWave++;
    }

    private void UpdateTextWave()
    {
        TextWave.text = $"Wave {currWave + 1}/{Config.Waves.Count()}";
    }
}
