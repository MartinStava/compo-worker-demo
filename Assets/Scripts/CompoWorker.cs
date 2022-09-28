using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompoWorker : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed = 1.0f;

    [SerializeField]
    private float _rotationSpeed = 1.5f;

    private Animator _animator;

    private bool _moving = false;
    private bool _rotating = false;

    private Vector3 _movePoint;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_moving)
        {
            if (_rotating)
            {
                Vector3 targetDirection = _movePoint - transform.position;

                Vector3 newDirection = Vector3.RotateTowards(
                    transform.forward,
                    targetDirection,
                    _rotationSpeed * Time.deltaTime,
                    0.0f
                );

                if (Vector3.Angle(targetDirection, newDirection) < 1.0f)
                {
                    _rotating = false;

                    _animator.SetBool("idle", false);
                    _animator.SetBool("running", true);
                }
                else
                {
                    transform.rotation = Quaternion.LookRotation(newDirection);
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    _movePoint,
                    _movementSpeed * Time.deltaTime
                );

                if (transform.position.Equals(_movePoint))
                {
                    _animator.SetBool("idle", true);
                    _animator.SetBool("running", false);

                    _moving = false;
                }
            }
        }
    }

    public void StartMovement(Vector3 movePoint)
    {
        if (!_moving)
        {
            _movePoint = movePoint;

            _rotating = true;
            _moving = true;
        }
    }
}
