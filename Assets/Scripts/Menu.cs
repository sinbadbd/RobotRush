using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject PauseObject;

    [SerializeField]
    GameObject OptionsWindow;

    [SerializeField]
    GameObject HelpWindow;

    [SerializeField]
    GameObject MenuUI;

    AudioManager audioManager;


    enum MenuStates { playing, Pause, Option, Help }
    MenuStates currentStates;

    private void Update()
    {


        if(Input.GetKeyDown("escape") && currentStates == MenuStates.Pause)
        {
            currentStates = MenuStates.playing;
        }else if(Input.GetKeyDown("escape") && currentStates == MenuStates.playing)
        {
            currentStates = MenuStates.Pause;
        }



        switch (currentStates)
        {
            case MenuStates.playing:
                currentStates = MenuStates.playing;
                PauseObject.SetActive(false);
                OptionsWindow.SetActive(false);
                HelpWindow.SetActive(false);
                MenuUI.SetActive(false);
                Time.timeScale = 1;
                break;

            case MenuStates.Pause:
                 PauseObject.SetActive(true);
                OptionsWindow.SetActive(false);
                HelpWindow.SetActive(false);
                MenuUI.SetActive(true);
                Time.timeScale = 0; 
                break;

            case MenuStates.Option:
                PauseObject.SetActive(false);
                OptionsWindow.SetActive(true);
                HelpWindow.SetActive(false);
                MenuUI.SetActive(true);
                Time.timeScale = 0;
                break;

            case MenuStates.Help:
                PauseObject.SetActive(false);
                OptionsWindow.SetActive(false);
                HelpWindow.SetActive(true);
                MenuUI.SetActive(true);
                Time.timeScale = 0;
                break;
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void DispalayOption()
    {
        currentStates = MenuStates.Option;
    }
    public void DisplaHelp()
    {

    }

   public void Resume()
    {

        currentStates = MenuStates.playing;
    }

    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public  void BackButton()
    {
        currentStates = MenuStates.Pause;
    }


    public void SetSFXVolume(float sfxlv)
    {
        audioManager.setSFXVolume(sfxlv);
    }
    public void SerMusicVolume(float musicV)
    {
        audioManager.setMusicVolume(musicV);
    }

    public void SerMasterVolume(float masterV)
    {
        audioManager.setMasterVolume(masterV);
    }
}
