using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject level1;
    [SerializeField] private GameObject level2;
    [SerializeField] private GameObject levels;
    [SerializeField] private GameObject levelMenu;

    public void Play()
    {
        levelMenu.SetActive(true);
    }
    public void LevelSelectBack()
    {
        levelMenu.SetActive(false);
    }
    public void Level1Back()
    {
        level1.SetActive(false);
        levels.SetActive(false);
    }
    public void Level2Back()
    {
        level2.SetActive(false);
        levels.SetActive(false);
    }
}
