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

    WeaponStats current_weapon_stats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 fire_position = transform.position;
            fire_position += transform.forward * 1;

            Instantiate(bullet_prefav, fire_position, transform.rotation);
        }
    }
}
