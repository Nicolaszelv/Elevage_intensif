using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public GameObject Lapin_male;
    public GameObject Lapin_femelle;
    private Vector3 worldPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("lapin male");

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

            Instantiate(Lapin_male, worldPosition, Quaternion.identity);
        }

        if (Input.GetMouseButtonDown(1)){
            Debug.Log("lapin femelle");
            

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

            Instantiate(Lapin_femelle, worldPosition, Quaternion.identity);
        }
    }
}
