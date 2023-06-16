using System;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelection : MonoBehaviour
{
    List<GameObject> ships = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {

    }

    public void AddShip(GameObject ship)
    {
        ships.Add(ship);
    }

    public void RemoveShip(GameObject ship)
    {
        ships.Remove(ship);
    }

    public Boolean CheckShip(GameObject ship)
    {
        if (ships.Contains(ship))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
