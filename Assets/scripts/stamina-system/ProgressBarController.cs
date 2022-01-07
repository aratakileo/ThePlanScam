using UnityEngine;
using UnityEngine.UI;
using Pexty.Utils;

namespace Pexty
{
    public class ProgressBarController : MonoBehaviour
    {
        [Space, Header("Data")]
        [SerializeField] private StaminaController staminaController;
        [SerializeField] private Slider slider;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Image progressImage;

        private static int DEFAULT_COLOR = 0x07C855;
        private static int MIDDLE_COLOR = 0xEA9727;
        private static int DANGER_COLOR = 0xD21711;

        // Start is called before the first frame update
        void Start()
        {
            slider.maxValue = staminaController.maxValue;
        }

        // Update is called once per frame
        void Update()
        {
            slider.maxValue = staminaController.maxValue;
            slider.value = staminaController.value;

            // Show stamina progress by center
            float percent = slider.value / slider.maxValue;

            if (percent > 0.65f) progressImage.color = ColorUtil.fromRgb(DEFAULT_COLOR);
            if (percent <= 0.65f) progressImage.color = ColorUtil.fromRgb(MIDDLE_COLOR);
            if (percent <= 0.15f) progressImage.color = ColorUtil.fromRgb(DANGER_COLOR);

            rectTransform.anchorMin = new Vector2(1f - (0.5f * percent + 0.5f), rectTransform.anchorMin.y);
            rectTransform.anchorMax = new Vector2(0.5f + 0.5f * percent, rectTransform.anchorMax.y);
        }
    }
}
