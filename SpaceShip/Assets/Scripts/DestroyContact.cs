using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject PlayerExplosion;
    void OnTriggerEnter(Collider other)
    {//Разрушение метеорита при столкновении с кораблем
        if (other.tag == "Player")
        {
            Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
        }
        else if (other.tag == "Rocket")
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(other.gameObject);//Разрушение метеоритов при столкновении
        Destroy(gameObject);
    }

}