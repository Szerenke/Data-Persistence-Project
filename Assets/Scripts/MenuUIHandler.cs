using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    //private string m_playerName;
    //private string m_Score;
    public TextMeshProUGUI inputName;
    public TextMeshProUGUI menuScoreText;

    // Start is called before the first frame update
    void Start()
    {
        MainManager.Instance.LoadPlayerAndScore();
        SetScoreText();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(inputName.text);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadPlayerAndScoreClicked()
    {
        MainManager.Instance.LoadPlayerAndScore();
        //ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }

    void SetScoreText()
    {
        menuScoreText.text = $"Best score: {MainManager.Instance.NameText.text} : " +
            $"{MainManager.Instance.ScoreText.text}";
    }

    public void Exit()
    {
         #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }
}
