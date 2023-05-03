using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipPrefab : MonoBehaviour
{
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 newScale = obj.transform.localScale;
        newScale.x *= -1;
        obj.transform.localScale = newScale;

    }
}