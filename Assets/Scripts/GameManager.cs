using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float explosiveRadius;
    [SerializeField] private float explosiveForce;

    [SerializeField] private GameObject exitMenu = null;
    public static float score = 0;
    public static bool scored = false;
    public static bool levelFinished = false;

    public static Transform spawn;

    private static GameManager _singleton;

    public static GameManager Singleton
    {
        get => _singleton;
        private set
        {
            if (_singleton == null)
            {
                _singleton = value;
            }
            else if (_singleton != value)
            {
                Debug.LogWarning("Two instances of GameManager, removing one");
                Destroy(value.gameObject);
            }
        }
    }
    private void Awake()
    {
        Singleton = this;
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        Explosion._explosionRadius = explosiveRadius;
        Explosion._explosiveForce = explosiveForce;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hitpoints.hp <= 0 || scored)
        {
            exitMenu.SetActive(true);
            GameObject exitText = GameObject.Find("Exit Text");
            exitText.GetComponent<Text>().text = scored ? "You Win!" : "You Lose!";
            levelFinished = true;
        }
        else
        {
            exitMenu.SetActive(false);
        }

        spawn ??= GameObject.FindWithTag("Spawn")?.transform;
        //if (spawn == null)
        //{ //null coalescing
        //    spawn = GameObject.FindWithTag("Spawn")?.transform;//to call objects when null
        //}
        //a?.property
        //!null ? null : a.property
        //
        //a?[b]
        //!null ? null : a[b]
    }

    public void GotoScene(int scene)
    {
        SceneManager.LoadScene(scene);
        ResetGame();
    }

    public void ResetGame()
    {
        //reset score
        score = 0;
        //reset bool
        scored = false;
        levelFinished = false;
        //remove exit menu
        exitMenu.SetActive(false);
        //reset hp
        Hitpoints.hp = 100;
        //find new spawn
        spawn = null;
    }
}
