using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private CubePool _cubePool;

    private float _minDelay = 2;
    private float _maxDelay = 5;
    private bool _isTouched;
    private bool _isColorChanged;

    public void Initialize(CubePool cubePool)
    {
        _cubePool = cubePool;
    }

    private void OnEnable()
    {
        _isTouched = false;
        _isColorChanged = false;

        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            if (_isTouched)
            {
                return;
            }

            _isTouched = true;

            ChangeColor();
            _isColorChanged = true;

            StartCoroutine(DelayDestroying());
        }
    }

    private void ChangeColor()
    {
        if (_isColorChanged)
        {
            return;
        }

        gameObject.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }

    private IEnumerator DelayDestroying()
    {
        yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));
        _cubePool.Return(this);
    }
}
