using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference flyUpActionReference;
    [SerializeField] private InputActionReference flyDownActionReference;
    [SerializeField] private float jumpForce = 500.0f;

    private Rigidbody body;
    private bool IsGrounded => Physics.Raycast(new Vector2(transform.position.x, transform.position.y + 2.0f), Vector3.down, 2.0f);
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        flyUpActionReference.action.performed += OnFlyUp;
        flyDownActionReference.action.performed += OnFlyDown;
    }
    private void OnFlyUp(InputAction.CallbackContext obj)
    {
        // if (!IsGrounded) return;
        body.AddForce(Vector3.up * jumpForce);
    }
    private void OnFlyDown(InputAction.CallbackContext obj)
    {
        // if (!IsGrounded) return;
        body.AddForce(Vector3.down * jumpForce);
    }
}
