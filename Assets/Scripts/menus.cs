using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class menus : MonoBehaviour
{
    [SerializeField] private GameObject quitMenu;
    [SerializeField] private GameObject pauseMenu;
    public bool paused = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void esc(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            onPause();
        }
    }
    public void RetryNo()
    {
        SceneManager.LoadScene(0);
    }
    public void RetryYes()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void onPause()
    {
        paused = !paused;
        if (paused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void quitShowHide()
    {
        quitMenu.SetActive(!quitMenu.activeSelf);
    }
    public void quit()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
