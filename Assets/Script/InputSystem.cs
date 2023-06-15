using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static InputSystem inputSystem;
    private void Awake() {
        //Assigned inputSystem to this script
        inputSystem = this;
    }
    public float Movement(){
        float inputValue = Input.GetAxis("Horizontal");
        return inputValue;
    }

    //Will trigger if press button key
    public bool JumpPress(){
        bool inputValue = Input.GetButtonDown("Jump");
        return inputValue;
    }

    //Will trigger if release button key
    public bool JumpUp(){
        bool inputValue = Input.GetButtonUp("Jump");
        return inputValue;
    }
}
