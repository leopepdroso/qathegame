using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyIA : MonoBehaviour {

    public Transform Target;
    private GameObject Enemy;
    private GameObject Player;
    private float Range;
    public float speed = 1f;

    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        Range = Vector2.Distance(Enemy.transform.position, Player.transform.position);
        if (Range <=2f)
        {
            Debug.Log("Enemy nearby");
            Enemy.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }
}
