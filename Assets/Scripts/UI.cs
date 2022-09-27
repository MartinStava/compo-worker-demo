using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private CompoWorker _compoWorker;

    // Start is called before the first frame update
    void Start()
    {
        _compoWorker = GameObject.Find("CompoWorker").GetComponent<CompoWorker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _compoWorker.StartMovement();
        }
    }
}
