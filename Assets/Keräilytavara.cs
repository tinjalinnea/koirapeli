using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keräilytavara : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Koira")
        {
            Destroy(gameObject);
        }
    }
}
