using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public float speed;
    int cardTime = 0;
    public GameObject effect;


    List<string> CardList = new List<string>();
    public void Start()
    {
        cardTime = Random.Range(1, 14);
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
            other.GetComponent<Player>().time += cardTime;
            Debug.Log(other.GetComponent<Player>().time);
            Destroy(gameObject);
        }
    }
}
