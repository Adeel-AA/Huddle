using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
/*
* class in charge of changing the scenes and changing the level as well as quitting the game
*/
public class ChangeScene : MonoBehaviour {

	// Use this for initialization
    /*
    * empty constructor not needed to initiate only needs to run in a static manner
    */
	public ChangeScene (){
	}
	/*
	*changes the scene given the scene name aka the file name of the scene
	*/
	public void ChangeToScene (string sceneName) { 
		SceneManager.LoadScene(sceneName);
		Time.timeScale = 1;

	
	}
    /*
    * quits the game and closes the application window
    */
	public void QuitGame () {
		Application.Quit();

	}
    /*
    * reloads scene, used for the restart button if the player loses
    */
	public void ReloadScene(){
		ChangeToScene (SceneManager.GetActiveScene ().name);

	}
    /*
    * changes the scene to the level select scene
    */
	public void LevelSelect() {
		ChangeToScene ("LevelSelect");

	}
    /*
    * changes the scene to the main menu
    */
	public void MainMenu(){
		ChangeToScene ("MainMenu");

	}
    /*
    * changes the scene given the build number of the scene
    */
	public void ChangeSceneInt(int sceneNumber){
		SceneManager.LoadScene (sceneNumber);

	}
}
