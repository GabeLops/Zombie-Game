using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;

    [SerializeField]
    private int maxLives = 1;

    private static int _reamainingLives;
    public static int RemainingLives
    {
        get { return _reamainingLives; }
    }

    [SerializeField]
    private GameObject gameOverUI;

    [SerializeField]
    private GameObject YouWin;
   

    void Awake ()
    {
        
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    void Start()
    {
        _reamainingLives = maxLives;
    }
    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 2;


    
    public void GameWin()
    {
        Debug.Log("Winner");
        Time.timeScale = 0f;
        YouWin.SetActive(true);

    }
    public void EndGame()
    {
        Debug.Log("GAME OVER");
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
        
    }

    public IEnumerator RespawnPlayer ()
    {
        Debug.Log("Spawn Sound");
        yield return new WaitForSeconds(spawnDelay);

        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("TODO: add Spawn PARticles");
    }
    public static void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        _reamainingLives -= 1;
        if (_reamainingLives <= 0)
        {
            gm.EndGame();

        }
        else
        {

        }
        gm.StartCoroutine(gm.RespawnPlayer());

    }

    public static void KillEnemy (Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }
}


