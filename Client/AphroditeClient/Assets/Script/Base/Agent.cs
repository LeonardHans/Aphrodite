using Aphrodite.Client.Manager;
using UnityEngine;

namespace Aphrodite.Client
{
	public class Agent : MonoObject
	{
		void Awake()
		{
			Debug.Log("Agent Loaded!");
			SceneManager.Instance.LoadScene();
		}
	}
}
