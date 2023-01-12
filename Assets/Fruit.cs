using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject fruitSlicedPrefab;

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Blade")
        {
            Debug.Log("Kat gya");
            //collision stores the position of the mouse pointer
            Vector3 direction = (collision.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            Instantiate(fruitSlicedPrefab, transform.position, rotation);
            //Destroy(gameObject);
        }

    }
}
