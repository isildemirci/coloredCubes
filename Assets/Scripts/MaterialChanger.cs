using System;
using DefaultNamespace.Enums;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public Material[] material;
    private MeshRenderer rend;
    
    [SerializeField] private ObjectColor objectColor;
    public ObjectColor ObjectColor => objectColor;
    private void Awake()
    {
        rend = GetComponent<MeshRenderer>();
        ChangeMaterial(objectColor);
    }
    
    public void ChangeMaterial(ObjectColor objectColor)
    {
        switch (objectColor)
        {
            case ObjectColor.Yellow:
                rend.material = material[0];
                break;
            case ObjectColor.Green:
                rend.material = material[1];
                break;
            case ObjectColor.Blue:
                rend.material = material[2];
                break;
            case ObjectColor.Pink:
                rend.material = material[3];
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
