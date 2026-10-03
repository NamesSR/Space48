using UnityEngine;

public class ShipRotation : MonoBehaviour {

    public float rotationSpeed { get; set; }
    Transform tf { get; set; }


  public ShipRotation(float rotSpeed,Transform sd2){
        rotationSpeed = rotSpeed;
        tf = sd2;
    }
   public  void Rotate()
    {
        tf.Rotate(tf.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }
}
