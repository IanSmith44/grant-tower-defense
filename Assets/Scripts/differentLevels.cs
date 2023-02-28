using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class differentLevels : MonoBehaviour
{
    [SerializeField] private GameObject level1;
    [SerializeField] private GameObject levels;

    public void Level1()
    {
        levels.SetActive(true);
        level1.SetActive(true);
    }
    public void Level1Play()
    {
        SceneManager.LoadScene(1);
    }
}
