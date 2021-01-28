using UnityEngine;

public class Quitter : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Quitting");
            Application.Quit();
        }
    }

    public void QuitGame() {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
