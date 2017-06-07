using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aphrodite.Client
{
	public static class AssetAssistant
	{
		static Queue<Transform> findingQueue = new Queue<Transform>();

		public static GameObject CreateGameObject(string name, Transform parent = null)
		{
			GameObject obj = new GameObject(name);

			if (parent != null)
			{
				obj.transform.SetParent(parent, false);
			}

			return obj;
		}

		public static T CreateComponent<T>(string name, Transform parent = null) where T : Component
		{
			return AddComponent<T>(CreateGameObject(name, parent));
		}

		public static Transform FindTransform(string targetName, Transform parent = null)
		{
			if (parent == null)
			{
				GameObject gameObject = GameObject.Find(targetName);
				return gameObject == null ? null : gameObject.transform;
			}

			findingQueue.Enqueue(parent);
			while (findingQueue.Count > 0)
			{
				Transform top = findingQueue.Peek();
				for (int i = 0; i < top.childCount; ++i)
				{
					if (top.GetChild(i).name.Equals(targetName))
					{
						findingQueue.Clear();
						return top;
					}
				}
				findingQueue.Dequeue();
			}

			return null;
		}

		public static T AddComponent<T>(GameObject target) where T : Component
		{
			if (target == null)
				return null;
			return target.AddComponent<T>();
		}

		public static void Destroy(GameObject obj)
		{
			GameObject.Destroy(obj);
		}

		public static void DestroyAll()
		{
			Resources.UnloadUnusedAssets();
		}

		public static void RegisterDontDestroy(GameObject obj)
		{
			GameObject.DontDestroyOnLoad(obj);
		}
	}

}
