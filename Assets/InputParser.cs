using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class InputParser
{
    string jsonStr;
    private Side _side;

    public InputParser(GameObject caller)
    {
        _side = caller.gameObject.GetComponent<Side>();
    }

    public void JsonParse()
    {
        jsonStr =
            "{\"sides\":{\"0\":{\"id\":0,\"fleets\":{\"0\":{\"ships\":{\"0\":{\"shipId\":1,\"name\":\"\u0422\u044F\u0436\u0435\u043B\u044B\u0439 \u0438\u0441\u0442\u0440\u0435\u0431\u0438\u0442\u0435\u043B\u044C\",\"quantity\":100,\"armor\":\"100\",\"baseDamage\":10,\"damage\":{\"armor\":{\"lightArmor\":1,\"mediumArmor\":1,\"heavyArmor\":0.5,\"reinforcedArmor\":0.3},\"hull\":{\"small\":1,\"medium\":1,\"large\":0.5,\"huge\":0.3}},\"armorType\":\"Light\",\"hullSize\":\"Small\"},\"1\":{\"shipId\":2,\"name\":\"\u041C\u0430\u043B\u044B\u0439 \u0442\u0440\u0430\u043D\u0441\u043F\u043E\u0440\u0442\",\"quantity\":100,\"armor\":\"10\",\"baseDamage\":1,\"damage\":{\"armor\":{\"lightArmor\":1,\"mediumArmor\":1,\"heavyArmor\":0.5,\"reinforcedArmor\":0.3},\"hull\":{\"small\":1,\"medium\":1,\"large\":0.5,\"huge\":0.3}},\"armorType\":\"Light\",\"hullSize\":\"Small\"}},\"id\":123,\"is_garrison\":null,\"name\":\"enemy fleet name 1\",\"belongsTo\":2,\"captain\":null,\"metal\":5000,\"crystal\":3200,\"gas\":12232},\"1\":{\"id\":124,\"ships\":{\"0\":{\"shipId\":2,\"name\":\"\u041C\u0430\u043B\u044B\u0439 \u0442\u0440\u0430\u043D\u0441\u043F\u043E\u0440\u0442\",\"quantity\":50,\"armor\":\"10\",\"baseDamage\":1,\"damage\":{\"armor\":{\"lightArmor\":1,\"mediumArmor\":1,\"heavyArmor\":0.5,\"reinforcedArmor\":0.3},\"hull\":{\"small\":1,\"medium\":1,\"large\":0.5,\"huge\":0.3}},\"armorType\":\"Light\",\"hullSize\":\"Small\"},\"2\":{\"shipId\":3,\"name\":\"\u0411\u043E\u043B\u044C\u0448\u043E\u0439 \u0442\u0440\u0430\u043D\u0441\u043F\u043E\u0440\u0442\",\"quantity\":10,\"armor\":\"100\",\"baseDamage\":10,\"damage\":{\"armor\":{\"lightArmor\":1,\"mediumArmor\":1,\"heavyArmor\":0.5,\"reinforcedArmor\":0.3},\"hull\":{\"small\":1,\"medium\":1,\"large\":0.5,\"huge\":0.3}},\"armorType\":\"Medium\",\"hullSize\":\"Large\"},\"3\":{\"shipId\":4,\"name\":\"\u041F\u0435\u0440\u0435\u0440\u0430\u0431\u043E\u0442\u0447\u0438\u043A\",\"quantity\":100,\"armor\":\"10\",\"baseDamage\":1,\"damage\":{\"armor\":{\"lightArmor\":1,\"mediumArmor\":1,\"heavyArmor\":0.5,\"reinforcedArmor\":0.3},\"hull\":{\"small\":1,\"medium\":1,\"large\":0.5,\"huge\":0.3}},\"armorType\":\"Light\",\"hullSize\":\"Small\"}},\"is_garrison\":null,\"name\":null,\"belongsTo\":3,\"captain\":null,\"metal\":0,\"crystal\":0,\"gas\":30000}}},\"1\":{\"id\":1,\"fleets\":{\"0\":{\"ships\":{\"0\":{\"shipId\":1,\"name\":\"\u0422\u044F\u0436\u0435\u043B\u044B\u0439 \u0438\u0441\u0442\u0440\u0435\u0431\u0438\u0442\u0435\u043B\u044C\",\"quantity\":50,\"armor\":\"100\",\"baseDamage\":10,\"damage\":{\"armor\":{\"lightArmor\":1,\"mediumArmor\":1,\"heavyArmor\":0.5,\"reinforcedArmor\":0.3},\"hull\":{\"small\":1,\"medium\":1,\"large\":0.5,\"huge\":0.3}},\"armorType\":\"Light\",\"hullSize\":\"Small\"}},\"id\":340,\"is_garrison\":null,\"name\":\"neutral fleet name\",\"belongsTo\":10,\"captain\":null,\"metal\":0,\"crystal\":0,\"gas\":3000},\"1\":{\"id\":233,\"ships\":{\"0\":{\"shipId\":1,\"name\":\"\u0422\u044F\u0436\u0435\u043B\u044B\u0439 \u0438\u0441\u0442\u0440\u0435\u0431\u0438\u0442\u0435\u043B\u044C\",\"quantity\":10,\"armor\":\"100\",\"baseDamage\":10,\"damage\":{\"armor\":{\"lightArmor\":1,\"mediumArmor\":1,\"heavyArmor\":0.5,\"reinforcedArmor\":0.3},\"hull\":{\"small\":1,\"medium\":1,\"large\":0.5,\"huge\":0.3}},\"armorType\":\"Light\",\"hullSize\":\"Small\"}},\"is_garrison\":null,\"name\":null,\"belongsTo\":15,\"captain\":null,\"metal\":0,\"crystal\":0,\"gas\":300},\"2\":{\"ships\":{\"0\":{\"shipId\":1,\"name\":\"\u0422\u044F\u0436\u0435\u043B\u044B\u0439 \u0438\u0441\u0442\u0440\u0435\u0431\u0438\u0442\u0435\u043B\u044C\",\"quantity\":10,\"armor\":\"100\",\"baseDamage\":10,\"damage\":{\"armor\":{\"lightArmor\":1,\"mediumArmor\":1,\"heavyArmor\":0.5,\"reinforcedArmor\":0.3},\"hull\":{\"small\":1,\"medium\":1,\"large\":0.5,\"huge\":0.3}},\"armorType\":\"Light\",\"hullSize\":\"Small\"}},\"id\":234,\"is_garrison\":null,\"name\":null,\"belongsTo\":15,\"captain\":null,\"metal\":0,\"crystal\":0,\"gas\":300}}}}}";
        var fleet = JSON.Parse(jsonStr);

        foreach (JSONNode BattleSide in fleet["sides"])
        {
            //сторона
            GameObject sideObject = _side.Create(BattleSide);

            int FleetInSideNumber = 0;
            foreach (JSONNode BattleFleet in BattleSide["fleets"])
            {
                var _fleet = sideObject.AddComponent<Fleet>();

                //флот внутри стороны
                GameObject fleetObject = _fleet.Create(sideObject, BattleFleet, BattleSide["fleets"].Count, FleetInSideNumber);

                int shipQuantity = BattleFleet["ships"].Count;
                int ShipInFleet = 0;
                foreach (JSONNode ship in BattleFleet["ships"])
                {
                    //корабли внутри флота
                    var _spaceShip = fleetObject.AddComponent<SpaceShip>();
                    GameObject shipObject = ShipsController.Create(fleetObject, ship, shipQuantity, ShipInFleet);
                    ShipInFleet++;
                }
                FleetInSideNumber++;
            }
        }
    }
}