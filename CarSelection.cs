using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CarSelection: MonoBehaviour
{
    [Header("Buttons and Canvas")]
    public Button nextButton;
    public Button previousButton;

    [Header("Canvas")]
    public GameObject cam1;
    public GameObject cam2;


    [Header("Buttons and Canvas")]
    public GameObject SelectionCanvas;
     public GameObject SkipButton;
    public GameObject PlayButton;

    private int currentCar;
    private GameObject[] carlist;

    private void Awake()
    {
        SelectionCanvas.SetActive(false);
        PlayButton.SetActive(false);
        cam2.SetActive(false);
        chooseCar(0);
    }
    private void Start()
    {

        currentCar = PlayerPrefs.GetInt("CarSelected");
        carlist = new GameObject[transform.childCount];

        for(int i=0;i<transform.childCount;i++)
        carlist[i] = transform.GetChild(i).gameObject;

        foreach(GameObject go in carlist)
        go.SetActive(false);

        if(carlist[currentCar])
         carlist[currentCar].SetActive(true);

    }

    private void chooseCar(int index)
    {
        previousButton.interactable = (currentCar !=0);
        nextButton.interactable = (currentCar != transform.childCount -1);
        
        for(int i = 0; i < transform.childCount; i++)
        {
        transform.GetChild(i).gameObject.SetActive(i == index);
        }
    }
    public void switchCar(int switchCars)
    {
    currentCar += switchCars;
    chooseCar (currentCar);
    }
    public void playGame()
    {
        PlayerPrefs.SetInt("CarSelected",currentCar);
        SceneManager.LoadScene("scene_day");
    }

    public void skipButton()
    {
        SelectionCanvas.SetActive(false);
        PlayButton.SetActive(true);
        SkipButton.SetActive(false);
        cam1.SetActive(false);
        cam2.SetActive(true);
    }
}

