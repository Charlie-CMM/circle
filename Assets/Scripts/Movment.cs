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
        if (coordinates.Count > 0) //� ������� �������� ������ 0 �� �� ��������� 
        {
            transform.position = Vector2.Lerp(transform.position, coordinates[0], speed); //�������� ������� (������, ����������� �� ������� �������������, ��������)

            if(Vector2.Distance(coordinates[0], transform.position) < 0.01f) // ����������� ��������� (���������� �� ������� ����, ������) < ��������� ����� �������� � ������ �� ������� ���� 
            {
                coordinates.RemoveAt(0); // �������� �������� ����������
            }
        }

        if (Input.GetMouseButton(0)) //��������, ��� �� ������ ����
        {
            SetTargetPosition();
        }
    }

    private void SetTargetPosition()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        coordinates.Add(new Vector2(mousePos.x, mousePos.y)); //���������� ������ ������������ 
    }
}
