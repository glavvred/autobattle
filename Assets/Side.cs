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
    public List<Fleet> fleets;

    public GameObject Create(JSONNode side)
    {
        GameObject prefab = Resources.Load("Misc/SideBox") as GameObject;
        GameObject SideGo = Instantiate(prefab) as GameObject;
        SideGo.name = "Side" + SideController.Sides.Count;
        SideGo.transform.parent = transform;
        SideController.Sides.Add(this);

        float startPositionZ = - transform.localScale.y / 2;
        SideGo.transform.position = new Vector3(0 , 0, startPositionZ - 1f + SideController.Sides.Count * 4f);

        return SideGo;
    }

    public void Start()
    {
    }
}



