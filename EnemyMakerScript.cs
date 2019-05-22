using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMakerScript : MonoBehaviour {

	// Use this for initialization
	public GameObject enemyGo;
public Sprite[] myImages;



	void Start ()
	 {
		 InvokeRepeating("makeAnEnemyAction",1,3);
		
	}
	
	// Update is called once per frame
	void makeAnEnemyAction() 
	{
		GameObject newEnemyGo = (GameObject) Instantiate (enemyGo) as GameObject;
		float x = Random.Range (-5.5f,5.5f);
		float y = -3;
		float z = 6;

		newEnemyGo.transform.position = new Vector3 (x,y,z);
		newEnemyGo.GetComponent<SpriteRenderer>().sprite=myImages[Random.Range(0,myImages.Length)];
		newEnemyGo.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 550);



	}
}
