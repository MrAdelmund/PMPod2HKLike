using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PatrolLtoR : MonoBehaviour
{
    /*public Vector2 Moveby;
    Vector2 PointA;
    Vector2 PointB;
    public float TimeToWait;
    float delay;
    public Vector2 SpeedAndDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.PointA = this.transform.position;
        this.PointB = this.PointA + Moveby;
        delay = TimeToWait;
    }
    bool isArrived(Vector2 pos, Vector2 target)
    {
        pos.y = 0;
        target.y = 0;
        return Vector2.Distance(pos, target) <= 0.2f;
    }

    bool toB = true;

    void FixedUpdate()
    {
        TimeToWait -= Time.deltaTime;
        if (TimeToWait <= 0)
        {
            if (toB)
            {
                if(isArrived(this.transform.position, this.PointB) == false)
                {
                    this.transform.Translate(SpeedAndDirection * Time.deltaTime);
                }
                else
                {
                    toB = false;
                    TimeToWait = delay;
                }
            }
            if (!toB)
            {
                if(isArrived(this.PointA, this.transform.position) == false)
                {
                    this.transform.Translate(-SpeedAndDirection * Time.deltaTime);
                }
                else
                {
                    toB = true;
                    TimeToWait = delay;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }*/
    public Vector3 MoveBy;
    Vector3 pointA;
    Vector3 pointB;
    public float time_to_wait;
    float delay;
    public Vector3 SpeedAndDirection;
    void Start()
    {
        this.pointA = this.transform.position;
        this.pointB = this.pointA + MoveBy;
        delay = time_to_wait;
    }
    bool isArrived(Vector3 pos, Vector3 target)
    {
        pos.z = 0;
        target.z = 0;
        return Vector3.Distance(pos, target) <= 0.2f;
    }
    bool toB = true;
    void FixedUpdate()
    {
        time_to_wait -= Time.deltaTime;
        if (time_to_wait <= 0)
        {
            if (toB)
            {
                if (isArrived(this.transform.position, this.pointB) == false)
                {
                    this.transform.Translate(SpeedAndDirection * Time.deltaTime);
                }
                else
                {
                    toB = false;
                    time_to_wait = delay;
                }
            }
            if (toB == false)
            {
                if (isArrived(this.pointA, this.transform.position) == false)
                {
                    this.transform.Translate(-SpeedAndDirection * Time.deltaTime);
                }
                else
                {
                    toB = true;
                    time_to_wait = delay;
                }
            }
        }
    }
}

