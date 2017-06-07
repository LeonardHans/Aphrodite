using System.Collections;
using Management = UnityEngine.SceneManagement;

namespace Aphrodite.Client
{
	public abstract class Scene : MonoObject
	{
		public Management.Scene Metadata { get; set; }
		protected abstract IEnumerator Initialize();
	}
}