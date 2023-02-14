using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public float amplitude = 0.2f;

    public float baseline = 0.8f;

    public float frequency = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        transform.localScale = new Vector3(Mathf.Sin(Time.time*frequency)*amplitude + baseline, 1, 1);
    }
}
