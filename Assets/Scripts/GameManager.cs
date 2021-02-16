using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    [SerializeField]
    GameObject[] switchs;

    [SerializeField]
    GameObject exitDoors;


    int noOfSwitchCount = 0;


    [SerializeField]
    Text switchCount;

    public static GameManager instance;
   
    void Start()
    {

        GetNoOfSwitch();

    }

     void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public int getCurrentLevel()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextLavel(int x)
    {
        SceneManager.LoadScene(x);
    }


    public void LoadLastSave(int x)
    {
        SceneManager.LoadScene(x);
    }




    public int GetNoOfSwitch()
    {
        int x = 0;
        for (int i = 0; i < switchs.Length; i++)
        {
            if (switchs[i].GetComponent<Switch>().isOn == false)
                x++;
            else if (switchs[i].GetComponent<Switch>().isOn == true)
                noOfSwitchCount--;
        }

        noOfSwitchCount = x;

        return noOfSwitchCount;
    }


     void GetExitDoorState()
    {
        if (noOfSwitchCount <= 0)
        {
            exitDoors.GetComponent<Door>().OpenDoor();
        }
    }


    private void Update()
    {
        switchCount.text = GetNoOfSwitch().ToString();
        GetExitDoorState();
    }




}
