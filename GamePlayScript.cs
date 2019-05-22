using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GamePlayScript : MonoBehaviour
 {
	 public GameObject gameOverPanel;
	 AudioSource gunShotAudioSourse;
	 public AudioClip gunShotClip;


	 public GameObject timerTextValue;
	 public GameObject scoreTextValue;
	 int roundShot = 0;
	 int enemyKilled = 0;


	
	 public GameObject crossHairObj ;
	 bool gameIsPaused = false;





      public int gameTime ;
	 



	// Use this for initialization
	void Start ()
	 {

		 scoreTextValue.GetComponent<Text>().text = enemyKilled.ToString()+" / " + roundShot.ToString();

		 gunShotAudioSourse = gameObject.GetComponent<AudioSource>();

      InvokeRepeating ( "timeCounterAction" , 0, 1);
    }
	int timeMinutes;
	int timeSeconds;

	void timeCounterAction()

	{
		if ( gameTime >= 0)
		{
		timeMinutes = (int)(gameTime /60);
		timeSeconds = gameTime % 60;

		string timerTextString = timeMinutes.ToString("D1") + "\'" + timeSeconds.ToString("D2") + ("\"");

		timerTextValue.GetComponent<Text>().text =  timerTextString ;
         gameTime = gameTime - 1 ;
		}
		else
		{
			gameIsPaused = true;
			Time.timeScale = 0 ;
			Destroy(gameObject);
			Destroy(crossHairObj);
			gameOverPanel.GetComponent<CanvasGroup>().alpha = 1;
			gameOverPanel.GetComponent<CanvasGroup>().interactable = true;
			gameOverPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
			
            
		}

	}
	
	void shootAction ()
	{
		 gunShotAudioSourse.PlayOneShot(gunShotClip);
      roundShot = roundShot + 1;
	   
	   Vector2 dir = new Vector2 (crossHairObj.transform.position.x, crossHairObj.transform.position.y);
	   RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position,dir);
	    if (hit.collider != null && hit.collider != crossHairObj) 
		{
          enemyKilled ++ ;
		  Destroy (hit.collider.gameObject);
		  

		}
		scoreTextValue.GetComponent<Text>().text = enemyKilled.ToString()+" / " + roundShot.ToString();
		 
	 
	}
	// Update is called once per frame
	void Update () 
	{
		if ( ! gameIsPaused )
	  {
	   if (Input.GetKeyUp (KeyCode.Space))
		
		shootAction();

	    float h = Input.GetAxis("Mouse X")*5 ;
		float v = Input.GetAxis("Mouse Y")*5 ;
        Vector3 crossHairMov = new Vector3 (h,v,0);
		crossHairObj.transform.Translate(crossHairMov);
		float x = crossHairObj.transform.position.x;
		float y = crossHairObj.transform.position.y; 
		if (x > 47)
		x = 47;
		if (x < -47)
		x = -47;
		if (y > 22)
		y = 22;
		if (y < -22)
		y = -22;

      crossHairObj.transform.position = new Vector3 (x,y,51);
		 
	   }
	}
	public void RestartAction()
	{   
		Time.timeScale = 1 ;
		gameIsPaused = false;
		gameOverPanel.GetComponent<CanvasGroup>().alpha = 0;
		gameOverPanel.GetComponent<CanvasGroup>().interactable = false;
		gameOverPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
		gameTime = 60;
		enemyKilled = 0;
		roundShot = 0;
		scoreTextValue.GetComponent<Text>().text = enemyKilled.ToString()+" / " + roundShot.ToString();
		


	}
 }
