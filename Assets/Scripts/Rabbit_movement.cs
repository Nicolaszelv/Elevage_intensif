using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit_movement : MonoBehaviour
{
    
    private Animator lapin_parent_animator;
    //public GameObject Lapin_parent;
    private Vector3 worldPosition;
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

    void Start()
    {
        startWaitTime = Random.Range(waitMin, waitMax+1);
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        lapin_parent_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
        
        if(Vector2.Distance(transform.position, moveSpot.position) < 0.2f){
            if(waitTime <= 0) {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;

                lapin_parent_animator.SetBool("Jump", true);
                lapin_parent_animator.SetBool("Idle", false);
            }
            else {
                waitTime -= Time.deltaTime;

                lapin_parent_animator.SetBool("Idle", true);
                lapin_parent_animator.SetBool("Jump", false);
            }
        }
    }
}
