using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;

public class Fleet : MonoBehaviour
{
    public GameObject Create(GameObject SideObject, JSONNode BattleFleet , int FleetCount, int CurrentNumber)
    {
        GameObject prefab = Resources.Load("Misc/FleetBox") as GameObject;
        GameObject FleetGo = Instantiate(prefab) as GameObject;
        
        FleetGo.name = "Fleet " + CurrentNumber  + "(" + BattleFleet["id"] + ")";
        FleetGo.transform.parent = SideObject.transform;

        float zPos;
        if (CurrentNumber % 2 == 0)
        {
            zPos = 1f;
        }
        else
        {
            zPos = -1f;
        }
        FleetGo.transform.position = new Vector3(-3.3f + SideObject.transform.position.x + 4f * CurrentNumber, 0.01f, SideObject.transform.position.z + zPos);

        Side.Fleets.Add(this);
 
        return FleetGo;
    }

}



