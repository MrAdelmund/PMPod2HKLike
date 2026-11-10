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
    public float attackSpeed;
    public GameObject Spinner;
    public void OnRangedAttack()
    {
        if (ShotCooldown > 3 && Time.timeScale >= 0.1)
        {
            Debug.Log("it's reading this"); //works
            GameObject shot = Instantiate(Spinner, transform.position, Quaternion.identity); //works
            Destroy(shot, 10); //works
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)); mousePos = Camera.main.ScreenToWorldPoint(mousePos); //Didn't work
            print(mousePos); //works
            Vector2 myPosition = transform.position; //Didn't work
            Vector2 direction = (mousePos - myPosition).normalized; //Based on previous line
            shot.GetComponent<Rigidbody2D>().linearVelocity = direction * attackSpeed; //works
            ShotCooldown = 0; //works
        }
    }
}

