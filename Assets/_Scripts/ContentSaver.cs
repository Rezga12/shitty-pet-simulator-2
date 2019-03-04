using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ContentSaver {

	private static float dirtingOverTime = 0.01f;

	public static void saveWashState(Color col){
		PlayerPrefs.SetFloat ("r",col.r);
		PlayerPrefs.SetFloat ("g",col.g);
		PlayerPrefs.SetFloat ("b",col.b);

		PlayerPrefs.SetInt("Time",getCurrentTime());

	}

	public static Color getWashColor(){
		Color col = new Color ();
		int secondsPassed = getCurrentTime() - PlayerPrefs.GetInt("Time");
		col.r = Mathf.Max(PlayerPrefs.GetFloat ("r",1) - dirtingOverTime * secondsPassed,0);
		col.g = Mathf.Max(PlayerPrefs.GetFloat ("g",1) - dirtingOverTime * secondsPassed,0);
		col.b = Mathf.Max(PlayerPrefs.GetFloat ("b",1) - dirtingOverTime * secondsPassed,0);

		return col;
	}

	public static int getCurrentTime(){
		System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
		int cur_time = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;

		return cur_time;
	}
}
