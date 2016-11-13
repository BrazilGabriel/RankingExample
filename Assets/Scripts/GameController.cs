using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text clickCounterText, timeRemainingText;
	public InputField playerName;

	int totalClicks = 0;
	int timeRemaining = 10;
	bool gameInPlay = true;

	void Start ()
	{
		StartCoroutine (OneSecond ());
	}
	
	IEnumerator OneSecond()
	{
		while (1==1)
		{
			yield return new WaitForSeconds (1.0f);
			timeRemaining--;
			timeRemainingText.text = "Time: " + timeRemaining;
			if (timeRemaining == 0)
			{
				EndGame();
				break;
			}
		}		
	}

	void EndGame()
	{
		gameInPlay = false;
	
	}

	public void InitialsEntered()
	{
		GetComponent<RankingController>().CheckForHighScore(totalClicks,playerName.text);
	}

	void Update() 
	{
		if (!gameInPlay) return;
		if(Input.GetKeyDown(KeyCode.Space))
		{
			totalClicks++;
			clickCounterText.text = "Clicks: " + totalClicks;
		}
	}
}
