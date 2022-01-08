using UnityEngine;

namespace Pexty
{
    public class StaminaController : MonoBehaviour
    {
        #region Variables
            #region Data
                [Space, Header("Data")]
                [SerializeField] private MovementInputData movementInputData = null;
            #endregion

            #region Seetings
                [Space, Header("Settings")]
                [SerializeField] private float m_maxValue = 5f;
                [SerializeField] private float cooldown = 1f;
        #endregion

            #region Private
                private float m_value;
                private float cooldownDuration = 0f;
                private bool isRestoring = false;
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
                if (m_value > m_maxValue) m_value = m_maxValue;
                if (m_value < 0) m_value = 0;
                if (m_value > 0 && isRunning && !isRestoring) m_value -= Time.deltaTime;
                if (m_value == 0) isRestoring = true;

                if (m_value == m_maxValue)
                {
                    isRestoring = false;
                    cooldownDuration = 0;
                }

                if (isRestoring)
                {
                    if (cooldownDuration < cooldown) cooldownDuration += Time.deltaTime;
                    else m_value += Time.deltaTime;
                }

                if (m_value < m_maxValue && !isRunning && !isRestoring) m_value += Time.deltaTime;
            }
        #endregion

        #region Custom Methods
            private bool isRunning => movementInputData.IsRunning && !movementInputData.IsCrouching && movementInputData.InputVector.y > 0f;
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
