using SimpleJSON;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ShipsController
{
    public static List<SpaceShip> Ships = new List<SpaceShip>();

    public static List<SpaceShip> FindMyTargets(SpaceShip attacker) 
    {
        List<SpaceShip> result = Ships.FindAll(ship =>
            (ship.shipSize == attacker.bestTarget.Item1 && ship.shipArmor == attacker.bestTarget.Item2));
        return result;
    }

    public static GameObject Create(GameObject fleetObject, JSONNode ship, int ShipQuantity, int CurrentNumber)
    {
        GameObject prefab = Resources.Load("Ships/SpaceShip" + ship["shipId"]) as GameObject;
        float boxLength = 5;
        float boxWidth = 1.5f;

        float shipStep = boxLength / ShipQuantity;

        float xPos = (fleetObject.transform.position.x - boxLength / 2) + (shipStep / 2) + shipStep * CurrentNumber;
        float zPos;

        if (CurrentNumber % 2 == 0)
        {
            zPos = (fleetObject.transform.position.z + boxWidth / 4);
        }
        else
        {
            zPos = (fleetObject.transform.position.z - boxWidth / 4);
        }

        GameObject go = GameObject.Instantiate(prefab) as GameObject;
        go.transform.parent = fleetObject.transform;
        go.transform.position = new Vector3(xPos, fleetObject.transform.position.y + 1f, zPos);

        GameObject prefabHighlighter = Resources.Load("Misc/Highlighter") as GameObject;
        GameObject HighlighterGO = GameObject.Instantiate(prefabHighlighter) as GameObject;
        HighlighterGO.transform.parent = go.transform;
        HighlighterGO.transform.position = new Vector3(go.transform.position.x, go.transform.position.y - 0.7f, go.transform.position.z);

        Font Roboto = (Font)Resources.Load("Fonts/Roboto-Bold");

        // Create Canvas GameObject.
        GameObject canvasGo = new GameObject();
        canvasGo.name = "ShipCanvas";
        canvasGo.AddComponent<Canvas>();
        canvasGo.AddComponent<CanvasGroup>();
        CanvasGroup canvasGoCG = canvasGo.GetComponent<CanvasGroup>();
        canvasGoCG.blocksRaycasts = false;
        canvasGoCG.interactable = false;

        canvasGo.GetComponent<RectTransform>().SetParent(go.transform, true);
        canvasGo.GetComponent<RectTransform>().sizeDelta = new Vector2(200f, 100f);
        canvasGo.transform.LookAt(Camera.main.transform);
        canvasGo.transform.localPosition = new Vector3(0, 0, -1.5f);
        canvasGo.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);

        // ShipName
        GameObject ShipName = new GameObject();
        ShipName.transform.parent = canvasGo.transform;
        ShipName.transform.localPosition = new Vector3(0, 90f, 0f);
        ShipName.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        ShipName.name = "ShipName";

        Text ShipNameText = ShipName.AddComponent<Text>();
        ShipNameText.font = Roboto;
        ShipNameText.text = ship["name"].ToString().Trim('"');
        ShipNameText.alignment = TextAnchor.MiddleCenter;
        ShipNameText.fontSize = 12;
        ShipNameText.color = Color.grey;

        // ShipQuantity
        GameObject ShipQuantityObject = new GameObject();
        ShipQuantityObject.transform.parent = ShipName.transform;
        RectTransform ShipNameRt = ShipName.GetComponent<RectTransform>();

        ShipQuantityObject.transform.localPosition = new Vector3( 0f, -120f, 0f);
        ShipQuantityObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        ShipQuantityObject.name = "ShipQuantity";

        Text ShipQuantityText = ShipQuantityObject.AddComponent<Text>();
        ShipQuantityText.font = Roboto;
        ShipQuantityText.text = ship["quantity"].ToString();
        ShipQuantityText.alignment = TextAnchor.MiddleCenter;
        ShipQuantityText.fontSize = 15;
        ShipQuantityText.color = Color.magenta;

        // ShipCurrentArmor
        GameObject ShipCurrentArmor = new GameObject();
        ShipCurrentArmor.transform.parent = ShipName.transform;

        ShipCurrentArmor.transform.localPosition = new Vector3(0, -100f, 0f);
        ShipCurrentArmor.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        ShipCurrentArmor.name = "ShipCurrentArmor";

        Text ShipCurrentArmorText = ShipCurrentArmor.AddComponent<Text>();
        ShipCurrentArmorText.font = Roboto;
        ShipCurrentArmorText.text = "12300";
        ShipCurrentArmorText.alignment = TextAnchor.MiddleCenter;
        ShipCurrentArmorText.fontSize = 15;
        ShipCurrentArmorText.color = Color.white;
        

        Debug.Log(ship["armorType"].ToString());
        go.GetComponent<SpaceShip>().shipArmor = (SpaceShip.Armor)Enum.Parse(typeof(SpaceShip.Armor), "Light");

        return go;
    }

}