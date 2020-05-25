using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public void Play()
	{
		SceneManager.LoadScene("main");
	}

    public void car()
    {
        SceneManager.LoadScene("car");
    }
    public void sportcar()
    {
        SceneManager.LoadScene("sportcar");
    }
    public void bus()
    {
        SceneManager.LoadScene("bus");
    }
    public void Exit()
	{
		Application.Quit();
	}
}
