using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform _transform;
    private float horizontalInput;
    private bool keyPressed;
    
    public int verticalSpeed = 7;
    public int horizontalSpeed = 5;

    private float minValue = -1.58f;
    private float maxValue = 1.58f;

    private void Awake()
    {
        _transform = transform;
    }
    
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0 && keyPressed == false)
        {
            keyPressed = true;
        }
    }

    private void FixedUpdate()
    {
        _transform.position = new Vector3(Mathf.Clamp(transform.position.x + Time.deltaTime * horizontalInput * horizontalSpeed, 
            minValue, maxValue), transform.position.y, transform.position.z);
        
        if (!keyPressed) return;
        _transform.position += Vector3.forward * verticalSpeed * Time.fixedDeltaTime;
    }
}
