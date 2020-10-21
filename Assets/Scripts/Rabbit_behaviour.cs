using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Rabbit_behaviour : MonoBehaviour
{
    
    public float speed;
    private float waitTime;
    private float startWaitTime;
    public float waitMin;
    public float waitMax;
    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public bool horny_male;
    public bool horny_femelle;
    
    public float lifetime;
    public float random_death_min;
    public float random_death_max;
    private float deathtime;

    public float size;
    public float grow_speed;
    public float random_size_min;
    public float random_size_max;
    private float final_size;
    public float size_to_be_horny;

    public string[] Sexe = new string[2];
    private int randomIndex;

    public int nb_babies_min;
    public int nb_babies_max;
    private int nb_babies;

    public float horny_time_min;
    public float horny_time_max;
    private float horny_ready;
    private float horny_timer;

    public GameObject Lapin_neutre;
    public GameObject Move_Spot;
    private Vector3 worldPosition;

    private int n_males;
    private int n_femelles;
    private int n_total;
    public int population_max;

    private GameObject[] lapins_males;
    private GameObject[] lapins_femelles;

    
    void Start()
    {
        startWaitTime = Random.Range(waitMin, waitMax+1);
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        lifetime = 0;
        deathtime = Random.Range(random_death_min, random_death_max);

        size = 0;
        final_size = Random.Range(random_size_min, random_size_max);

        nb_babies = Random.Range(nb_babies_min, nb_babies_max);

        horny_ready = Random.Range(horny_time_min, horny_time_max);

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
        
        lifetime += Time.deltaTime;

        if(lifetime >= deathtime){
            Destroy(gameObject);
        }

        if(horny_male == false && gameObject.tag == "Male"){
            horny_timer += Time.deltaTime;
            speed = 1;
            if(horny_timer >= horny_ready){
                horny_male = true;
                horny_timer = 0;
            }
            else {
                speed = 5;
            }
            
        }

        if(horny_femelle == false && gameObject.tag == "Femelle"){
            horny_timer += Time.deltaTime;
            speed = 1;
            if(horny_timer >= horny_ready){
                horny_femelle = true;
                horny_timer = 0;
            }
            else {
                speed = 5;
            }
            
        }

        size += Time.deltaTime * grow_speed;
        gameObject.GetComponent<Transform>().localScale = new Vector3 (size, size, size);

        if(size >= final_size){
            size = final_size;
        }

        if(size >= size_to_be_horny & gameObject.tag == "Untagged"){
            randomIndex = Random.Range (0, 2);
            string randomTag = Sexe[randomIndex];
            gameObject.tag = randomTag;
        }

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
        if (other.gameObject.tag == "Femelle" && gameObject.tag == "Male" && other.gameObject.GetComponent<Rabbit_behaviour>().horny_femelle == true && horny_male == true) // SI LAPIN RENCONTRE LAPINE
            {

                for (int i = 0; i < nb_babies; i++)
                    {
                        Transform spot = Instantiate(Move_Spot, gameObject.transform.position, Quaternion.identity).transform;
                        Transform lapin_n = Instantiate(Lapin_neutre, gameObject.transform.position, Quaternion.identity).transform;
                        lapin_n.GetComponent<Rabbit_behaviour>().moveSpot = spot;
                        lapin_n.GetComponent<SpriteRenderer>().color = Color.Lerp(gameObject.GetComponent<SpriteRenderer>().color, other.gameObject.GetComponent<SpriteRenderer>().color,  Random.Range(0.2f, 0.8f));
                        lapin_n.tag = "Untagged";
                        other.gameObject.GetComponent<Rabbit_behaviour>().horny_femelle = false;
                        horny_male = false;
                    }
            }  
    }

    public void Kill() {
        lifetime = 50;
    }

    
}