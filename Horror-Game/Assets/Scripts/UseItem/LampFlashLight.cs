using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private Light flashLight;

    private void Start()
    {
        flashLight.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (flashLight.enabled == false)
            {
                flashLight.enabled = true;
            }
            else
            {
                flashLight.enabled = false;
            }
        }
    }
}
