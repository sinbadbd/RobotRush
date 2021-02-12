using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    Animator anim;

    [SerializeField]
    GameObject DoorType;

    int stateOfDoor = 1;

    void Start()
    {
        anim = GetComponent<Animator>();

        if(DoorType.name == "EntryDoor")
        {
            // OpenDoor();
            anim.SetFloat("DoorStates", 3);
        }

        if(DoorType.name == "ExitDoor")
        {
            LockDoor();
        }
    }

  

    void LockDoor()
    {
        //if(Do)
        if(DoorType.name == "ExitDoor")
        {
            anim.SetFloat("DoorStates", 1);
            stateOfDoor = 1;
        }
    }

    void UnLockDoor()
    {
        if (DoorType.name == "ExitDoor")
        {
            anim.SetFloat("DoorStates", 2);
            stateOfDoor = 2;
        }

    }


   public void OpenDoor()
    {
        if (DoorType.name == "ExitDoor")
        {
            anim.SetFloat("DoorStates", 3);
            stateOfDoor = 3;
        }
    }


    public void setDoorState(int state)
    {
        if (state == 1 && DoorType.name == "ExitDoor")
            LockDoor();
        if (state == 2 && DoorType.name == "ExitDoor")
            UnLockDoor();
        if (state == 3 && DoorType.name == "ExitDoor")
            OpenDoor();
    }


    public int GetDoorState()
    {
        return stateOfDoor;

    }

}
