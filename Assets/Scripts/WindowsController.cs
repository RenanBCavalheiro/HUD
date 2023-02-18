using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowsController : MonoBehaviour
{
    public GameObject statsWindow;
    
    // Start is called before the first frame update
    void Start()
    {
        statsWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (statsWindow.activeSelf == false)
            {
                statsWindow.SetActive(true);
            }

            else
            {
                statsWindow.SetActive(false);
            }
        }
    }
}
