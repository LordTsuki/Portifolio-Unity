using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private Rigidbody2D rig;
    public ShipStatus status;
    private float x, y, z;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        status.speed = 0;
        if (status == null)
        {
            Debug.LogError("ShipStatus scriptable object is not assigned in the inspector.");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (status != null)
        {
            Move();
            Rotate();
        }
    }

    void Move()
    {
        if (status.isGrounded)
        {
            float targetSpeed = 0;

            if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
            {
                if (status.speed < 0)
                {
                    status.movement = 1;
                    targetSpeed = status.breakSpeed;
                }
                else
                {
                    targetSpeed = status.maxSpeed;
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
            {
                if (status.speed > 0)
                {
                    status.movement = -1;
                    targetSpeed = -status.breakSpeed;
                }
                else
                {
                    targetSpeed = -status.maxSpeed;
                }
            }
            else
            {
                status.movement = 0;
                targetSpeed = 0;
            }

            status.speed = Mathf.MoveTowards(status.speed, targetSpeed, status.acceleration * Time.deltaTime);

            float limitedSpeed = Mathf.Clamp(status.speed, -status.maxSpeed, status.maxSpeed);
            rig.linearVelocity = new Vector2(limitedSpeed, rig.linearVelocityY);
        }
    }

    void Rotate()
    {
        if (!status.isGrounded)
        {
            float rotation = 0;

            if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
            {
                rotation = -status.rotationSpeed;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                rotation = status.rotationSpeed;
            }

            transform.Rotate(0, 0, rotation * Time.deltaTime);
        }
    }
}
