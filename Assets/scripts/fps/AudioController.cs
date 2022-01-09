using UnityEngine;

namespace Pexty
{
    public class AudioController : MonoBehaviour
    {
        #region Variables
            #region Data
                [Space, Header("Data")]
                [SerializeField] private MovementInputData movementInputData = null;
                [SerializeField] private AudioSource audioSource = null;
            #endregion

            #region Settings
                [Space, Header("Settings")]
                [SerializeField] private AudioClip[] stepSounds;
                [SerializeField] private float walkingStepDuration = 0.4f;
                [SerializeField] private float runningStepDuration = 0.2f;
        #endregion

            #region Private
                private float stepTimer;
                private bool stepSkipped;
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
                float currentStepDuration = movementInputData.IsRunning ? runningStepDuration : walkingStepDuration;

                if (stepTimer < currentStepDuration) stepTimer += Time.deltaTime;

                if (!audioSource.isPlaying && movementInputData.IsGrounded && movementInputData.HasInput && stepTimer >= currentStepDuration)
                {
                    audioSource.clip = stepSounds[Random.Range(0, stepSounds.Length)];

                    if(Random.Range(0f, 1f) >= 0.5f || stepSkipped) {
                        audioSource.Play();
                        stepSkipped = false;
                    }
                    else stepSkipped = true;

                    stepTimer = 0f;
                }
                else audioSource.Stop();
        }
        #endregion

        #region Custom Methods
            
        #endregion
    }
}
