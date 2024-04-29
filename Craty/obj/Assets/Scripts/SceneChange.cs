using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string levelName;
    public void LevelChange(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
