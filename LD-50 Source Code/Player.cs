using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    public float Yincrement;
    public float xLocale;
    public float yStart;

    public float speed;
    public float maxHeight;
    public float minHeight;

    public float time = 60;

    public GameObject effect;

    private void Start()
    {
        targetPos = new Vector2(xLocale, yStart);
        transform.position = targetPos;
    }


    private void Update()
    {

        time -= 1 * Time.deltaTime;

        if (time <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(xLocale, transform.position.y + Yincrement);
            transform.position = targetPos;
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(xLocale, transform.position.y - Yincrement);
            transform.position = targetPos;
        }
    }
}
