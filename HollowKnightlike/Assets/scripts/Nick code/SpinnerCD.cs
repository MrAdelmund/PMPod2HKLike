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
    }
    private float ShotCooldown;
    private float attackSpeed = 10f;
    public GameObject Spinner;
    public void OnRangedAttack()
    {
        if (ShotCooldown > 3 && Time.timeScale >= 0.1)
        {
            /*ShotCooldown = 0;
            GameObject rangeAttack = Instantiate(Spinner, transform.position, Quaternion.identity);
            Destroy(rangeAttack, 5);

            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;

            Vector3 shootDir = mousePos - transform.position;
            shootDir.Normalize();
            rangeAttack.GetComponent<Rigidbody2D>().linearVelocity = shootDir * attackSpeed;*/

            Debug.Log("it's reading this");
            GameObject shot = Instantiate(Spinner, transform.position, Quaternion.identity);
            Destroy(shot, 10);
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            Debug.Log(mousePos);
            Vector3 shootDir = mousePos - transform.position;
            shootDir.Normalize();
            shot.GetComponent<Rigidbody2D>().linearVelocity = shootDir;
            shot.GetComponent<Rigidbody2D>().linearVelocity = shootDir * attackSpeed;
            ShotCooldown = 0;
        }
    }
}

