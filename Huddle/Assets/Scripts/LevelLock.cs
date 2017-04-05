using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.Data.Common;
using System;
public class LevelLock : MonoBehaviour {
	private DataTable completionHistory; // the data table from saved state read from the xml file
	private int latestLeveComplete;
	public static int lastestIndex;
	// Use this for initialization
	void Start () {
		completionHistory = new SavedState ().readSave ();

		LevelLock.lastestIndex = readLatestSave ();

	}
	/*
	 * reads the latest save index by accessing the database and sorting column level by max value 
	 * */
	private int readLatestSave () {
		int max = Convert.ToInt32(completionHistory.Compute ("max([Level])", string.Empty));
		return max;

	}

}
