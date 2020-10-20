using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toboggan : MonoBehaviour
{
    
    public GameObject Lapin_neutre;
    public GameObject Move_Spot;
    private Vector3 worldPosition;
    public Color MyCustomColor;
    public string[] Sexe = new string[2];
    private int randomIndex;

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
        Transform lapin_n = Instantiate(Lapin_neutre, worldPosition, Quaternion.identity).transform;
        
        lapin_n.GetComponent<Rabbit_behaviour>().moveSpot = spot;
        lapin_n.GetComponent<SpriteRenderer>().color = MyCustomColor;

        randomIndex = Random.Range (0, 2);
        string randomTag = Sexe[randomIndex];
        lapin_n.tag = randomTag;

    }
}
