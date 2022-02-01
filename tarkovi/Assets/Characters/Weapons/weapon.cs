
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Geopoly/New Weapon Config")]

public class weapon : ScriptableObject
{
    [Header("Modify Transform")]
    [Tooltip("Szia dave")]
    public Vector3 AdjustPosition = Vector3.zero;
    public Quaternion AdjustRotation = Quaternion.identity;
    public Vector3 AdjustScale = Vector3.one;
    [Space]
    public GameObject mass;


}