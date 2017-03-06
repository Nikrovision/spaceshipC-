using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait, startWait, waveWait;

    IEnumerator SpawnAsteroids()
    {
        yield return new WaitForSeconds(startWait);//Стартовая задержка респауна астероидов
        while(true)
        {
            for (int i = 0; i < hazardCount; i++)
            {//Задаем координаты появления астероидов
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);//Задержка между появлениями астероидов
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
    void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

}
