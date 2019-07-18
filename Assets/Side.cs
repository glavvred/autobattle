using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;

public class SideController
{
    public static List<Side> Sides = new List<Side>();
}

public class Side : MonoBehaviour
{
    private float yPos;
    public static List<Fleet> Fleets = new List<Fleet>();

    public GameObject Create(JSONNode side)
    {
        GameObject prefab = Resources.Load("Misc/SideBox") as GameObject;
        GameObject SideGo = Instantiate(prefab) as GameObject;
        SideGo.name = "Side" + SideController.Sides.Count;
        SideGo.transform.parent = transform;

        float SideHeight = SideGo.GetComponent<Renderer>().bounds.size.z;
        float BFHeight = transform.GetComponent<Renderer>().bounds.size.z;

        float StartPositionZ = transform.position.z - BFHeight / 2 + SideHeight / 2 + 1.6f;

        SideGo.transform.position = new Vector3(0 , 0, StartPositionZ + SideController.Sides.Count * 9f);
        SideController.Sides.Add(this);

        return SideGo;
    }

    private void Update()
    {
    }
}



