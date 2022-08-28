using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private Text _scoreKeeper;

    // Start is called before the first frame update
    void Start()
    {
        _scoreKeeper = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _scoreKeeper.text = $"Score: {GameManager.score.ToString("N0")}";
    }
}
