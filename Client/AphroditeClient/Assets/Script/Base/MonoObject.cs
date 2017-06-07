using UnityEngine;

namespace Aphrodite.Client
{
	public class MonoObject : MonoBehaviour
	{
		Transform cachedTransform;
		public new Transform transform
		{
			get
			{
				if (cachedTransform == null)
					cachedTransform = transform;
				return cachedTransform;
			}
		}
	}
}