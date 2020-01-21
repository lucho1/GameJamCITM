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

    [Range (1,2)]public int controllerNumber;

    private string fireButton;

    WeaponStats current_weapon_stats;

    public int layer;

    // Start is called before the first frame update
    void Start()
    {
        fireButton = "FireButton" + controllerNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(fireButton)>0)
        {
            Vector3 fire_position = transform.position;
            fire_position += transform.forward * 1;

            GameObject newBullet = Instantiate(bullet_prefav, fire_position, transform.rotation);
            newBullet.layer = layer;
        }
    }
}
