using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poles : MonoBehaviour
{
    private Vector3 movementSpeed = new Vector3 (5f, 0f, 0f);
    void Update()
    {
        transform.position -= movementSpeed * Time.deltaTime;

        if (transform.position.x < -15f)
        {
            //GameManager.poles.Remove(this.gameObject);
            Destroy(this.gameObject);

        }
        /*if (transform.position.x <= -2 && !GameManager.poles.Contains(this.gameObject))
        {
            GameManager.points += 1;
            GameManager.poles.Add(this.gameObject);
            Debug.Log(GameManager.points);
        }*/
    }

}
