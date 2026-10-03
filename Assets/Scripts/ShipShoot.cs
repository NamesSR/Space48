using UnityEngine;

public class ShipShoot : MonoBehaviour
{
    float cooldownCounter;
    private GameObject laserPrefab { get; set; }
    public float cooldownTime { get; set; }
    Transform tf;

public ShipShoot(GameObject laserprefab, float cooldown, Transform sd3){
        laserPrefab = laserprefab;
        cooldownTime = cooldown;
        tf = sd3;

}

    public void Shoot() {
        cooldownCounter += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && cooldownCounter > cooldownTime)
        {
            GameObject laser = Instantiate(laserPrefab);
            laser.transform.position = tf.position;
            laser.transform.rotation = tf.rotation;
            Destroy(laser, 3f);

            cooldownCounter = 0f;

        }


    }

}
