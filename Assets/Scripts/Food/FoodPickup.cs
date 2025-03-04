using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPickup : MonoBehaviour
{
    // Speed food rotates in degrees per second
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    // Called when Player picks up food
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
