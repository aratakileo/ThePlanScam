using UnityEngine;

namespace Pexty
{
    public class AudioController : MonoBehaviour
    {
        #region Variables
            #region Data
                [Space, Header("Data")]
                [SerializeField] private FirstPersonController firstPersonController;
                [SerializeField] private AudioSource audioSource = null;
            #endregion

            #region Settings
                [Space, Header("Settings")]
                [SerializeField] private AudioClip[] stepSounds;
                [SerializeField] private float crouchingStepDuration = 0.7f;
                [SerializeField] private float walkingStepDuration = 0.4f;
                [SerializeField] private float runningStepDuration = 0.2f;
            #endregion

            #region Private
                private float stepTimer;
                private bool stepSkipped;
                private bool prevIsGrounded = true;
            #endregion
        #endregion

        #region BuilIn Methods
            // Start is called before the first frame update
            void Start()
            {
                stepTimer = walkingStepDuration;
            }

            // Update is called once per frame
            void Update()
            {
                float currentStepDuration = firstPersonController.isRunning ? runningStepDuration : (firstPersonController.isCrouching ? crouchingStepDuration : walkingStepDuration);
                
                if (stepTimer < currentStepDuration) stepTimer += Time.deltaTime;

                if (
                        (firstPersonController.isMoving || !prevIsGrounded) // triggered if the player moves, starts or finishes a jump, lands on the surface
                        &&
                        stepTimer >= currentStepDuration
                   ) 
                {
                    if(Random.Range(0f, 1f) >= 0.5f || stepSkipped || firstPersonController.isGrounded && !prevIsGrounded) { 
                        // can skip no more than 1 step in a row

                        audioSource.clip = stepSounds[Random.Range(0, stepSounds.Length)];
                        audioSource.Play();
                        stepSkipped = false;
                    }
                    else stepSkipped = true;

                    stepTimer = 0f;
                }

                prevIsGrounded = firstPersonController.isGrounded;
            }
        #endregion
    }
}
