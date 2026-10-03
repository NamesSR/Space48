using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShipUseItems : MonoBehaviour
{
    private Image itemImageHolder { get; set; }
    //private List<Color> items = new List<Color>();

    ShipBehaviour ship;
    Movement movement{ get; set; }
    ShipRotation shipRot{ get; set; }
    ShipShoot shipshoot{ get; set; }
    GameObject gb;

    public ShipUseItems(GameObject sb, Movement move, ShipRotation rot, ShipShoot shoot, Image item)
    {

        gb = sb;
        movement = move;
        shipRot = rot;
        shipshoot = shoot;
        itemImageHolder = item;




    }
   public  void UseItem()
    {
        if(ship == null){
            ship = gb.GetComponent<ShipBehaviour>();
        }

        if (Input.GetKeyDown(KeyCode.E) && ship.items.Count > 0 && ship.activeItemIndex != -1)
        {

            if (ship.items[ship.activeItemIndex] == Color.blue)
            {
                ship.StartCoroutine(ship.ShowMessage(" +  Move Speed"));
                movement.moveSpeed += 5;
            }
            else if (ship.items[ship.activeItemIndex] == Color.red)
            {
                ship.StartCoroutine(ship.ShowMessage(" + Fire Rate"));
                shipshoot.cooldownTime -= 0.1f;
            }
            else if (ship.items[ship.activeItemIndex] == Color.green)
            {
                ship.StartCoroutine(ship.ShowMessage(" + Rotation Speed"));
                shipRot.rotationSpeed += 10;
            }
            ship.items.RemoveAt(ship.activeItemIndex);
            if (ship.activeItemIndex > 0)
            {
                ship.activeItemIndex--;
                itemImageHolder.color = ship.items[ship.activeItemIndex];
            }
            else if (ship.items.Count == 0)
            {
                itemImageHolder.color = Color.white;
                ship.activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }

        }
    }
}
