using SimpleJSON;
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

    public Material unselected;
    public Material selected;
    
    void Start()
    {
        unselected = Resources.Load("Materials/Transparent", typeof(Material)) as Material;
        selected = Resources.Load("Materials/type1", typeof(Material)) as Material;


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

    private void Update()
    {

        //unit select
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                foreach (Transform child in transform)
                {
                    if (child.gameObject.tag == "Highlight") {
                        MeshRenderer mr = child.gameObject.GetComponent<MeshRenderer>();
                        if (mr.sharedMaterial == selected)
                        {
                            mr.material = unselected;
                        }
                        else
                            mr.material = selected;
                        //тут еще нужно юниту поставить признак какой то, выбран он или нет
                    }
                }
            }
        }
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


