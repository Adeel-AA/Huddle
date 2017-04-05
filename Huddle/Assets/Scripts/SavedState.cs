using UnityEngine;
using System.Data;
using System.IO;
using System;
using System.Xml;

public class SavedState {
	private  DataTable table;
	private DataSet ds;
	private string savedRoute;






	public SavedState () {
		savedRoute = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments).Replace ("\\", "/");
		savedRoute += "/HuddleSave/";
		if (Directory.Exists (savedRoute)) {

		} else {
			createDir_File ();

		}
		table = new DataTable ();
		ds = new DataSet ();
		ds.Tables.Add (table);
		CreateTable ();

	}

	private void createDir_File() {

		Directory.CreateDirectory (savedRoute);



		File.Create (savedRoute+"save.xml");

	}
	private void CreateTable(){
		table.Columns.Add ("Name", typeof(string));
		table.Columns.Add ("Level", typeof(int));
		table.Columns.Add ("Score",typeof(int));

	}

	public void flushSave (string playerName,int level, int score) {
		try {ds.ReadXml (savedRoute+"save.xml");
			// clears table of any level duplicates 
			for (int i = 0; i < ds.Tables [0].Rows.Count; i++) {
				if (ds.Tables [0].Rows [i] ["Name"].ToString ().Equals (playerName) && ds.Tables [0].Rows [i] ["Level"].Equals (level)) {
					ds.Tables [0].Rows [i].Delete ();

				}

			}
		
		
		
		}
		catch (Exception e) {
			

		}

			

			table.Rows.Add (playerName, level, score);
			ds.Merge (table);


		ds.WriteXml (savedRoute+ "save.xml");

	}


	// need to implement this too tiered today lol
	public DataTable readSave () {
		DataSet data = new DataSet ();
		try {
		data.ReadXml (savedRoute+"save.xml");
		
	}

		catch (Exception e) {
			
		}

		return data.Tables [0];

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
