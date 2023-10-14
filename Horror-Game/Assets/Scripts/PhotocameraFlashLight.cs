using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotocameraFlashLight : MonoBehaviour
{
    [SerializeField] private Light flashLight;
    [SerializeField] private float flashTime;   // Длительность вспышки
    [SerializeField] private float reloadTime;  // Время перезарядки фотоапарата
    private bool isFlashing;
    private float flashTimer;

    private void Start()
    {
        flashLight.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isFlashing)
        {
            StartCoroutine(StartFlash());
        }
    }

    private IEnumerator StartFlash()
    {
        isFlashing = true;
        flashTimer = flashTime;
        flashLight.enabled = true;

        while (flashTimer > 0)
        {
            flashTimer -= Time.deltaTime;
            yield return null;
        }

        flashLight.enabled = false;

        yield return new WaitForSeconds(reloadTime);
        isFlashing = false;
    }
}
