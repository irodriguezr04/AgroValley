using UnityEngine;
using StarterAssets; // Namespace de Starter Assets

public class WaterDetection : MonoBehaviour
{
    private Animator _animator;
    private ThirdPersonController _controller;
    private static readonly int IsSwimmingParam = Animator.StringToHash("isSwimming");

    [Header("Ajustes de Agua")]
    public float swimSpeed = 2.5f;          // Velocidad al nadar
    public float waterSurfaceY = 0f;        // Nivel de la superficie del agua

    private float _originalMoveSpeed;
    private float _originalSprintSpeed;
    private float _originalGravity;
    private bool _isSwimming = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        if (_animator == null) _animator = GetComponentInChildren<Animator>();
        _controller = GetComponent<ThirdPersonController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water") || other.gameObject.name.ToLower().Contains("water"))
        {
            if (!_isSwimming)
            {
                EnterWater(other);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water") || other.gameObject.name.ToLower().Contains("water"))
        {
            if (_isSwimming)
            {
                ExitWater();
            }
        }
    }

    private void EnterWater(Collider waterCol)
    {
        _isSwimming = true;
        if (_animator != null) _animator.SetBool(IsSwimmingParam, true);

        // Obtener el límite superior del Box Collider del agua
        waterSurfaceY = waterCol.bounds.max.y;

        if (_controller != null)
        {
            // Guardar valores originales
            _originalMoveSpeed = _controller.MoveSpeed;
            _originalSprintSpeed = _controller.SprintSpeed;
            _originalGravity = _controller.Gravity;

            // Ajustar velocidad de nado y anular gravedad
            _controller.MoveSpeed = swimSpeed;
            _controller.SprintSpeed = swimSpeed;
            _controller.Gravity = 0f;
        }
    }

    private void ExitWater()
    {
        _isSwimming = false;
        if (_animator != null) _animator.SetBool(IsSwimmingParam, false);

        if (_controller != null)
        {
            // Restaurar movimiento y gravedad originales de tierra
            _controller.MoveSpeed = _originalMoveSpeed;
            _controller.SprintSpeed = _originalSprintSpeed;
            _controller.Gravity = _originalGravity;
        }
    }

    private void Update()
    {
        if (_isSwimming)
        {
            float targetY = waterSurfaceY - 0.57f;

            if (transform.position.y < targetY)
            {
                CharacterController cc = GetComponent<CharacterController>();
                if (cc != null) cc.enabled = false;

                Vector3 pos = transform.position;
                pos.y = Mathf.MoveTowards(pos.y, targetY, Time.deltaTime * 5f);
                transform.position = pos;

                if (cc != null) cc.enabled = true;
            }
        }
    }
}