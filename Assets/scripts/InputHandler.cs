using UnityEngine;
using NaughtyAttributes;

namespace Pexty
{    
    public class InputHandler : MonoBehaviour
    {
        #region Data
            [Space,Header("Input Data")]
            [SerializeField] private CameraInputData cameraInputData = null;
            [SerializeField] private MovementInputData movementInputData = null;
            [SerializeField] private InteractionInputData interactionInputData = null;
        #endregion

        #region BuiltIn Methods
            void Start()
            {
                cameraInputData.ResetInput();
                movementInputData.ResetInput();
                interactionInputData.ResetInput();
            }

            void Update()
            {
                GetCameraInput();
                GetMovementInputData();
                GetInteractionInputData();
            }
        #endregion

        #region Custom Methods
            void GetInteractionInputData()
            {
                interactionInputData.InteractedClicked = Input.GetKeyDown(KeyCode.E);
                interactionInputData.InteractedReleased = Input.GetKeyUp(KeyCode.E);
            }

            void GetCameraInput()
            {
                cameraInputData.InputVectorX = Input.GetAxis("Mouse X");
                cameraInputData.InputVectorY = Input.GetAxis("Mouse Y");

                cameraInputData.ZoomClicked = Input.GetMouseButtonDown(1);
                cameraInputData.ZoomReleased = Input.GetMouseButtonUp(1);
            }

            void GetMovementInputData()
            {
                movementInputData.inputVectorX = Input.GetAxisRaw("Horizontal");
                movementInputData.inputVectorY = Input.GetAxisRaw("Vertical");

                movementInputData.runClicked = Input.GetKeyDown(KeyCode.LeftShift);
                movementInputData.runReleased = Input.GetKeyUp(KeyCode.LeftShift);

                if(movementInputData.runClicked)
                    movementInputData.isRunning = true;

                if(movementInputData.runReleased)
                    movementInputData.isRunning = false;

                movementInputData.jumpClicked = Input.GetKeyDown(KeyCode.Space);
                movementInputData.crouchClicked = Input.GetKeyDown(KeyCode.LeftControl);
            }
        #endregion
    }
}