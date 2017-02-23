using System;
public class Player
	{
		private string name;
		private int currentScore;

		public Player (string name)
		{
			this.name = name;
			currentScore = 0;
		}

		public void setScore (int score) {
			currentScore = score;
		}

		public int getCurrentScore() {
			return currentScore;
		}

		public string getName() {
			return name;
		}

}

