using UnityEngine;

public class Hammer : MonoBehaviour
{
   private bool hammerIsUp = true;
   private float hammerDownAngle = 0;
    private float hammerUpAngle = 90;
    private Quaternion hammerDownRotation; // X Angle(0) when hammer is down private Quaternion hammerUpRotation; // X Angle(90) when Hammer is up
    private Quaternion hammerUpRotation; // X Angle(90) when Hammer is up
    private float hammerDownMaxTime = 0.25f; // Max time to swing hammer before moving back up

// Start is called before the first frame update
    void Start()
    {
    // Initialize hammer rotations
    hammerDownRotation = Quaternion.Euler(hammerDownAngle, transform.rotation.y, transform.rotation.z);
    hammerUpRotation = Quaternion.Euler(hammerUpAngle, transform.rotation.y, transform.rotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
        // If Hammer is Up, Call Swing Hammer with hammerRotationDown
            if (hammerIsUp) {
                SwingHammer (hammerUp: false, hammerRotation: hammerDownRotation);
            }
        // If Hammer is Down, Call Swing Hammer with hammerRotationUp
            else {
                SwingHammer (hammerUp: true, hammerRotation: hammerUpRotation);
            }
        }

        // Only have hammer down a max of 1/4 second
        if(!hammerIsUp){
        hammerDownMaxTime -= Time.deltaTime;
        if (hammerDownMaxTime <= 0f)
                SwingHammer(hammerUp: true, hammerRotation: hammerUpRotation);
        }

    }

    void SwingHammer(bool hammerUp, Quaternion hammerRotation)
    {
        // Set hammerIsUp to the opposite of the current state
        hammerIsUp = hammerUp;

        // Start the hammer swing animation
        transform.rotation = hammerRotation;

        // If hammer is down, wait for a short time before moving it back up
        if (hammerUp) {
            hammerDownMaxTime = 0.25f; // Reset the max time for the next swing
        }

    }

}
