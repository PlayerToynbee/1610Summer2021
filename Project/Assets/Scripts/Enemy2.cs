using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject player;
    private Rigidbody enemyRb;
    public float speed = 20;
    public float attackRate = 3.0f;
    public float nextAttack;
    public float nextActionCD;
    public float nextActionCDTime = 6;
    public bool isCooldown = false;
    public float movementRate = 3;
    public float nextMovementRate;
    public float randomMove = 3;

    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        distance = gameManager.detectionRange;
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyRb.AddForce((transform.position - player.transform.position) * 100, ForceMode.Impulse);
            nextActionCD = Time.time + nextActionCDTime;
            isCooldown = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= distance && Time.time > nextAttack && !isCooldown)
        {
            nextAttack = Time.time + attackRate;
            transform.LookAt(player.transform.position);
            enemyRb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
        }
        else if (isCooldown && Time.time > nextActionCD) isCooldown = false;
        else if (Time.time > nextMovementRate)
        {
            nextMovementRate = Time.time + movementRate;
            enemyRb.AddForce(new Vector3(Random.Range(-randomMove,randomMove),Random.Range(-randomMove,randomMove),Random.Range(-randomMove,randomMove)) * 50, ForceMode.Impulse);
        }
    }
}
