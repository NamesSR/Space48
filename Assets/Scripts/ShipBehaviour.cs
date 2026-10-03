using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShipBehaviour : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 25f;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float cooldownTime = 3f;
    [SerializeField] private Image itemImageHolder;
    [SerializeField] private TMP_Text introductionField;
    [SerializeField] private TMP_Text messageField;

    private float cooldownCounter = 0f;
    public List<Color> items = new List<Color>();
    public int activeItemIndex = -1;
    public ShipBehaviour sb;
    Movement movement;
    ShipRotation shipRot;
    ShipShoot shipshoot;
    ShipPickUpItem shippickupitem;
    ShipCycleItems shipcycleitems;
    ShipUseItems shipuseitem;
    public Transform tf;

    private void Awake()
    {


        movement = new Movement(true, moveSpeed, tf);
        shipRot = new ShipRotation(rotationSpeed,tf);
        shipshoot = new ShipShoot(laserPrefab, cooldownTime,tf);
        shippickupitem = new ShipPickUpItem(itemImageHolder,sb);
        shipcycleitems = new ShipCycleItems(itemImageHolder,sb);
        shipuseitem = new ShipUseItems(this.gameObject, movement, shipRot, shipshoot, itemImageHolder);
        Debug.Log(movement.moveSpeed);
    }
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(ShowMessage("Welcome to Space 4 8. \n Move your ship with the arrows or WASD. \n Shoot with SPACE. \n Gather pickups and cycle with 'Left CTR'.  \n  Use pickups with 'E'."));
    }

    public IEnumerator ShowMessage(string message)
    {
        messageField.enabled = true;
        messageField.text = message;
        yield return new WaitForSeconds(3f);
        messageField.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        movement.Move();
        shipRot.Rotate();
        shipshoot.Shoot();
        shipcycleitems.CycleItems();
        shipuseitem.UseItem();

    }


    // public void GetScripts()
    // {
    //     movement = new Movement(true, moveSpeed);
    //     shipRot = new ShipRotation(rotationSpeed);
    //     shipshoot = new ShipShoot(laserPrefab, cooldownTime);
    //     shippickupitem = new ShipPickUpItem(itemImageHolder);
    //     shipcycleitems = new ShipCycleItems(itemImageHolder);
    //     shipuseitem = new ShipUseItems(sb,movement,shipRot,shipshoot,itemImageHolder);
    // }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            shippickupitem.PickUpItem(other.gameObject);
        }
    }





}
