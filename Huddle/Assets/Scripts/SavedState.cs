using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System;

public class SavedState : MonoBehaviour {
	private static int LevelsCompleted{ get; set;}
	public static string CurrentScore { get; set;}
	public static string saveFile = Application.dataPath + "/SaveFiles/";
	public static Dictionary <string,int> playerLog;


	public static void FlushDataToSave(String LevelName){
		

		File.WriteAllText ((saveFile + LevelName + ".txt"), CurrentScore);
			

			

		


	}


	public static void levelsCount(){
		int fileCount = Directory.GetFiles (saveFile, "*.txt", SearchOption.TopDirectoryOnly).Length;
		LevelsCompleted = fileCount;

	}

	public static void readSave() {
		playerLog = new Dictionary <string,int> ();
		levelsCount ();
		string amountOfLevels = "" + LevelsCompleted;
		File.WriteAllText (Application.dataPath+"/DebugSave/levels.txt", amountOfLevels+" levels are there and counted"); // debug to see if it's actually counting levels
		string[] levelNamescurrent = Directory.GetFiles (saveFile,"*.txt", SearchOption.TopDirectoryOnly);
		File.WriteAllText (Application.dataPath+"/DebugSave/arrayLevelNames.txt", levelNamescurrent.Length+" levels are there and counted");
		if (levelNamescurrent != null) {
			for (int i = 0; i < levelNamescurrent.Length; i++) {
				using (StreamReader stream = new StreamReader (levelNamescurrent [i])) {
					String line = stream.ReadLine ();
					int score = int.Parse (line);
					playerLog.Add ("Level "+(i+1), score);

				}

			}
		}

	}

	public int findSaveScore(string levelName){
		return 0;

	}





}
