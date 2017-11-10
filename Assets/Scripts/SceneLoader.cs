using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	private bool loadScene = false;

	[SerializeField]
	public string scene;
	[SerializeField]
	private Text loadingText;
	string EscenaACargar;
	float progreso;
	AsyncOperation async;
	void Start()
	{

		EscenaACargar = NextScene.nextScene;
		scene = EscenaACargar;
		StartCoroutine(LoadNewScene());

	}

	// Updates once per frame
	void Update() {

		progreso = (async.progress * 100)+10;
			// ...change the instruction text to read "Loading..."
		loadingText.text = "Cargando..." + progreso.ToString("f0") + " %";


			// ...then pulse the transparency of the loading text to let the player know that the computer is still working.
		//	loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));


	}


	// The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
	IEnumerator LoadNewScene() {

		// This line waits for 3 seconds before executing the next line in the coroutine.
		// This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
//		yield return new WaitForSeconds(3);

		// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
		 async = SceneManager.LoadSceneAsync(scene);

		// While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
		while (!async.isDone) {
			yield return null;
		}

	}

}
