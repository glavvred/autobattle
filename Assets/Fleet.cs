using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;

public class Fleet : MonoBehaviour
{
    private int FleetSide;

    public GameObject Create(GameObject SideObject, JSONNode side)
    {
        GameObject prefab = Resources.Load("Misc/FleetBox") as GameObject;
        GameObject FleetGo = Instantiate(prefab) as GameObject;
        FleetGo.name = "Fleet " + SideController.Sides.Count + " : " + SideController.Sides[side["id"]].fleets.Count;
        FleetGo.transform.parent = transform;

        FleetGo.transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        SideController.Sides[side["id"]].fleets.Add(this);
        FleetSide = side["id"];

        return FleetGo;
    }

    public void Update()
    {
       
        }
}



