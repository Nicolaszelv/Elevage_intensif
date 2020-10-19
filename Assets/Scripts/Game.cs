using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public GameObject Lapin_male;
    public GameObject Lapin_femelle;
    public GameObject Move_Spot;
    private Vector3 worldPosition;
    // Start is called before the first frame update
    void Start()
    {
        //Lapin_femelle.GetComponent<Rabbit_behaviour>.moveSpot = Move_Spot.transform.position;
        //Lapin_male.GetComponent<Rabbit_behaviour>.moveSpot = Move_Spot.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("lapin male");

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

            //Instantiate(Move_Spot, worldPosition, Quaternion.identity);
            Transform spot = Instantiate(Move_Spot, worldPosition, Quaternion.identity).transform;

            //Instantiate(Lapin_male, worldPosition, Quaternion.identity);
            Transform lapin_m = Instantiate(Lapin_male, worldPosition, Quaternion.identity).transform;
            
            lapin_m.GetComponent<Rabbit_behaviour>().moveSpot = spot;
        }

        if (Input.GetMouseButtonDown(1)){
            Debug.Log("lapin femelle");

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

            //Instantiate(Move_Spot, worldPosition, Quaternion.identity);
            Transform spot = Instantiate(Move_Spot, worldPosition, Quaternion.identity).transform;

            //Instantiate(Lapin_femelle, worldPosition, Quaternion.identity);
            Transform lapin_f = Instantiate(Lapin_femelle, worldPosition, Quaternion.identity).transform;
            
            lapin_f.GetComponent<Rabbit_behaviour>().moveSpot = spot;
            
        }
    }
}
