using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ExitArea : MonoBehaviour
{
    public GameObject exit;
    public static int totalGens;

    public Text exitText;
    
    void Start()
    {
        //exit.SetActive(false);
        totalGens = 0;
    }

    
    void Update()
    {
        if(totalGens <=4)
        {
            OpenExit();
        }
        if (totalGens >= 3)
        {
            exit.SetActive(false);
        }
        
    }
    private void OpenExit()
    {
        exit.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //escaped
        }

        if (other.tag == "Enemy")
        {
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            
        }
    }
}
