using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    [SerializeField] private UI uiRef;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            uiRef.EndGame("You fell");
    }
}
