using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ShipCycleItems : MonoBehaviour
{
    private Image itemImageHolder { get; set; }


    ShipBehaviour ship { get; set; }

    public ShipCycleItems(Image item,ShipBehaviour sb){
            itemImageHolder = item;
        ship = sb;
    }
    public void CycleItems()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (ship.items.Count > 0)
            {
                if (ship.activeItemIndex < ship.items.Count - 1)
                {
                    ship.activeItemIndex++;
                }
                else
                {
                    ship.activeItemIndex = 0;
                }
                itemImageHolder.color = ship.items[ship.activeItemIndex];
            }
            else
            {
                itemImageHolder.color = Color.white;
                ship.activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }
        }
    }
}
