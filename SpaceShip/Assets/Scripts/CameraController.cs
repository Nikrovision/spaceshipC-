using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public Ray ray;
    public Vector2 mousePos;

    private Transform target;
    private GameObject player;
    private Vector3 wantedPosition;

    public float distance = 50.0f;
    public float height = 3.0f;
    public float damping = 15.0f;
    public float rotationDamping = 1.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
    }

    void Update()
    {//Создаем луч к позиции мыши на экране
        ray = Camera.main.ScreenPointToRay(mousePos);
        if (Input.GetAxis("Mouse ScrollWheel") < 0)//Задаем приближение и отдаление камеры вращением колесика мышки
        {
            distance = distance - 5;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
           distance = distance + 5;
        }
    }

    void LateUpdate()
    {
        SmoothFollow();
    }

    void SmoothFollow()
    {
        //Обеспечивает гладкость слежения
        wantedPosition = target.TransformPoint(0, height, -distance);

        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

        Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);

        transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);

        transform.LookAt(target, target.up);
    }
}