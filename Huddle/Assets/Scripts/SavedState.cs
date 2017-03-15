using UnityEngine;
using System.Data;
using System.IO;
using System;

public class SavedState {
	private  DataTable table;
	private DataSet ds;
	private static string savefile = Application.dataPath + "/SaveFiles/save.xml";






	public SavedState () {
		table = new DataTable ();
		ds = new DataSet ();
		ds.Tables.Add (table);
		CreateTable ();

	}
	private void CreateTable(){
		table.Columns.Add ("Name", typeof(string));
		table.Columns.Add ("Level", typeof(int));
		table.Columns.Add ("Score",typeof(int));

	}

	public void flushSave (string playerName,int level, int score) {
		try {ds.ReadXml (savefile);
			// clears table of any level duplicates 
			for (int i = 0; i < ds.Tables [0].Rows.Count; i++) {
				if (ds.Tables [0].Rows [i] ["Name"].ToString ().Equals (playerName) && ds.Tables [0].Rows [i] ["Level"].Equals(level)) {
					ds.Tables [0].Rows [i].Delete ();

				}
		
		}
		}
		catch (Exception e) {

		}

			table.Rows.Add (playerName, level, score);
			ds.Merge (table);


		ds.WriteXml (Application.dataPath + "/SaveFiles/save.xml");

	}

	// need to implement this too tiered today lol
	public void readSave () {
		try { ds.ReadXml (Application.dataPath +savefile); }
		catch (Exception e) {}



	}


	public int getLevelAmount (string player_Name){
		int counter = 0;
		foreach (DataRow row in table.Rows) {
			if (row["Name"].Equals(player_Name)) {
				counter ++;

			}
		}
		return counter;
	}





}
