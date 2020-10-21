using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit_manager : MonoBehaviour
{
    // Start is called before the first frame update
    private int n_males;
    private int n_femelles;
    private int n_total;
    public int population_max;
    public float lifetime;

    private GameObject[] lapins_males;
    private GameObject[] lapins_femelles;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lapins_males = GameObject.FindGameObjectsWithTag("Male");
        lapins_femelles = GameObject.FindGameObjectsWithTag("Femelle");

        n_males = lapins_males.Length;
        n_femelles = lapins_femelles.Length;

        n_total = n_males + n_femelles;
                
        while(n_total > population_max) {
            if(n_males > n_femelles) {
                this.DestroyTheOldest(lapins_males);    
                n_males--;    
            } else {
                this.DestroyTheOldest(lapins_femelles); 
                n_femelles --;
            }
            n_total--;
        }
    }

    void OnGUI()
        {
        GUI.Label(new Rect(0,0,100,100), "Nombre de mâles : " + n_males);
        GUI.Label(new Rect(0,100,100,200), "Nombre de femelles : " + n_femelles);
        }
    
    void DestroyTheOldest(GameObject[] lapins)
    {
        float maxLife = 20f;
        int iLapinVieux = -1;
        for (int i = 0; i < lapins.Length; i++)
        {
            if (lapins[i].GetComponent<Rabbit_behaviour>().lifetime > maxLife || i == 0)
            {
                maxLife = lapins[i].GetComponent<Rabbit_behaviour>().lifetime;
                iLapinVieux = i;
            }
        }

        if (iLapinVieux > -1)
        {
            lapins[iLapinVieux].GetComponent<Rabbit_behaviour>().Kill();
        }
    } 
}
