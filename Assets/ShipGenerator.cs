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

    void Create(GameObject gameObject, JSONNode jSONNode)
{
        int randomShipId = Random.Range(1, 4);
        GameObject prefab = Resources.Load("Ships/SpaceShip" + randomShipId) as GameObject;
        float boxLength = gameObject.transform.localScale.x;
        float boxWidth = gameObject.transform.localScale.z;
        
        float shipStep = boxLength / shipQuantity;

        for (int i = 0; i < shipQuantity; i++)
        {                  
            float xPos = (gameObject.transform.position.x - boxLength / 2) + (shipStep / 2) + shipStep * i;
            float zPos;

            if (i % 2 == 0) {
                zPos = (gameObject.transform.position.z + boxWidth / 4);
            } else
            {
                zPos = (gameObject.transform.position.z - boxWidth / 4);
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
