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
    private float zPos;

    public GameObject Create(JSONNode side)
    {
        GameObject prefab = Resources.Load("Misc/SideBox") as GameObject;
        GameObject SideGo = Instantiate(prefab) as GameObject;
        SideGo.name = "Side" + SideController.Sides.Count;
        SideGo.transform.parent = transform;

        if (SideController.Sides.Count < 2)
        {
            zPos = -6f;
        }
        else
        {
            zPos = 3f;
        }

        SideGo.transform.position = new Vector3(transform.position.x, transform.position.y + 2, zPos);
        SideController.Sides.Add(this);

        Debug.Log(SideController.Sides.Count);

        return SideGo;
    }

    public void Start()
    {
    }
}



