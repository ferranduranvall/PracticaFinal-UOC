using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.Vehicles.Car;

public class InCar : MonoBehaviour
{
    public GameObject thirdPersonPlayer;
    public GameObject carPlayer;
    public GameObject cameraThirdPerson;

    public GameObject spotPlayerCar;

    public CarUserControl carUserControl;
    public ThirdPersonUserControl thirdPersonUserControl;

    // Start is called before the first frame update
    void Awake()
    {
        carUserControl.GetComponent<CarUserControl>();
        carUserControl.enabled = false;
        spotPlayerCar.SetActive(false);
    }

    //Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("OutCar"))
        {
            carUserControl.enabled = false;
            thirdPersonPlayer.SetActive(true);
            cameraThirdPerson.SetActive(true);
            thirdPersonUserControl.enabled = true;
            thirdPersonPlayer.transform.position = carPlayer.transform.position;
            spotPlayerCar.SetActive(false);
        }

        if (Input.GetButtonDown("InCar"))
        {
            thirdPersonPlayer.transform.position = carPlayer.transform.position;
            thirdPersonPlayer.SetActive(false);
            cameraThirdPerson.SetActive(false);
            thirdPersonUserControl.enabled = false;
            carUserControl.enabled = true;
            spotPlayerCar.SetActive(true);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Player3rd")
    //    {
    //        thirdPersonPlayer.transform.position = carPlayer.transform.position;
    //        thirdPersonPlayer.SetActive(false);
    //        thirdPersonUserControl.enabled = false;
    //        carUserControl.enabled = true;

    //    }
    //}

}
