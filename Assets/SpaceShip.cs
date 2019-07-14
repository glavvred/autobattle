using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public interface IShip
{
    void TakeDamage();
    void Shoot();
}

public class SpaceShip : MonoBehaviour
{
    public enum Size { Small, Medium, Large, Huge }
    public enum Armor { Light, Medium, Heavy, Reinforced }

    public Size shipSize;
    public Armor shipArmor;

    private float[,] damage;

    public float bestDamage { get; private set; } = 0f;
    public (Size, Armor) bestTarget { get; private set; }

    public enum Side { red, green, blue, yellow, pink };
    public ShipGenerator.Side shipSide;

    void Start()
    {
        Font Roboto = (Font)Resources.Load("Fonts/Roboto-Bold");

        // Create Canvas GameObject.
        GameObject canvasGo = new GameObject();
        canvasGo.name = "ShipCanvas";
        canvasGo.AddComponent<Canvas>();
        canvasGo.transform.parent = transform;
        canvasGo.transform.LookAt(Camera.main.transform); 
        canvasGo.transform.localPosition = new Vector3(0, 1.0f, -2.5f);
        canvasGo.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);

        // ShipName
        GameObject ShipName = new GameObject();
        ShipName.transform.parent = canvasGo.transform;
        ShipName.transform.localPosition = new Vector3(0, 15f, 0f);
        ShipName.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        ShipName.name = "ShipName";

        Text ShipNameText = ShipName.AddComponent<Text>();
        ShipNameText.font = Roboto;
        ShipNameText.text = "Ship name placeholder";
        ShipNameText.alignment = TextAnchor.MiddleCenter;
        ShipNameText.fontSize = 14;
        ShipNameText.color = Color.black;

        // ShipQuantity
        GameObject ShipQuantity = new GameObject();
        ShipQuantity.transform.parent = ShipName.transform;
        RectTransform ShipNameRt = ShipName.GetComponent<RectTransform>();

        ShipQuantity.transform.localPosition = new Vector3(ShipNameRt.rect.width / 2 + 5f, 0, 0f);
        ShipQuantity.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        ShipQuantity.name = "ShipQuantity";

        Text ShipQuantityText = ShipQuantity.AddComponent<Text>();
        ShipQuantityText.font = Roboto;
        ShipQuantityText.text = "(123)";
        ShipQuantityText.alignment = TextAnchor.MiddleCenter;
        ShipQuantityText.fontSize = 15;
        ShipQuantityText.color = Color.blue;

        // ShipCurrentArmor
        GameObject ShipCurrentArmor = new GameObject();
        ShipCurrentArmor.transform.parent = canvasGo.transform;

        ShipCurrentArmor.transform.localPosition = new Vector3(0, 50f, 0f);
        ShipCurrentArmor.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        ShipCurrentArmor.name = "ShipCurrentArmor";

        Text ShipCurrentArmorText = ShipCurrentArmor.AddComponent<Text>();
        ShipCurrentArmorText.font = Roboto;
        ShipCurrentArmorText.text = "12300";
        ShipCurrentArmorText.alignment = TextAnchor.MiddleCenter;
        ShipCurrentArmorText.fontSize = 15;
        ShipCurrentArmorText.color = Color.green;



        //для демонстрации заполним массив случайным барахлом
        //сразу найдем, по каким кораблям у нас лучший дамаг
        damage = new float[Enum.GetValues(typeof(Size)).Length, Enum.GetValues(typeof(Armor)).Length];
        for (var i = 0; i < damage.GetLength(0); i++)
        {
            for (var j = 0; j < damage.GetLength(1); j++)
            {
                var d = Random.Range(0f, 20f);
                damage[i, j] = d;
                if (d > bestDamage)
                {
                    bestDamage = d;
                    bestTarget = ((Size)i, (Armor)j);
                }
            }
        }

        //и засунем наш корабль в класс-контроллер
        ShipsController.Ships.Add(this);
    }

    //Метод для поиска лучшей цели
    SpaceShip FindBestTarget()
    {
        //Просто спросим у контроллера, а кто нам подходит
        //Контроллер дает сразу список подходящих целей
        var targets = ShipsController.FindMyTargets(this);

        return targets[Random.Range(0, targets.Count)];
    }

}


