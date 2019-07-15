using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;

public class Fleet : MonoBehaviour
{
    public GameObject Create(GameObject SideObject, JSONNode side)
    {
        GameObject prefab = Resources.Load("Misc/FleetBox") as GameObject;
        GameObject FleetGo = Instantiate(prefab) as GameObject;
        FleetGo.name = "Fleet " + SideController.Sides.Count + " : " + SideController.Sides[side["id"]].fleets.Count;
        FleetGo.transform.parent = transform;

        FleetGo.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        SideController.Sides[side["id"]].fleets.Add(this);

        return FleetGo;
    }

    public void Start()
    {
    }
}



