using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject[] cards;
    public int damage = 1;
    public float speed;

    public GameObject effect;

    private void Start()
    {
        int rand = Random.Range(0, 20);

        if (rand == 0)
        {
            Destroy(gameObject);
            int cardIdx = Random.Range(0, cards.Length);
            Instantiate(cards[cardIdx], transform.position, Quaternion.identity);
        }
        
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);

            other.GetComponent<Player>().time -= damage;
            Debug.Log(other.GetComponent<Player>().time);
            Destroy(gameObject);
        }
    }
}
