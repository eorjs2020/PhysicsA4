using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Color = UnityEngine.Color;


[System.Serializable]
public class CubeBehaviour : MonoBehaviour
{
    public Vector3 size;
    public Vector3 max;
    public Vector3 min;
    public bool isColliding;
    public bool debug;
    public List<CubeBehaviour> contacts;
    public float friction;
    public float mass;
    public Vector3 direction;
    public Vector3 velocity;
    public bool movable;
    public bool hasGravity;
    public bool Ground;

    public Vector3 gravity;
    private float mesh;
    public float speed;
    public MeshFilter meshFilter;
    private Bounds bounds;

    // Start is called before the first frame update
    void Start()
    {
        debug = false;
        meshFilter = GetComponent<MeshFilter>();
        speed = 0;
        bounds = meshFilter.mesh.bounds;
        size = bounds.size;
        friction = 0.0f;
        mass = 50;
        hasGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        max = Vector3.Scale(bounds.max, transform.localScale) + transform.position;
        min = Vector3.Scale(bounds.min, transform.localScale) + transform.position;
    }

    void FixedUpdate()
    {
        gravity = new Vector3(0.0f, -0.98f, 0.0f);
        _BoxHit();
        _Move();
       
        // physics related calculations
    }
    private void _Move()
    {
        
        if(speed > 0)
        {
            speed *= (1 - friction);
        }
        else if (speed < 0.00001)
        {
            speed = 0;
        }
        
        transform.position += direction * speed * Time.deltaTime;
        if(movable && hasGravity)
        {
            transform.position += gravity * Time.deltaTime;
        }
               
    }
    

    private void _BoxHit()
    {
        if (isColliding == true)
        {            
            velocity = direction * speed;
            transform.position += velocity * Time.deltaTime;           
            isColliding = false;
        }
    }

    private void OnDrawGizmos()
    {
        
          Gizmos.color = Color.magenta;
            
          Gizmos.DrawWireCube(transform.position, Vector3.Scale(new Vector3(1.0f, 1.0f, 1.0f), transform.localScale));
       
    }

    public void _changeFriction(float a)
    {
        friction = a;
    }

    public void _changeMass(float a)
    {
        mass = a;
    }
}
