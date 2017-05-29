
using System.Collections;
using UnityEngine;
using Management = UnityEngine.SceneManagement;

namespace Aphrodite.Client.Manager
{
	public abstract class Scene : MonoObject
	{
		public abstract Management.Scene Metadata { get; set; }
		protected abstract IEnumerator Initialize();
	}

	public class SceneManager : Singleton<SceneManager>
	{
		const string AgentName = "Agent";
		const string EmptySceneAgent = "EmptySceneAgent";

		Scene currentScene;
		public Scene CurrentScene
		{
			get { return currentScene; }
		}

		public void ChangeScene<T>() where T : Scene
		{

		}

		IEnumerator ProcessChangeScene()
		{
			yield return Management.SceneManager.LoadSceneAsync(EmptySceneAgent);
			yield return StartCoroutine(ProcessClearScene());
			yield return Management.SceneManager.LoadSceneAsync(AgentName);
		}

		IEnumerator ProcessClearScene()
		{
			if (currentScene != null)
			{
				AsyncOperation op = Management.SceneManager.UnloadSceneAsync(currentScene.Metadata.name);
				yield return op;
			}
		}
	}
}
