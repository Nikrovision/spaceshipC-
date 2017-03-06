using UnityEngine;
using System.Collections;

public class SpeedParticles : MonoBehaviour {

    private PlayerController player;

    //Инициализация
    void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();						
	}
	
	// Обновляем каждый кадр
	void Update () {
		if (player.status){
			if(player.currrentSpeed <= 15)
				GetComponent<ParticleEmitter>().emit = false;
			else{
				GetComponent<ParticleEmitter>().emit = true;
				Vector3 aux = GetComponent<ParticleEmitter>().localVelocity;
				aux.z = -(player.currrentSpeed*50)/20;
				GetComponent<ParticleEmitter>().localVelocity = aux;
			}
		}
		else
			GetComponent<ParticleEmitter>().emit = false;
	}
}
