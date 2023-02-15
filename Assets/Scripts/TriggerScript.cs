using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerScript : MonoBehaviour
{
    public static int amount;
    public static float progress;
    public static bool activated;
    public static bool killerEntered;

    public Text progressText;

    public GameObject pod;


    void Start()
    {
        pod.GetComponent<Renderer>().material.color = Color.red;
    }

    
    void Update()
    {
        if (progress <=0)
        {
            progress = 0;
        }
        if (!activated)
        {
            progress -= 1 * Time.deltaTime;
        }
        if (activated)
        {
            progress += amount * Time.deltaTime;
        }

        if (progress >= 50)
        {
            pod.GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (progress >= 100)
        {
            pod.SetActive(false);
        }
        

        progressText.text = "Progress = " + Mathf.Round(progress);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            amount++;
            pod.GetComponent<Renderer>().material.color = Color.green;
            activated = true;
            killerEntered = false;
        }

        if (other.tag == "Enemy" && !killerEntered)
        {
            progress = progress / 2;
            killerEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            amount--;
            pod.GetComponent<Renderer>().material.color = Color.red;
            if (amount <= 0)
            {
                activated = false;
            }
        }
    }
}
