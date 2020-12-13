﻿using System.Collections;
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
    public bool movable; 

    private float mesh;
    private float speed;
    public MeshFilter meshFilter;
    private Bounds bounds;

    // Start is called before the first frame update
    void Start()
    {
        debug = false;
        meshFilter = GetComponent<MeshFilter>();
        speed = 4;
        bounds = meshFilter.mesh.bounds;
        size = bounds.size;
        friction = 0.1f; 
    }

    // Update is called once per frame
    void Update()
    {
        max = Vector3.Scale(bounds.max, transform.localScale) + transform.position;
        min = Vector3.Scale(bounds.min, transform.localScale) + transform.position;
    }

    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
        // physics related calculations
    }

    private void OnDrawGizmos()
    {
        
          Gizmos.color = Color.magenta;
            
          Gizmos.DrawWireCube(transform.position, Vector3.Scale(new Vector3(1.0f, 1.0f, 1.0f), transform.localScale));
       
    }
}
