using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toboggan : MonoBehaviour
{
    
    public GameObject Lapin_parent;
    public GameObject Move_Spot;
    private GameObject lapin1_corps;
    private GameObject lapin1_c;
    private GameObject lapin_p;
    
    private Vector3 worldPosition;
    public Color MyCustomColor;
    //public string[] Sexe = new string[2];
    //private int randomIndex;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        Transform spot = Instantiate(Move_Spot, worldPosition, Quaternion.identity).transform;
        lapin_p = Instantiate(Lapin_parent, worldPosition, Quaternion.identity);

        lapin1_corps = lapin_p.transform.Find("Lapin1_corps").gameObject;
        lapin1_c = lapin1_corps.transform.Find("lapin1_c").gameObject;
        
        lapin_p.GetComponent<Rabbit_movement>().moveSpot = spot;
        lapin1_c.GetComponent<SpriteRenderer>().color = MyCustomColor;

        //randomIndex = Random.Range (0, 2);
        //string randomTag = Sexe[randomIndex];
        //lapin_n.tag = randomTag;

    }
}
