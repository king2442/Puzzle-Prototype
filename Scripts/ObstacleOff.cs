using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleOff : MonoBehaviour
{
    public GameObject floor;
    private MeshRenderer floor_color; 
    private Renderer visible;

    // Start is called before the first frame update
    void Start()
    {
        visible = GetComponent<MeshRenderer>();
        floor_color = floor.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {     
        if (floor_color.sharedMaterial.name == "FloorDark")
        {
            visible.enabled = false;
        }
        if (floor_color.sharedMaterial.name == "Floor")
        {
            visible.enabled = true;
        }
    }
}
