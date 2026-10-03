using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShipPickUpItem : MonoBehaviour
{
    private Image itemImageHolder { get; set; }
     ShipBehaviour ship { get; set; }


public ShipPickUpItem(Image item,ShipBehaviour sb){
        itemImageHolder = item;
        ship = sb;
}
    public void PickUpItem(GameObject item) {

        Color color = item.gameObject.GetComponent<Renderer>().material.color;

        Destroy(item);

        ship.items.Add(color);

        ship.activeItemIndex = ship.items.Count - 1;

        itemImageHolder.color = ship.items[ship.activeItemIndex];
        itemImageHolder.enabled = true;
    }
}
