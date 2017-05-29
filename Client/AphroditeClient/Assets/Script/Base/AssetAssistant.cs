using UnityEngine;

public static class AssetAssistant
{
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

	public static void RegisterDontDestroy(GameObject obj)
	{
		GameObject.DontDestroyOnLoad(obj);
	}
}
