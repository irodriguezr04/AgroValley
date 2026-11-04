using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class MovimientoRapido : MonoBehaviour
{
    public float velocidad = 12f;
    public float sensibilidadRaton = 0.001f;
    public float gravedad = -20f;

    private CharacterController controller;
    private Transform camara;
    private float rotacionX = 0f;
    private Vector3 velocidadVertical;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        camara = GetComponentInChildren<Camera>().transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 1. Ratón (Mirar alrededor con sensibilidad suave)
        if (Mouse.current != null)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();
            float mouseX = mouseDelta.x * sensibilidadRaton;
            float mouseY = mouseDelta.y * sensibilidadRaton;

            rotacionX -= mouseY;
            rotacionX = Mathf.Clamp(rotacionX, -80f, 80f);

            camara.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }

        // 2. Teclado (WASD / Flechas)
        float x = 0f;
        float z = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) z += 1f;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) z -= 1f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) x += 1f;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) x -= 1f;

            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }

        Vector3 move = (transform.right * x + transform.forward * z).normalized;
        controller.Move(move * velocidad * Time.deltaTime);

        // 3. Gravedad
        if (controller.isGrounded && velocidadVertical.y < 0)
        {
            velocidadVertical.y = -2f;
        }

        velocidadVertical.y += gravedad * Time.deltaTime;
        controller.Move(velocidadVertical * Time.deltaTime);
    }
}