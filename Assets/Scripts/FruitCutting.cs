using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitCutting : MonoBehaviour {

    
    public GameObject slicePrefab;

    Rigidbody rb;

    public float startForce = 15.0f;
  

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.up * startForce , ForceMode.Impulse);
	}

    private void OnMouseDown()
    {
        if (fruit.index <= 2 && !fruit.isLose)
        {
            fruit.Count++;


            GameObject slice = Instantiate(slicePrefab, gameObject.transform.position, gameObject.transform.rotation);

            Destroy(gameObject);

            Destroy(slice, 3.0f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        { 
            if (fruit.index <= 2 && !fruit.isLose)
            {
                fruit.Count++;
               

                GameObject slice = Instantiate(slicePrefab, gameObject.transform.position, gameObject.transform.rotation);

                Destroy(gameObject);

                Destroy(slice, 3.0f);
            }
        

        }
    }
}
