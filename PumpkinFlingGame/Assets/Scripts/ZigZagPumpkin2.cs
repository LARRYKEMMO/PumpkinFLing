using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagPumpkin2 : MonoBehaviour
{
    private bool Switch = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Switch == false)
        {
            gameObject.transform.position -= new Vector3(2f * Time.deltaTime, 0f, 0f);

            if (gameObject.transform.position.x <= -8f)
            {
                Switch = true;
            }
        }
        else if (Switch == true)
        {
            gameObject.transform.position += new Vector3(2f * Time.deltaTime, 0f, 0f);

            if (gameObject.transform.position.x >= 8)
            {
                Switch = false;
            }
        }
    }
}
