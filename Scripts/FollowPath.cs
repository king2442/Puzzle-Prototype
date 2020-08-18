using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    private List<Vector3> follow_position;
    public Vector3 final;
    private bool move = false;
    public GameObject floor;
    public Material blue_floor;
    public Light main_light;

    // Start is called before the first frame update
    void Start()
    {
        follow_position = FindObjectOfType<MakePath>().store_position;
    }

    // Update is called once per frame
    void Update()
    {
        if(move && transform.position!=final && gameObject.activeSelf)
        {
            transform.position = follow_position[0];
            follow_position.RemoveAt(0);
        }
        if(transform.position == final)
        {
            floor.GetComponent<MeshRenderer>().sharedMaterial = blue_floor;
            main_light.enabled = true;
        }
    }
    private void OnMouseDown()
    {
        move = true;  //to move the player after click 
    }
}
