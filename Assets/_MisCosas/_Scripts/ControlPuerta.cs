using UnityEngine;

public class ControlPuerta : MonoBehaviour
{
    [Header("Ajustes")]
    public float anguloApertura = 90f;   // Grados que gira la puerta
    public float velocidad = 3f;         // Velocidad de giro

    private bool _abierta = false;
    private Quaternion _rotCerrada;
    private Quaternion _rotAbierta;

    private void Start()
    {
        // Guarda la orientación inicial cerrada
        _rotCerrada = transform.rotation;
        // Calcula la orientación abierta sumando el giro en Y
        _rotAbierta = _rotCerrada * Quaternion.Euler(0, anguloApertura, 0);
    }

    private void Update()
    {
        // Gira suavemente hacia la posición que toque
        Quaternion destino = _abierta ? _rotAbierta : _rotCerrada;
        transform.rotation = Quaternion.Slerp(transform.rotation, destino, Time.deltaTime * velocidad);
    }

    // Se abre cuando el jugador entra al área verde
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.GetComponent<CharacterController>() != null)
        {
            _abierta = true;
        }
    }

    // Se cierra cuando el jugador sale del área verde
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.GetComponent<CharacterController>() != null)
        {
            _abierta = false;
        }
    }
}