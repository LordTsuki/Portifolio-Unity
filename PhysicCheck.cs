using UnityEngine;

public class PhysicCheck : MonoBehaviour
{
    public ShipStatus status;
    public RaycastHit2D topLeftCheck, topRightCheck, bottomLeftCheck, bottomRightCheck;

    void Start()
    {

    }

    void Update()
    {
        PhysicsCheck();
    }

    void PhysicsCheck()
    {
        // Definindo a direção dos raios para cima e para baixo
        Vector3 upDirection = -transform.right;
        Vector3 downDirection = transform.right;

        // Calculando as posições corretas para os pontos de origem dos raios
        Vector3 topLeftOrigin = transform.TransformPoint(status.gravityField[0]);
        Vector3 topRightOrigin = transform.TransformPoint(status.gravityField[1]);
        Vector3 bottomLeftOrigin = transform.TransformPoint(status.gravityField[2]);
        Vector3 bottomRightOrigin = transform.TransformPoint(status.gravityField[3]);

        // Raios para cima
        topLeftCheck = Raycast(topLeftOrigin, upDirection, status.groundDistance, status.shipLayerCollider);
        topRightCheck = Raycast(topRightOrigin, upDirection, status.groundDistance, status.shipLayerCollider);

        // Raios para baixo
        bottomLeftCheck = Raycast(bottomLeftOrigin, downDirection, status.groundDistance, status.shipLayerCollider);
        bottomRightCheck = Raycast(bottomRightOrigin, downDirection, status.groundDistance, status.shipLayerCollider);

        status.isGrounded = bottomLeftCheck || bottomRightCheck;

        if ((topLeftCheck || topRightCheck) && !status.jumpFail)
        {
            status.jumpFail = true;
        }
        else if (!topLeftCheck && !topRightCheck && status.jumpFail)
        {
            status.jumpFail = false;
        }
    }

    RaycastHit2D Raycast(Vector3 origin, Vector3 direction, float length, LayerMask mask)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, length, mask);

        Color color = hit ? Color.red : Color.green;
        Debug.DrawRay(origin, direction * length, color);

        return hit;
    }
}
