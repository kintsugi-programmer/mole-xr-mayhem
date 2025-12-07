using System. Collections;
using System. Collections.Generic;
using UnityEngine;
public class Mole : MonoBehaviour {
// Show & Hide Variables
public float visibleYHeight = 2.0f;
public float hiddenYHeight = -1.6f;
private Vector3 myNewXYZPosition;
public float speed = 4f;
public float hideMoleTimer = 1.5f;
// Mole is Created
    void Awake ()
    {
// Get the Current X, & Z
    HideMole();
// set our current position
    transform. localPosition = myNewXYZPosition;
// value of Y when Mole is shown
// value of Y when Mole is hidden
// position to move current Mole
// speed the mole Moves
// timer to hide the mole after it shows
    }
// Use this for initialization
    void Start () {
    }
// Update is called once per frame
void Update () 
    {
        // Move mole to new X,Y,z Position
        transform. localPosition = Vector3. Lerp(
        transform. localPosition, myNewXYZPosition,
        Time.deltaTime * speed
        ) ;
hideMoleTimer -= Time.deltaTime;
if (hideMoleTimer <= 0f){
    HideMole();
}
}

public void HideMole() {
    myNewXYZPosition = new Vector3(
        transform. localPosition. x,
        hiddenYHeight,
        transform. localPosition. z
    );
    // reset hide mole timer
    
}

public void ShowMole() {
    myNewXYZPosition = new Vector3(
        transform. localPosition. x,
        visibleYHeight,
        transform. localPosition. z
    );
    hideMoleTimer = 1.5f;
}
}