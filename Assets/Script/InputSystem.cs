using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static InputSystem inputSystem;
    [HideInInspector]public float inputValue;
    private void Awake() {
        inputSystem = this;
    }
    public float Movement(){
        inputValue = Input.GetAxisRaw("Horizontal");
        return inputValue;
    }
}
