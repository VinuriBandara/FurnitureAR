using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanegMaterial : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject objectChange;

    void Start()
    {
        Touch touch = Input.GetTouch(0);
        if  (touch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.current.ScreenPointToRay(touch.position);
            RaycastHit hitObject;

            if (Physics.Raycast(ray, out hitObject))
            {
                objectChange = hitObject.transform.parent.transform.parent.gameObject;
                MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
                meshRenderer.material.color = Color.blue;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
