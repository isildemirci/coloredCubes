using System;
using System.Collections.Generic;
using DefaultNamespace.Enums;
using UnityEngine;

namespace DefaultNamespace
{
    public class ColorDoor : MonoBehaviour
    {
        public Material[] doorMaterial;
        private MeshRenderer doorRend;
        
        [SerializeField] private ObjectColor doorColor;
        public ObjectColor ObjectColor => doorColor;
       
        private void Awake()
        {
            doorRend = GetComponent<MeshRenderer>();
            ChangeDoorMaterial(doorColor);
        }
        public void ChangeDoorMaterial(ObjectColor doorColor)
        {
            switch (doorColor)
            {
                case ObjectColor.Yellow:
                    doorRend.material = doorMaterial[0];
                    break;
                case ObjectColor.Green:
                    doorRend.material = doorMaterial[1];
                    break;
                case ObjectColor.Blue:
                    doorRend.material = doorMaterial[2];
                    break;
                case ObjectColor.Pink:
                    doorRend.material = doorMaterial[3];
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}