using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompoWorker : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0f;

    private Animator _animator;

    private bool _moving = false;

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
            transform.position = transform.position + new Vector3(0, 0, _speed * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0))
        {
            StartMovement();
        }
    }

    IEnumerator Movement()
    {
        _animator.SetBool("idle", false);
        _animator.SetBool("running", true);

        _moving = true;

        yield return new WaitForSeconds(2);

        _animator.SetBool("idle", true);
        _animator.SetBool("running", false);

        _moving = false;
    }

    public void StartMovement()
    {
        if (!_moving)
        {
            StartCoroutine(Movement());
        }
    }
}
