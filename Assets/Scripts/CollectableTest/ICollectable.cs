using UnityEngine;

public interface ICollectable
{
    public void Collect(Transform parent);

    public void Drop();

    public void Throw(Vector3 direction);
}
