using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextScene : MonoBehaviour
{
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			int nextScene = SceneManager.GetActiveScene ().buildIndex + 1;
			if (nextScene >= SceneManager.sceneCountInBuildSettings)
				nextScene = 0;
			SceneManager.LoadScene (nextScene);
		}
	}
}
