using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePath : MonoBehaviour
{
    bool drag = false, end_pos = false;
    public Vector3 initial, final;
    float dist;
    public GameObject Player;
    public List<Vector3> store_position;
    public GameObject floor;
    public Material dark_floor;
    public Light main_light;
    public TrailRenderer trail;

    void Update()
    {
        if(end_pos == false && drag)
        {          
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(dist);
            rayPoint.y = 0.05f;
            transform.position = rayPoint;
            store_position.Add(transform.position + new Vector3(0f, 0.2f, 0f));  //storing path information 
            if (trail.time == 0)
            {
                trail.time = 100;
            }
        }
        else if(end_pos == true)
        {
            transform.position = final;
            store_position.Add(transform.position + new Vector3(0f, 0.2f, 0f));
            Player.SetActive(true);
            floor.GetComponent<MeshRenderer>().sharedMaterial = dark_floor;
            main_light.enabled = false;
        }
    }
    private void OnMouseDrag()
    {
        dist = Vector3.Distance(transform.position, Camera.main.transform.position);
        drag = true;
    }
    private void OnMouseUp()
    {
        drag = false;
        if (end_pos == false)   // return to initial pos if path is stopped midway
        {
            transform.position = initial;
            store_position.Clear();
            trail.time = 0; 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "End") //to check if end position has been reached
        {
            end_pos = true;
        }
    }
}
