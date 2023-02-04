using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quit_onpress : MonoBehaviour
{
    public Button m_StartGameButton, m_QuitButton;

    // Start is called before the first frame update
    void Start()
    {
        m_StartGameButton.onClick.AddListener(StartGame);
        m_QuitButton.onClick.AddListener(StopGame);
        
    }

    void StartGame()
    {
        Debug.Log("Start game");
        SceneManager.LoadScene("Level1");
    }

    void StopGame()
    {
        Debug.Log("Quiting the game");
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
