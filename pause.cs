using UnityEngine;

public class pause : MonoBehaviour
{
	bool isPaused = false;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			isPaused = !isPaused;
			if (isPaused)
			{
				Time.timeScale = 0;
			}
			else
			{
				Time.timeScale = 1;
			}
		}
	}

	void OnGUI()
	{
		if (isPaused)
		{
			GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Paused");
		}
	}
}
