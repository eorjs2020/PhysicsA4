using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CollisionManager : MonoBehaviour
{
    public CubeBehaviour[] actors;
    public BulletBehaviour[] bullet;
    public Vector3 collisionPoint;
    // Start is called before the first frame update
    void Start()
    {
      
        actors = FindObjectsOfType<CubeBehaviour>();
        
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        bullet = FindObjectsOfType<BulletBehaviour>();
        /*for (int i = 0; i < bullet.Length; i++)
        {
            bullet[i].isColliding = false;
        }
        for (int i = 0; i < actors.Length; i++)
        {
            actors[i].isColliding = false;
        }*/


        for (int i = 0; i < bullet.Length; i++)
        {
            for (int j = 0; j < actors.Length; j++)
            {
                if (i != j)
                {
                    CheckAABBandSphere(bullet[i], actors[j]);
                }
            }
        }

        for (int i = 0; i < actors.Length; i++)
        {
            for (int j = 0; j < actors.Length; j++)
            {
                if (i != j)
                {
                    CheckAABBs(actors[i], actors[j]);
                }
            }
        }
    }

    public static void CheckAABBs(CubeBehaviour a, CubeBehaviour b)
    {
        if ((a.min.x <= b.max.x && a.max.x >= b.min.x) &&
            (a.min.y <= b.max.y && a.max.y >= b.min.y) &&
            (a.min.z <= b.max.z && a.max.z >= b.min.z))
        {
            if (!a.contacts.Contains(b))
            {
                a.contacts.Add(b);
                a.isColliding = true;
            }
        }
        else
        {
            if (a.contacts.Contains(b))
            {
                a.contacts.Remove(b);
                a.isColliding = false;
            }

        }
    }
    public static void CheckAABBandSphere(BulletBehaviour a, CubeBehaviour b)
    {
        float radius = 0.06f;
        var x = Mathf.Max(b.min.x, Mathf.Min(a.transform.position.x, b.max.x));
        var y = Mathf.Max(b.min.y, Mathf.Min(a.transform.position.y, b.max.y));
        var z = Mathf.Max(b.min.z, Mathf.Min(a.transform.position.z, b.max.z));

        var distance = Mathf.Sqrt((x - a.transform.position.x) * (x - a.transform.position.x) +
            (y - a.transform.position.y) * (y - a.transform.position.y) +
            (z - a.transform.position.z) * (z - a.transform.position.z));

        if(distance < radius)
        {
            if (a.transform.position.x > b.max.x)
            {
                a.direction.x *= -1;
            }
            else if (a.transform.position.x < b.min.x)
            {
                a.direction.x *= -1;
            }

            if (a.transform.position.y > b.max.y)
            {
                a.direction.y *= -1;
            }
            else if (a.transform.position.y < b.min.y)
            {
                a.direction.y *= -1;
            }

            if (a.transform.position.z > b.max.z)
            {
                a.direction.z *= -1;
            }
            else if (a.transform.position.z < b.min.z)
            {
                a.direction.z *= -1;
            }
            a.isColliding = true;
            b.isColliding = true;
        }

        



        /*  Vector3 temp;
          temp.x = Mathf.Abs(a.transform.position.x - b.transform.position.x);
          temp.y = Mathf.Abs(a.transform.position.y - b.transform.position.y);
          temp.z = Mathf.Abs(a.transform.position.z - b.transform.position.z);

          temp.x = temp.x / Mathf.Sqrt(temp.x);
          temp.y = temp.y / Mathf.Sqrt(temp.y);
          temp.z = temp.z / Mathf.Sqrt(temp.z);


          float smalltemp = 0.0f;
          float bigtemp = 0.0f;
          float difftemp = 0.0f;
          bool xs = false, xb = false, ys = false, yb = false, zs = false, zb = false;
          System.Console.WriteLine(temp.x);


          if (temp.x < temp.y)
          {
              smalltemp = temp.x;
              bigtemp = temp.y;
              xs = true;
              yb = true;
          }
          else
          {
              bigtemp = temp.x;
              smalltemp = temp.y;
              ys = true;
              xb = true;
          }
          if (temp.z < smalltemp)
          {
              smalltemp = temp.z;
              xs = false;
              ys = false;
              zs = true;
          }
          if (temp.z > bigtemp)
          {
              bigtemp = temp.z;
              xb = false;
              yb = false;
              zb = true;
          }
          difftemp = 1 - bigtemp;

          if (difftemp < smalltemp)
          {
              xs = false;
              ys = false;
              zs = false;
          }
          else
          {
              xb = false;
              yb = false;
              zb = false;
          }
          if (a.isColliding)
          {
              if (zb || zs)
              {
                  a.direction.z = a.direction.z * -1;
              }
              if (xb || xs)
              {
                  a.direction.x = a.direction.x * -1;
              }
              if (yb || ys)
              {
                  a.direction.y = a.direction.y * -1;
              }
          }
          */



    }
}
