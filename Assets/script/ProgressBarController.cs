using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VHS;

public class ProgressBarController : MonoBehaviour
{
    [SerializeField] private FirstPersonController firstPersonController;
    [SerializeField] private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = firstPersonController.maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = firstPersonController.maxStamina;
        slider.value = firstPersonController.stamina;

        gameObject.SetActive(slider.value == slider.maxValue || slider.value == 0);
    }
}
