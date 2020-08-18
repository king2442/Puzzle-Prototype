using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailOff : MonoBehaviour
{
    public TrailRenderer pos;
    public Transform player;
    public Vector3 final;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position == final)
        {
            pos.time = 0;
        }
    }
}
