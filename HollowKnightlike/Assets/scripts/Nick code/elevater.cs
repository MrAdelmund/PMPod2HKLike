using UnityEngine;

public class elevater : MonoBehaviour
{
    [Header("It will move this much in this direction")] //whermst
    public Vector3 MoveBy;
    Vector3 pointA;
    Vector3 pointB;

    [Header("It will wait this long before moving again")]
    public float time_to_wait;
    float delay;
    [Header("how fast it moves")]
    public Vector3 SpeedAndDirection;
    //if this doesn't work, x means it will move right, -x will be left, even if you didn't put a x value on the MoveBy value.
    //I'dn't've if whomst wasn't whermst
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


