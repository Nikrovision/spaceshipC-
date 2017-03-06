using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collison : MonoBehaviour {

	//Метод принимает объект класса Collision, с которым происходит столкновение
    void OnCollisionEnter(Collision myCollision)
    {
        //Столкновение с объектом
        if (myCollision.gameObject.name == "asteroid3")
        {
            //Указание на объект с которым столкнулись 
            Debug.Log("Hit the asteroid3");
        }
        else if (myCollision.gameObject.name == "asteroid1")
        {
            //Указание на объект с которым столкнулись 
            Debug.Log("Hit the asteroid1");
        }
        else if (myCollision.gameObject.name == "asteroid2")
        {
            //Указание на объект с которым столкнулись 
            Debug.Log("Hit the asteroid2");
        }
    }
}
