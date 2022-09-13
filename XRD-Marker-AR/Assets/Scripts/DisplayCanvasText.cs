using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class DisplayCanvasText : MonoBehaviour
{
    [Header("Planet Information")]
    [SerializeField] private String planetName;
    [SerializeField] private String planetSizeRadius;
    [SerializeField] private String averageTemperature;
    [SerializeField] private String distanceToSun;

    [Header("Text objects")]
    [SerializeField] private GameObject nameObject;
    [SerializeField] private GameObject sizeObject;
    [SerializeField] private GameObject temperatureObject;
    [SerializeField] private GameObject distanceObject;

    // Start is called before the first frame update
    void Start()
    {
        nameObject.GetComponent<TMP_Text>().SetText("Planet name: " + planetName);
        sizeObject.GetComponent<TMP_Text>().SetText("Planet size radius: " + planetSizeRadius);
        temperatureObject.GetComponent<TMP_Text>().SetText("Average temperature: " + averageTemperature);
        if (!String.IsNullOrEmpty(distanceToSun))
        {
            distanceObject.GetComponent<TMP_Text>().SetText("Distance to Sun: " + distanceToSun);
        }
        else distanceObject.SetActive(false);
    }
}
