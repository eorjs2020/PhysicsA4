using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletBehaviour : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public float range;
    public float bulletX;
    public float bulletY;
    public float bulletZ;
    public float mass;
    public Vector3 velocity;
    public int lifetime, maxLifetime;

    private MeshFilter meshFilter;
    public bool isColliding;
  
    // Start is called before the first frame update
    void Start()
    {        
        isColliding = false;
        mass = 1;
        meshFilter = GetComponent<MeshFilter>();
        lifetime = 0;
        maxLifetime = 500;
    }

    // Update is called once per frame
    void FixedUpdate()
    {       
        velocity = direction * speed;
        _BoxHit();  
        _Move();
        _CheckBounds();
        ++lifetime;
    }
    
    private void _Move()
    {
        transform.position += velocity * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) > range)
        {
            gameObject.SetActive(false);
        }
        if(lifetime >= maxLifetime)
        {
            gameObject.SetActive(false);
        }
    }

    private void _BoxHit()
    {
        if(isColliding == true )
        {                       
            //speed = (((mass - 10) / (mass + 10)) * speed) + (((2 * 10) / mass + 10) * 0);
            transform.position += velocity * Time.deltaTime;
            isColliding = false;
        }
    }

}
