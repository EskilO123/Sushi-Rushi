using UnityEngine;

[CreateAssetMenu(fileName = "ContainerSO", menuName = "Scriptable Objects/ContainerSO")]
public class ContainerSO : ScriptableObject
{
    [SerializeField] GameObject containedPrefab;

    public GameObject GetContainedObject()
    {
        return containedPrefab;
    }
}
