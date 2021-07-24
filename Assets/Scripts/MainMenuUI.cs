using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuUI : MonoBehaviour
{
    public Text playerName;
    public void PressStart()
    {
        DataManager.Instance.CurrentName = playerName.text;
        SceneManager.LoadScene(1);
    }
}
