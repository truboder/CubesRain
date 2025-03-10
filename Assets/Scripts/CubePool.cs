using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private int _capacity;

    private Queue<Cube> _cubes = new Queue<Cube>();

    private void OnEnable()
    {
        _cube.CubeDeactivated += Return;
    }

    private void OnDisable()
    {
        _cube.CubeDeactivated -= Return;
    }

       private void Awake()
    {
        for (int i = 0; i < _capacity; i++)
        {
            _cubes.Enqueue(Instantiate(_cube));
        }

        foreach (Cube cube in _cubes)
        {
            cube.gameObject.SetActive(false);
        }
    }

    public Cube Get()
    {
        if (_cubes.Count == 0)
        {
            ExpandPool();   
        }
         
        Cube newCube = _cubes.Dequeue();
        newCube.gameObject.SetActive(true);

        return newCube;
    }

    public void Return(Cube cube)
    {
        cube.gameObject.SetActive(false);
        _cubes.Enqueue(cube);   
    }

    private void ExpandPool()
    {
        Cube cube = Instantiate(_cube);
        _cubes.Enqueue(cube);
    }
}
