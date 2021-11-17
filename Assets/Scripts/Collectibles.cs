using System;
using System.Collections.Generic;
using DefaultNamespace.Enums;
using UnityEngine;

namespace DefaultNamespace
{
    public class Collectibles : MonoBehaviour
    {
        public Material[] collectibleMaterial;
        private MeshRenderer collectibleRend;

        [SerializeField] private MaterialChanger collectiblePrefab;
        [SerializeField] private Transform modelRoot;
        private List<MaterialChanger> collectibles = new List<MaterialChanger>();
        
        [SerializeField] private ObjectColor collectibleColor;
        public ObjectColor ObjectColor => collectibleColor;
        
        [SerializeField] private int NumberofObjects;
        public int objectNumber => NumberofObjects;
       
        private void Awake()
        {
            collectibleRend = GetComponent<MeshRenderer>();
            CreateNewCollectible();
        }
        
        public void ChangeCollectibleMaterial(ObjectColor collectibleColor)
        {
            switch (collectibleColor)
            {
                case ObjectColor.Yellow:
                    collectibleRend.material = collectibleMaterial[0];
                    break;
                case ObjectColor.Green:
                    collectibleRend.material = collectibleMaterial[1];
                    break;
                case ObjectColor.Blue:
                    collectibleRend.material = collectibleMaterial[2];
                    break;
                case ObjectColor.Pink:
                    collectibleRend.material = collectibleMaterial[3];
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        public void CreateNewCollectible()
        {
            for (int i = 0; i < NumberofObjects; i++)
            {
                var collectibleClone = 
                    Instantiate(collectiblePrefab, 
                        modelRoot.position + new Vector3(0, i * .8f, 0), 
                        modelRoot.rotation, modelRoot);
                collectibleClone.ChangeMaterial(collectibleColor);
                collectibles.Add(collectibleClone);
            }

        }
    }
}