using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Movment : MonoBehaviour
{
    public Slider slider;
    private List<Vector2> coordinates = new List<Vector2>();
    [SerializeField]
    private float speed = 0.01f;

    void Update()
    {
        if (coordinates.Count > 0) //в массиве значения больше 0 то он двигается 
        {
            transform.position = Vector2.Lerp(transform.position, coordinates[0], speed); //движение объекта (объект, кооридинаты на которые передвигается, скорость)

            if(Vector2.Distance(coordinates[0], transform.position) < 0.01f) // определение дистанции (координата до которой идет, объект) < дистануии между объектом и точкой до которой идет 
            {
                coordinates.RemoveAt(0); // удаление нынешней координаты
            }
        }

        if (Input.GetMouseButton(0)) //проверка, был ли сделан клик
        {
            SetTargetPosition();
        }
    }

    private void SetTargetPosition()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        coordinates.Add(new Vector2(mousePos.x, mousePos.y)); //заполнение списка каординатами 
    }
}
