using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour
{
    private ColorChanger _colorChanger;

    private float _minDelay = 2;
    private float _maxDelay = 5;
    private bool _isTouched;
    private bool _isColorChanged;

    public event UnityAction<Cube> CubeDeactivated;

    public bool IsColorChanged => _isColorChanged;

    private void Awake()
    {
        _colorChanger = new ColorChanger();
    }

    private void OnEnable()
    {
        _isTouched = false;
        _isColorChanged = false;

        _colorChanger.SetDefaultColor(this);
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

            _colorChanger.SetRandomColor(this);

            _isColorChanged = true;

            StartCoroutine(DelayDestroying());
        }
    }

    private IEnumerator DelayDestroying()
    {
        yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));

        CubeDeactivated?.Invoke(this);
    }
}
