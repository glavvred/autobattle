using System.Collections.Generic;

public static class ShipsController
{
    public static List<SpaceShip> Ships = new List<SpaceShip>();

    public static List<SpaceShip> FindMyTargets(SpaceShip attacker)
    {
        List<SpaceShip> result = Ships.FindAll(ship =>
            (ship.shipSize == attacker.bestTarget.Item1 && ship.shipArmor == attacker.bestTarget.Item2));
        return result;
    }
}