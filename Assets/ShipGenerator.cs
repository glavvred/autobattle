using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using SimpleJSON;

public class ShipGenerator : MonoBehaviour
{
    public int shipQuantity;
    public enum Side { red, green, blue, yellow, pink };
    public Side shipSide;

    public GameObject create(GameObject gameObject, JSONNode jSONNode)
    {

        return new GameObject();
    }

    void Start()
    {
        int randomShipId = Random.Range(1, 4);
        GameObject prefab = Resources.Load("Ships/SpaceShip" + randomShipId) as GameObject;
        float boxLength = transform.localScale.x;
        float boxWidth = transform.localScale.z;
        
        float shipStep = boxLength / shipQuantity;

        for (int i = 0; i < shipQuantity; i++)
        {                  
            float xPos = (transform.position.x - boxLength / 2) + (shipStep / 2) + shipStep * i;
            float zPos;

            if (i % 2 == 0) {
                zPos = (transform.position.z + boxWidth / 4);
            } else
            {
                zPos = (transform.position.z - boxWidth / 4);
            }

            GameObject go = Instantiate(prefab) as GameObject;
            go.transform.parent = transform;
            go.transform.position = new Vector3(xPos, transform.position.y + 1, zPos);
            go.GetComponent<SpaceShip>().shipSide = shipSide;

//            GameObject ship = Instantiate(shipInterceptor, startPosition, Quaternion.identity);
            //            ship.GetComponent<BattleSide>().side = BattleSide.Side.Blue;

        }
    }
}
