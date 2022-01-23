using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class StartMenuUI_Handler : MonoBehaviour
{
    public TextMeshProUGUI errorBox;
    public TMP_InputField pNameInput;

    public void StartGame()
    {
        if (string.IsNullOrWhiteSpace(pNameInput.text))
        {
            errorBox.text = "ERROR: Type your Name!";
            errorBox.gameObject.SetActive(true);
        }
        else
        {
            GameManager.Instance.p_name = pNameInput.text;
            SceneManager.LoadScene(1);
        }

    }
}
