using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class InputParser 
{
    string jsonStr;
    public void JsonParse() 
    {
        jsonStr = "{\"sides\":{\"0\":{\"ships\":{\"0\":{\"shipId\":1,\"name\":\"\u0422\u044F\u0436\u0435\u043B\u044B\u0439 \u0438\u0441\u0442\u0440\u0435\u0431\u0438\u0442\u0435\u043B\u044C\",\"quantity\":56,\"armor\":\"100\",\"baseDamage\":10,\"damage\":{\"armor\":{\"lightArmor\":1,\"mediumArmor\":1,\"heavyArmor\":0.5,\"reinforcedArmor\":0.3},\"hull\":{\"small\":1,\"medium\":1,\"large\":0.5,\"huge\":0.3}},\"armorType\":\"light\",\"hullSize\":\"small\"},\"1\":{\"shipId\":12,\"name\":\"\u041C\u0430\u043B\u044B\u0439 \u0442\u0440\u0430\u043D\u0441\u043F\u043E\u0440\u0442\",\"quantity\":1,\"armor\":\"10\",\"baseDamage\":1,\"damage\":{\"armor\":{\"lightArmor\":1,\"mediumArmor\":1,\"heavyArmor\":0.5,\"reinforcedArmor\":0.3},\"hull\":{\"small\":1,\"medium\":1,\"large\":0.5,\"huge\":0.3}},\"armorType\":\"light\",\"hullSize\":\"small\"},\"2\":{\"shipId\":13,\"name\":\"\u0411\u043E\u043B\u044C\u0448\u043E\u0439 \u0442\u0440\u0430\u043D\u0441\u043F\u043E\u0440\u0442\",\"quantity\":1,\"armor\":\"100\",\"baseDamage\":10,\"damage\":{\"armor\":{\"lightArmor\":1,\"mediumArmor\":1,\"heavyArmor\":0.5,\"reinforcedArmor\":0.3},\"hull\":{\"small\":1,\"medium\":1,\"large\":0.5,\"huge\":0.3}},\"armorType\":\"medium\",\"hullSize\":\"large\"},\"3\":{\"shipId\":14,\"name\":\"\u041F\u0435\u0440\u0435\u0440\u0430\u0431\u043E\u0442\u0447\u0438\u043A\",\"quantity\":1,\"armor\":\"10\",\"baseDamage\":1,\"damage\":{\"armor\":{\"lightArmor\":1,\"mediumArmor\":1,\"heavyArmor\":0.5,\"reinforcedArmor\":0.3},\"hull\":{\"small\":1,\"medium\":1,\"large\":0.5,\"huge\":0.3}},\"armorType\":\"light\",\"hullSize\":\"small\"}},\"is_garrison\":null,\"name\":null,\"belongsTo\":\"self\",\"captain\":null,\"metal\":110600,\"crystal\":27705,\"gas\":3026},\"1\":{\"ships\":{\"0\":{\"shipId\":1,\"name\":\"\u0422\u044F\u0436\u0435\u043B\u044B\u0439 \u0438\u0441\u0442\u0440\u0435\u0431\u0438\u0442\u0435\u043B\u044C\",\"quantity\":100,\"armor\":\"100\",\"baseDamage\":10,\"damage\":{\"armor\":{\"lightArmor\":1,\"mediumArmor\":1,\"heavyArmor\":0.5,\"reinforcedArmor\":0.3},\"hull\":{\"small\":1,\"medium\":1,\"large\":0.5,\"huge\":0.3}},\"armorType\":\"light\",\"hullSize\":\"small\"},\"1\":{\"shipId\":13,\"name\":\"\u0411\u043E\u043B\u044C\u0448\u043E\u0439 \u0442\u0440\u0430\u043D\u0441\u043F\u043E\u0440\u0442\",\"quantity\":10,\"armor\":\"100\",\"baseDamage\":10,\"damage\":{\"armor\":{\"lightArmor\":1,\"mediumArmor\":1,\"heavyArmor\":0.5,\"reinforcedArmor\":0.3},\"hull\":{\"small\":1,\"medium\":1,\"large\":0.5,\"huge\":0.3}},\"armorType\":\"medium\",\"hullSize\":\"large\"}},\"is_garrison\":null,\"name\":null,\"belongsTo\":\"self\",\"captain\":null,\"metal\":110600,\"crystal\":27705,\"gas\":3026}}}";
        var fleet = JSON.Parse(jsonStr);

        foreach (JSONNode JsonSide in fleet["sides"])
        {
            Side Side = new Side();
            GameObject sideObject = Side.Create(JsonSide);

            foreach (JSONNode ship in JsonSide["ships"])
            {
                //Debug.Log("id : " + ship["shipId"] + "name : " + ship["name"]);

                //ShipGenerator shipGenerator = new ShipGenerator();
                //GameObject shipObject = shipGenerator.create(sideObject, ship);

            }

        }
    }
}
