using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour {
	
	public GameObject cubo;
	public GameObject container;

	// Update is called once per frame
	void Start () {
		//LevelManager.numerador = 3;
		int numerador = (LevelManager.numerador);
		for(int i=0; i < numerador; i++){
			Instantiate(cubo, new Vector3(Random.Range(-25.0f, 30.0f), Random.Range(1.0f, 5.0f), Random.Range(0.0f, -28.0f)), Quaternion.identity);
		}

		int denominador = (LevelManager.denominador);

		float altura = 3.5f;
		float x = 27.0f;
		float z = 23.0f;

		for(int i=0; i < denominador; i++){
			switch(i){
				case 0:
					Instantiate(container, new Vector3(-34.4f, altura, 34.4f), Quaternion.identity);
					break;
				case 1:
					Instantiate(container, new Vector3(0.0f, altura, 34.4f), Quaternion.identity);
					break;
				case 2:
					Instantiate(container, new Vector3(34.0f, altura, 34.4f), Quaternion.identity);
					break;
				case 3:
					Instantiate(container, new Vector3(-34.4f, altura, -4.0f), Quaternion.identity);
					break;
				case 4:
					Instantiate(container, new Vector3(0.0f, altura, -4.0f), Quaternion.identity);
					break;
				case 5:
					Instantiate(container, new Vector3(34.4f, altura, -4.0f), Quaternion.identity);
					break;
				case 6:
					Instantiate(container, new Vector3(-34.4f, altura, -36.0f), Quaternion.identity);
					break;
				case 7:
					Instantiate(container, new Vector3(0.0f, altura, -36.0f), Quaternion.identity);
					break;
				case 8:
					Instantiate(container, new Vector3(34.4f, altura, -36.0f), Quaternion.identity);
					break;
			}
		}

	}
}