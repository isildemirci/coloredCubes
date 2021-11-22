using System;
using UnityEngine;
using System.Collections.Generic;
using DefaultNamespace.Enums;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class StackManager : MonoBehaviour
    {
        //Variables
        [SerializeField] private MaterialChanger materialChangerPrefab;
        [SerializeField] private Transform modelRoot;
        public List<MaterialChanger> cubes = new List<MaterialChanger>();
        private Transform _transform;
        public Text cubeCount;
        
        //References
        private ObjectColor objectColor;
        private Collectibles collectibleNumber;
        
        
        
        private void Awake()
        {
            objectColor = ObjectColor.Green;
            _transform = transform;
            CreateNewStack();
        }

        private void ChangeAllStackColors()
        {
            for (int i = 0; i < cubes.Count; i++)
            {
                cubes[i].ChangeMaterial(objectColor);
            }
        }
        
        public void CreateNewStack()
        {
            var cubeClone = 
                Instantiate(materialChangerPrefab, 
                    modelRoot.position + new Vector3(0, cubes.Count * 1, 0), 
                    modelRoot.rotation, modelRoot);
            cubeClone.ChangeMaterial(objectColor);
            cubes.Add(cubeClone);
        }
        
        public void DeleteCube()
        {
            var cube = cubes[cubes.Count - 1];
            cubes.Remove(cube);
            Destroy(cube.gameObject);
            if (cubes.Count < 1)
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        public void CubeCountText()
        {
            cubeCount.text = "Cube: " + (cubes.Count - 1);
        }

        private void OnTriggerEnter(Collider other)
       {
           var otherCube = other.GetComponent<Collectibles>();
           var door = other.GetComponent<ColorDoor>();

           if (otherCube != null)
           {
               if (otherCube.ObjectColor == objectColor)
               {
                   for (int i = 0; i < otherCube.ObjectNumber; i++)
                   {
                       CreateNewStack();
                       CubeCountText();
                   }
                   Destroy(other.gameObject);
               }
               else
               {
                   for (int i = 0; i < otherCube.ObjectNumber; i++)
                   {
                       DeleteCube();
                       CubeCountText();
                   }
                   Destroy(other.gameObject);
               }
           }

           if (door)
           {
               objectColor = door.ObjectColor;
               ChangeAllStackColors();
           }
       }
    }
}