using UnityEngine;

namespace Pexty
{    
    [CreateAssetMenu(fileName = "MovementInputData", menuName = "FirstPersonController/Data/MovementInputData", order = 1)]
    public class MovementInputData : ScriptableObject
    {
        #region Data
            Vector2 m_inputVector;

            bool m_isRunning;
            bool m_isCrouching;

            bool m_crouchClicked;
            bool m_jumpClicked;

            bool m_runClicked;
            bool m_runReleased;
        #endregion

        #region Properties
            public Vector2 inputVector => m_inputVector;
            public bool hasInput => m_inputVector != Vector2.zero;
            public float inputVectorX
            {
                set => m_inputVector.x = value;
            }

            public float inputVectorY
            {
                set => m_inputVector.y = value;
            }

            public bool isRunning
            {
                get => m_isRunning;
                set => m_isRunning = value;
            }

            public bool isCrouching
            {
                get => m_isCrouching;
                set => m_isCrouching = value;
            }

            public bool crouchClicked
            {
                get => m_crouchClicked;
                set => m_crouchClicked = value;
            }

            public bool jumpClicked
            {
                get => m_jumpClicked;
                set => m_jumpClicked = value;
            }

            public bool runClicked
            {
                get => m_runClicked;
                set => m_runClicked = value;
            }

            public bool runReleased
            {
                get => m_runReleased;
                set => m_runReleased = value;
            }
        #endregion

        #region Custom Methods
            public void ResetInput()
            {
                m_inputVector = Vector2.zero;
                
                m_isRunning = false;
                m_isCrouching = false;

                m_crouchClicked = false;
                m_jumpClicked = false;
                m_runClicked = false;
                m_runReleased = false;
            }
        #endregion
    }
}