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
    public float attackSpeed = 5f;
    public GameObject Spinner;
    public GameObject rangeAttack;
    public void OnRangedAttack()
    {
        if (ShotCooldown > 3 && Time.timeScale >= 0.1)
        {
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
        }
    }
}

