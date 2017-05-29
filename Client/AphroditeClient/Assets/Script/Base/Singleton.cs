using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
	public static string Name
	{
		get { return typeof(T).ToString(); }
	}

	static T instance;
	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = AssetAssistant.CreateComponent<T>(Name);
				AssetAssistant.RegisterDontDestroy(instance.gameObject);
			}
			return instance;
		}
	}
}
