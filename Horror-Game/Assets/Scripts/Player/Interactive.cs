using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interractive : MonoBehaviour
{
    [SerializeField] private Camera fpcCamera; // Объект камеры

    private Ray ray; // Луч
    private RaycastHit hit; // Столкновение луча

    [SerializeField] private float maxDistanceRay; // Расстояние взаимодействия луча
 
    private void Update()
    {
        Ray();
        DrawRay();
    }
    
    // Метод инициализации луча взаимодействия
    private void Ray()
    {
        ray = fpcCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

    }

    // Метод для дебага луча взаимодействия
    // Позже его можно закомментировать
    private void DrawRay()
    {
        if (Physics.Raycast(ray, out hit, maxDistanceRay))
        {
            Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.blue);
        }
        if (hit.transform == null)
        {
            Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.red);
        }
    } 
}
