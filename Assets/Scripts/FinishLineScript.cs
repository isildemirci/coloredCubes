using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLineScript : MonoBehaviour
{
    public GameObject endScreen;
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.CompareTag("FinishLine"))
        {
            endScreen.gameObject.SetActive(true);
        }
    }
}
