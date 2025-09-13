using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void Change(Capsule capsule)
    {
        capsule.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }
}
