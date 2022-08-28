using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float explosiveRadius;
    [SerializeField] private float explosiveForce;

    public static float score = 0;
    public static bool scored = false;
    public static bool levelFinished = false;

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
                Destroy(value);
            }
        }
    }
    private void Awake()
    {
        Singleton = this;
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

    }

    public void GotoScene(int scene)
    {
        //reset bool
        scored = false;
        levelFinished = false;
        //reset hp
        Hitpoints.hp = 100;
        SceneManager.LoadScene(scene);
    }
}
