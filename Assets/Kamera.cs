using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    [SerializeField] Transform koira;

    [SerializeField] float vasenRaja;
    [SerializeField] float oikeaRaja;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalPos = Mathf.Clamp(koira.transform.position.x, vasenRaja, oikeaRaja);
        transform.position = new Vector3(horizontalPos, 0, -10);
    }
}
