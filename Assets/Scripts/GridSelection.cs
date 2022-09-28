using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSelection : MonoBehaviour
{
    [SerializeField]
    private LayerMask _layerMask = 1 << 6;

    private Transform _characterSelector;

    private CompoWorker _compoWorker;

    // Start is called before the first frame update
    void Start()
    {
        _characterSelector = transform.Find("PS_Character_Selection");

        _compoWorker = GameObject.Find("CompoWorker").GetComponent<CompoWorker>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask))
        {
            Vector3 movePoint = new Vector3(
                Mathf.Round(hit.point.x * 0.5f) * 2.0f,
                0.0f,
                Mathf.Round(hit.point.z * 0.5f) * 2.0f
            );

            _characterSelector.gameObject.SetActive(true);

            _characterSelector.transform.position = new Vector3(
                movePoint.x,
                _characterSelector.transform.position.y,
                movePoint.z
            );

            if (Input.GetMouseButtonDown(0))
            {
                _compoWorker.StartMovement(movePoint);
            }
        }
        else
        {
            _characterSelector.gameObject.SetActive(false);
        }
    }
}
