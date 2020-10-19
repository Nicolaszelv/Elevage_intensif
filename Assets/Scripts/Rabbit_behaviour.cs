using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit_behaviour : MonoBehaviour
{
    
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public bool horny_male;
    public bool horny_femelle;
    Renderer rend;
    Color Rouge = Color.red;

    void Start()
    {
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        rend = GetComponent<Renderer>();

        if (gameObject.tag == "Male") {
            horny_male = true;
            horny_femelle = false;
        }

        if (gameObject.tag == "Femelle") {
            horny_male = false;
            horny_femelle = true;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpot.position) < 0.2f){
            if(waitTime <= 0) {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else {
                waitTime -= Time.deltaTime;
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Femelle" & gameObject.tag == "Male" & other.gameObject.GetComponent<Rabbit_behaviour>().horny_femelle == true & horny_male == true) // SI LAPIN RENCONTRE LAPINE
            {
                //speed = 1;
                //other.gameObject.GetComponent<Rabbit_behaviour>().speed = 1;
                Destroy(gameObject);
                Destroy(other.gameObject);
                horny_male = false;
                Debug.Log("LAPIN RENCONTRE LAPINE");
            }

        if (other.gameObject.tag == "Male" & gameObject.tag == "Femelle" & other.gameObject.GetComponent<Rabbit_behaviour>().horny_male == true & horny_femelle == true) // SI LAPINE RENCONTRE LAPINE
            {
                horny_femelle = false;
                Destroy(gameObject);
                Destroy(other.gameObject);
                //other.gameObject.GetComponent<Rabbit_behaviour>().speed = 1;
                //speed = 1;
                Debug.Log("LAPINE RENCONTRE LAPIN");
            }
    }
}