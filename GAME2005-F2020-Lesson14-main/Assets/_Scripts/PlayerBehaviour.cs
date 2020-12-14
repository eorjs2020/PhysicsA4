using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bullet;
    public GameObject[] cubes;
    public int fireRate;
    public static float bulletSpeed;
    public static float bulletMass;
    public float bulletLifetime;
    private bool toggleMouse;

    public BulletManager bulletManager;

    void start()
    {
        if (cubes == null)
            cubes = GameObject.FindGameObjectsWithTag("obstacle");
        bulletSpeed = 5;
        bulletMass = 1;
        bulletLifetime = 500.0f;
        toggleMouse = false;

         
    }

    // Update is called once per frame
    void Update()
    {
        _Fire();
        //Dont know how to make this work 
        if (Input.GetKeyDown(KeyCode.U))
        {
            toggleMouse = !toggleMouse;
            //Cursor.lockState.Equals(CursorLockMode.None);
           
           Cursor.visible = true;
            
            print(Cursor.lockState);
        }
        _BoxUpdate();

    }
    public void _changeSpeed(float a)
    {
        bulletSpeed = a;
    }

    public void _changeMass(float a)
    {

        bulletMass = a;
    }

    public void _changeLifetime(float a)
    {
        bulletLifetime = a;
    }

    private void _Fire()
    {
        if (Input.GetAxisRaw("Fire1") > 0.0f)
        {
            // delays firing
            if (Time.frameCount % fireRate == 0)
            {
                if (bulletSpeed == 0)
                {
                    bulletSpeed = 5;
                }
                if (bulletLifetime == 0)
                {
                    bulletLifetime = 500.0f;
                }
                if (bulletMass == 0)
                {
                    bulletMass = 1;
                }

                GameObject obj = BulletManager.current.GetActiveObject();
                if (obj == null) return;
                obj.transform.position = bulletSpawn.position;
                obj.transform.rotation = bulletSpawn.rotation;
                obj.GetComponent<BulletBehaviour>().lifetime = 0;
                obj.GetComponent<BulletBehaviour>().direction = bulletSpawn.forward;
                obj.GetComponent<BulletBehaviour>().speed = bulletSpeed;
                obj.GetComponent<BulletBehaviour>().mass = bulletMass;
                obj.GetComponent<BulletBehaviour>().maxLifetime = bulletLifetime;
                obj.SetActive(true);
                /*var tempBullet = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
                tempBullet.GetComponent<BulletBehaviour>().direction = bulletSpawn.forward;

                tempBullet.transform.SetParent(bulletManager.gameObject.transform);*/
            }

        }
    }

    private void _BoxUpdate()
    {
       
    }

}
