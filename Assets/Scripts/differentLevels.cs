using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class differentLevels : MonoBehaviour
{
    [SerializeField] private GameObject level1;
    [SerializeField] private GameObject level2;
    [SerializeField] private GameObject levels;

    public void Level1()
    {
        levels.SetActive(true);
        level1.SetActive(true);
    }
    public void Level2()
    {
        levels.SetActive(true);
        level2.SetActive(true);
    }
    public void Level1Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Level1RPlay()
    {
        SceneManager.LoadScene(2);
    }
    public void Level2Play()
    {
        SceneManager.LoadScene(3);
    }
    public void Level2RPlay()
    {
        SceneManager.LoadScene(4);
    }
}
