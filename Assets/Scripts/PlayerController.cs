using System. Collections;
using System. Collections. Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour{


// Variables
private float horizontalInput; private float verticalInput;
[SerializeField]
private float speed = 10.0f;
// Update is called once per frame
void Update(){


// Set our Input Axis (Keyboard Arrows)
horizontalInput = Input. GetAxis ("Horizontal");
verticalInput = Input. GetAxis ("Vertical");
// Move when the user presses the arrow keys
transform. Translate(-Vector3.right * horizontalInput * Time.deltaTime * speed); 
transform. Translate(-Vector3. forward * verticalInput * Time.deltaTime * speed);
}
}