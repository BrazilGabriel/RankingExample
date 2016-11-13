using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RankingController : MonoBehaviour
{

	public Text[] highScores;
	int[] highScoreValues;
	string[] highScoreNames;

	void Start () 
	{
		highScoreValues = new int[highScores.Length];
		highScoreNames = new string[highScores.Length];

		for (int x = 0; x < highScores.Length; x++)
		{
			highScoreValues[x] = PlayerPrefs.GetInt("highScoresValues" + x);
			highScoreNames[x] = PlayerPrefs.GetString("highScoresNames" + x);
		}

		DrawScores();
	}

	void SaveScores()
	{
		for (int x = 0; x < highScores.Length; x++)
		{
			PlayerPrefs.SetInt("highScoresValues" + x, highScoreValues[x]);
			PlayerPrefs.SetString("highScoresNames" + x, highScoreNames[x]);
		}
	}

	public void CheckForHighScore(int _value, string _userName)
	{
		for (int x = 0; x < highScores.Length; x++)
		{
			if(_value > highScoreValues[x])
			{
				for(int y = highScores.Length - 1; y>x; y--)
				{
					highScoreValues [y] = highScoreValues [y - 1];
					highScoreNames [y] = highScoreNames [y - 1];
				}
				highScoreValues [x] = _value;
				highScoreNames [x] = _userName;

				DrawScores();
				SaveScores();
				break;
			}
		}
	}

	void DrawScores()
	{
		for (int x = 0; x < highScores.Length; x++)
		{
			highScores[x].text = highScoreNames[x] + ": " + highScoreValues[x].ToString();
		}
	}

}
