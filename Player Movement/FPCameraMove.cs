using UnityEngine;

public class FPCameraMove : MonoBehaviour
{
    public float mouseSensitivity = 80f;
    public Transform player;

    private float rotationX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotar la cámara en el eje X (arriba/abajo)
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -70f, 70f);
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // Rotar el jugador en el eje Y para que siga la cámara
        player.Rotate(Vector3.up * mouseX);
    }
}