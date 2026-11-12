using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SpinnerCD : MonoBehaviour
{

    public Image ImageShotCD;
    public Sprite ShotRDY;
    public Sprite Shot2;
    public Sprite Shot1;
    public Sprite Shot0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShotCooldown = 3;
    }

    // Update is called once per frame
    void Update()
    {
        ShotCooldown += Time.deltaTime;
        if (ShotCooldown == 3)
        {
            ImageShotCD.sprite = ShotRDY;
        }
        if (ShotCooldown == 2)
        {
            ImageShotCD.sprite = Shot2;
        }
        if (ShotCooldown == 1)
        {
            ImageShotCD.sprite = Shot1;
        }
        if (ShotCooldown == 0)
        {
            ImageShotCD.sprite = Shot0;
        }
        //image didn't change, look into later, working on the ranged attack even working
    }

    public Vector3 offset;
    private float ShotCooldown;
<<<<<<< HEAD
    public float attackSpeed = 5f;
=======
    public float attackSpeed;
>>>>>>> e9dcb260eb14eb134cb0e99f217cf093dd01082d
    public GameObject Spinner;
    public GameObject rangeAttack;
    public void OnRangedAttack()
    {
        if (ShotCooldown > 3 && Time.timeScale >= 0.1)
        {
<<<<<<< HEAD
            ShotCooldown = 0;

            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0f;

            // 2. Calculate direction and angle
            Vector2 shootDir = (mousePos - transform.position).normalized;
            float angle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg;

            // 3. Spawn and launch
            GameObject rangeAttack = Instantiate(Spinner, transform.position, Quaternion.Euler(0f, 0f, angle));
            rangeAttack.GetComponent<Rigidbody2D>().linearVelocity = shootDir * attackSpeed;
            Destroy(rangeAttack, 5f);
            Debug.Log("Player be shooting");
=======
            Debug.Log("it's reading this"); //works
            GameObject shot = Instantiate(Spinner, transform.position, Quaternion.identity); //works
            Destroy(shot, 10); //works
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)); mousePos = Camera.main.ScreenToWorldPoint(mousePos); //Didn't work
            print(mousePos); //works
            Vector2 myPosition = transform.position; //Didn't work
            Vector2 direction = (mousePos - myPosition).normalized; //Based on previous line
            shot.GetComponent<Rigidbody2D>().linearVelocity = direction * attackSpeed; //works
            ShotCooldown = 0; //works
>>>>>>> e9dcb260eb14eb134cb0e99f217cf093dd01082d
        }
    }
}

