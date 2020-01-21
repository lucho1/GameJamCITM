using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct WeaponStats
{
    public float fire_rate;
}

public class WeaponController : MonoBehaviour
{
    public GameObject bullet_prefav;
    private Timer weaponShootTime;
    public float fireRate = 1.0f;



    [Range (1,2)]public int controllerNumber;

    private string fireButton;

    public int layerMask;

    WeaponStats current_weapon_stats;

    // Start is called before the first frame update
    void Start()
    {
        fireButton = "FireButton" + controllerNumber.ToString();
        weaponShootTime = gameObject.GetComponent<Timer>();
        weaponShootTime.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(fireButton) > 0 && weaponShootTime.ReadTime() > fireRate)
        {
            weaponShootTime.Start();
            Vector3 fire_position = transform.position;
            fire_position += transform.forward * 1;

            GameObject newBullet = Instantiate(bullet_prefav, fire_position, transform.rotation);
            newBullet.layer = layerMask;
        }
    }
}
