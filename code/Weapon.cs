using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject BulletPrefad;
    public float fireRate = 0.1f;  // 控制發射速度
    private bool isFiring = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && !isFiring)  // 按住Fire1時
        {
            isFiring = true;
            StartCoroutine(FireContinuously());
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            isFiring = false;
            StopCoroutine(FireContinuously());  // 停止連續發射
        }
    }

    IEnumerator FireContinuously()
    {
        while (isFiring)
        {
            Shoot();
            yield return new WaitForSeconds(fireRate);  // 控制發射速率
        }
    }

    void Shoot()
    {
        Instantiate(BulletPrefad, firepoint.position, firepoint.rotation);
    }
}

