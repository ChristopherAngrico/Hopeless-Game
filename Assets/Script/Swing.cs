using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    private HingeJoint2D joint;
    private void Awake() {
        joint = GetComponent<HingeJoint2D>();
    }
    private void Start() {
        StartCoroutine(nameof(TriggerSwing));
    }
    IEnumerator TriggerSwing(){
        joint.useMotor = true;
        yield return new WaitForSeconds(0.1f);
        joint.useMotor = false;
    }
}
