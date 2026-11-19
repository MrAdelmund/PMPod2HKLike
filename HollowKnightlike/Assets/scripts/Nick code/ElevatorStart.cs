using UnityEngine;

public class ElevatorStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<elevater>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<elevater>().enabled = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<elevater>().enabled = false;
    }
}
