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
    
    private GameObject go_male;
    private GameObject go_femelle;

    private SpriteRenderer sr_male;
    private SpriteRenderer sr_femelle;

    public string[] Sexe = new string[2];
    private int randomIndex;

    public GameObject Lapin_neutre;
    public GameObject Move_Spot;
    private Vector3 worldPosition;

    void Start()
    {
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        /* go_male = GameObject.FindWithTag ("Male");
        sr_male = go_male.GetComponent<SpriteRenderer>();

        go_femelle = GameObject.FindWithTag ("Femelle");
        sr_femelle = go_femelle.GetComponent<SpriteRenderer>();
        transform.position = new Vector3(0.0f, -2.0f, 0.0f); */


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
                speed = 1;
                other.gameObject.GetComponent<Rabbit_behaviour>().speed = 1;

                Transform spot = Instantiate(Move_Spot, gameObject.transform.position, Quaternion.identity).transform;
                Transform lapin_n = Instantiate(Lapin_neutre, gameObject.transform.position, Quaternion.identity).transform;
                
                lapin_n.GetComponent<Rabbit_behaviour>().moveSpot = spot;
                lapin_n.GetComponent<Rabbit_behaviour>().speed = 8;
                lapin_n.GetComponent<Transform>().localScale = new Vector3 (0.25f, 0.25f, 0.25f);
                lapin_n.GetComponent<SpriteRenderer>().color = Color.Lerp(gameObject.GetComponent<SpriteRenderer>().color, other.gameObject.GetComponent<SpriteRenderer>().color,  Mathf.PingPong(Time.time, 1));

                //randomIndex = Random.Range (0, 2);
                //string randomTag = Sexe[randomIndex];
                //lapin_n.tag = randomTag;

                horny_male = false;
                other.gameObject.GetComponent<Rabbit_behaviour>().horny_femelle = false;
                StartCoroutine("Horny_over_time");
                Debug.Log("LAPIN RENCONTRE LAPINE");
            }

        /* if (other.gameObject.tag == "Male" & gameObject.tag == "Femelle" & other.gameObject.GetComponent<Rabbit_behaviour>().horny_male == true & horny_femelle == true) // SI LAPINE RENCONTRE LAPINE
            {
                
                speed = 1;
                other.gameObject.GetComponent<Rabbit_behaviour>().speed = 1;

                Transform spot = Instantiate(Move_Spot, worldPosition, Quaternion.identity).transform;
                Transform lapin_n = Instantiate(Lapin_neutre, worldPosition, Quaternion.identity).transform;
                
                lapin_n.GetComponent<Rabbit_behaviour>().moveSpot = spot;
                lapin_n.GetComponent<SpriteRenderer>().color = Color.Lerp(sr_male.color, sr_femelle.color, 0.5f);

                randomIndex = Random.Range (0, 2);
                string randomTag = Sexe[randomIndex];
                lapin_n.tag = randomTag;
                
                horny_femelle = false;

                Debug.Log("LAPINE RENCONTRE LAPIN");
            } */

        
    }

    private IEnumerator Horny_over_time()
        {
            while (true)
            {
                yield return new WaitForSeconds(5f);
                horny_male = true;
                horny_femelle = true;
                Debug.Log("horny again");
            }
        }
}