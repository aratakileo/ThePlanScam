using System;
using UnityEngine;

namespace Pexty
{
    public class StaminaController : MonoBehaviour
    {
        #region Variables
            #region Data
                [Space, Header("Data")]
                [SerializeField] private FirstPersonController firstPersonController;
            #endregion

            #region Settings
                [Space, Header("Settings")]
                [SerializeField] private float m_maxValue = 7f;
                [SerializeField] private float cooldown = 1f;
        #endregion

            #region Private
                private float m_value;
                private float cooldownDuration = 0f;
                private bool isRestoring = false;
                private bool hasImpulse = true;
            #endregion
        #endregion

        #region BuilIn Methods
        // Start is called before the first frame update
        void Start()
            {
                m_value = m_maxValue;
            }

            // Update is called once per frame
            void Update()
            {
                m_value = Math.Min(m_maxValue, Math.Max(0, m_value)); // 0 <= m_value <= m_maxValue

                if (m_value > 0 && (firstPersonController.isRunning || hasImpulse)) m_value -= Time.deltaTime; // stamina decreasing
                if (m_value == 0) isRestoring = true;

                if (m_value == m_maxValue)
                {
                    isRestoring = false;
                    cooldownDuration = 0;
                }

                if (isRestoring)
                {
                    if (cooldownDuration < cooldown) cooldownDuration += Time.deltaTime;
                    else m_value += Time.deltaTime; // stamina increasing
                }

                if (m_value < m_maxValue && !firstPersonController.isRunning && !isRestoring && !hasImpulse) m_value += Time.deltaTime; // stamina increasing

                if (firstPersonController.isGrounded) hasImpulse = firstPersonController.isRunning;
            }
        #endregion

        #region Custom Methods
            public bool canRun => !isRestoring;

            public float value => m_value;
            public float maxValue
            {
                get => m_maxValue;
                set => m_maxValue = value;
            }
        #endregion
    }
}
