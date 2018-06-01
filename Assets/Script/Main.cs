using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{

    [SerializeField] private PlayerScript player;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject enemyPrefab;
	[SerializeField] private Text scoreBoard;
    private List<GameObject> enemys = new List<GameObject>();
	private AudioSource se;


    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.transform.SetParent(canvas.transform, false);
            enemys.Add(enemy);
        }
		this.se = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!player.IsMovingStop)
            {
                StartCoroutine(player.NobiAgo());
				this.se.PlayOneShot(this.se.clip);
                foreach (GameObject enemy in this.enemys)
                {
                    enemy.GetComponent<EnemyObject>().IsMovingStop = true;
                }
            }
        }
		int score = 0;
		foreach(GameObject enemy in enemys){
			if(enemy.GetComponent<EnemyObject>().IsSuccess){
				score += 1;
			}
		}
		scoreBoard.text = "Score : " + score;
    }
}
