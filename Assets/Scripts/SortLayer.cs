using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortLayer : MonoBehaviour
{
    public string sortLayerName;
    public GameObject[] Go;
  

    private void Start()
    {
        for (int i = 0; i < Go.Length; i++)
        {
            Go[i].GetComponent<Renderer>().sortingLayerName = sortLayerName;
        }
    }
}
