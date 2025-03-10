using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void SetRandomColor(Cube cube)
    {
        if (cube.IsColorChanged)
        {
            return;
        }

        cube.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }

    public void SetDefaultColor(Cube cube)
    {
        cube.GetComponent<Renderer>().material.color = Color.white;
    }
}
