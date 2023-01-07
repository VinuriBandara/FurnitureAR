using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlaceObject : MonoBehaviour
{

    private Pose ItemPose; 
    private ARRaycastManager aRRaycastManager;
    
    public GameObject placementIndicator;
    public GameObject ghostObj;
    public GameObject objectToPlace;
    
    // furniture
    public GameObject chair;
    public GameObject table;
    public GameObject rack;


    private bool ItemPoseIsValid = false;


    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        UpdateItemPose();
        UpdatePlacementIndicator();

    }

    private void UpdatePlacementIndicator()
    {
        if (ItemPoseIsValid) 
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(ItemPose.position, ItemPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }
    
    private void UpdateItemPose()
    {
        var ssCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var casthits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(ssCenter, casthits, TrackableType.Planes);

        ItemPoseIsValid = casthits.Count > 0;
        if (ItemPoseIsValid)
        {
            ItemPose = casthits[0].pose;
        }
    }


    public void PlaceObject()
    {
        if (ItemPoseIsValid)
        {
            ghostObj.transform.parent = null;
            ghostObj = Instantiate(objectToPlace, ItemPose.position, ItemPose.rotation);
            ghostObj.transform.parent = placementIndicator.transform;
        }
    }
    
    private void SetObject(GameObject furn)
    {
        objectToPlace = furn;
        Destroy(ghostObj);
        ghostObj = Instantiate(furn, ItemPose.position, ItemPose.rotation);
        ghostObj.transform.parent = placementIndicator.transform;
    }
    
    public void SetChair()
    {
        SetObject(chair);
    }
    
    public void SetTable()
    {
        SetObject(table);
    }
    
    
    public void SetRack()
    {
        SetObject(rack);
    }


}