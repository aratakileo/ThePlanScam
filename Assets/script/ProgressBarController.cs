using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pexty
{
    public class ProgressBarController : MonoBehaviour
    {
        [SerializeField] private FirstPersonController firstPersonController;
        [SerializeField] private Slider slider;
        [SerializeField] private RectTransform rectTransform;

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

            // Show stamina progress by center
            float percent = slider.value / slider.maxValue;

            rectTransform.anchorMin = new Vector2(1f - (0.5f * percent + 0.5f), rectTransform.anchorMin.y);
            rectTransform.anchorMax = new Vector2(0.5f + 0.5f * percent, rectTransform.anchorMax.y);
        }
    }
}
