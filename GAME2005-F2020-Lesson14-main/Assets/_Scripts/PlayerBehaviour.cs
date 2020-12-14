using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bullet;
    public int fireRate;
    public static float bulletSpeed;
    public static float bulletMass;
    private bool toggleMouse;

    public BulletManager bulletManager;

    void start()
    {
        bulletSpeed = 5;
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


    }
    public void _changeSpeed(float a)
    {
        bulletSpeed = a;
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
                   
                GameObject obj = BulletManager.current.GetActiveObject();
                if (obj == null) return;
                obj.transform.position = bulletSpawn.position;
                obj.transform.rotation = bulletSpawn.rotation;
                obj.GetComponent<BulletBehaviour>().lifetime = 0;
                obj.GetComponent<BulletBehaviour>().direction = bulletSpawn.forward;
                obj.GetComponent<BulletBehaviour>().speed = bulletSpeed;
                obj.GetComponent<BulletBehaviour>().mass = bulletMass;
                obj.SetActive(true);
                /*var tempBullet = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
                tempBullet.GetComponent<BulletBehaviour>().direction = bulletSpawn.forward;

                tempBullet.transform.SetParent(bulletManager.gameObject.transform);*/
            }

        }
    }
    

}
