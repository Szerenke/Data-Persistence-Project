using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputName;
    public TextMeshProUGUI menuScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (ScoreManager.Instance.playerName != null)
        {
            inputName.text = ScoreManager.Instance.playerName;
        }
        SetScoreText();
    }

    public void StartNew()
    {
        SetPlayerName();
        SceneManager.LoadScene(1);
    }

    void SetScoreText()
    {
        menuScoreText.text = $"Best Score : {ScoreManager.Instance.playerName} : {ScoreManager.Instance.score}";
    }

    void SetPlayerName()
    {
        ScoreManager.Instance.playerName = inputName.text;
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
