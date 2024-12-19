using UnityEngine;

[CreateAssetMenu(fileName = "ShipStatus", menuName = "Scriptable Objects/ShipStatus")]
public class ShipStatus : ScriptableObject
{
    [Header("Physics")]
    public float speed = 1;
    public float maxSpeed = 20;
    public float breakSpeed = 30;
    public float rotationSpeed = 200;
    public float movement = 0;
    public float acceleration = 5;
    public float groundDistance = 0.5f;
    public LayerMask shipLayerCollider;
    public Vector3[] gravityField;

    [Header("Controller")]
    public bool controller = false;
    public bool isGrounded = false;
    public bool jumpFail = false;
}
