using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundaries : MonoBehaviour
{
    private Vector3 screen;
    // Start is called before the first frame update
    void Start()
    {
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0.05f, Screen.height));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 view = transform.position;
        view.x = Mathf.Clamp(view.x, screen.x, screen.x * -1);
        view.y = Mathf.Clamp(view.z, screen.z, screen.z * -1);
        transform.position = view;
    }
}
