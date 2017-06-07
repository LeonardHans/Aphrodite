
using System;
using System.Collections;
using UnityEngine;
using Management = UnityEngine.SceneManagement;

namespace Aphrodite.Client.Manager
{
	public class SceneManager : Singleton<SceneManager>
	{
		const string MainAgent = "Test";
		const string EmptyAgent = "EmptyAgent";

		Scene currentScene;
		public Scene CurrentScene
		{
			get { return currentScene; }
		}
		Type currentSceneType = typeof(LoadingScene);

		public void ChangeScene<T>() where T : Scene
		{
			StartCoroutine(ProcessChangeScene());
		}

		public void LoadScene()
		{
			string[] token = currentSceneType.ToString().Split('.');
			string sceneName = token[token.Length - 1];

			Debug.Log(sceneName);
			Management.Scene meta = Management.SceneManager.CreateScene(sceneName);
			Transform sceneTransform = AssetAssistant.FindTransform(sceneName);
			
			if (sceneTransform == null)
			{
				Management.SceneManager.SetActiveScene(meta);
				sceneTransform = AssetAssistant.CreateGameObject(sceneName).transform;
				currentScene = sceneTransform.gameObject.AddComponent(currentSceneType) as Scene;
				currentScene.Metadata = meta;
			}
		}

		IEnumerator ProcessChangeScene()
		{
			yield return Management.SceneManager.LoadSceneAsync(EmptyAgent);
			yield return StartCoroutine(ProcessClearScene());
			yield return Management.SceneManager.LoadSceneAsync(MainAgent);
		}

		IEnumerator ProcessClearScene()
		{
			if (currentScene != null)
			{
				AsyncOperation op = Management.SceneManager.UnloadSceneAsync(currentScene.Metadata.name);
				yield return op;
			}

			AssetAssistant.DestroyAll();
			GC.Collect();
		}
	}
}
