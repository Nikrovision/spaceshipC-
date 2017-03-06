using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public int maxSpeed = 70;
    public int minSpeed = 0;
    public float rotationSpeed = 150;
    public bool status = false;

    public int currrentSpeed = 30;
    private GameObject[] turbines;
    public GameObject Shot;
    public Transform ShotSpawn;
    public float FireRate;
    private float NextFire;

    //Инициализируем турбины
    void Start()
    {
        turbines = GameObject.FindGameObjectsWithTag("Turbine");
    }

    void Update()
    {//Производим выстрелы ракетами при нажатии ЛКМ
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
        }
    }

    void LateUpdate()
    {
        if (status)
        {
            //Менеджер вращения
            if (Input.GetKey(KeyCode.A))
                transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);
            else if (Input.GetKey(KeyCode.D))
                transform.Rotate(0, 0, -Time.deltaTime * rotationSpeed);

            //Максимальная скорость
            if (Input.GetKey(KeyCode.W))
            {
                currrentSpeed = maxSpeed;
                MaxTurbines(0.65f);//Количество огня из турбин
            }
            //Минимальная скорость
            else if (Input.GetKey(KeyCode.S))
            {
                currrentSpeed = minSpeed;
                MaxTurbines(0.3f);
            }
            //Постоянная скорость, без учета нажатия клавиш управления
            else
            {
                currrentSpeed = 10;
                MaxTurbines(0.55f);
            }

            Vector3 mouseMovement = (Input.mousePosition - (new Vector3(Screen.width, Screen.height, 0) / 2.0f)) * 1;
            transform.Rotate(new Vector3(-mouseMovement.y, mouseMovement.x, -mouseMovement.x) * 0.025f);
            transform.Translate(Vector3.forward * Time.deltaTime * currrentSpeed);
        }
    }
    //Максимальный огонь из турбин
    void MaxTurbines(float intensity)
    {
        foreach (GameObject turbine in turbines)
        {
            turbine.GetComponent<LensFlare>().brightness = intensity;
        }
    }

}