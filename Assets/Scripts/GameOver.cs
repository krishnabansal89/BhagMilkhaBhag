using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject canva;

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        canva.SetActive(true);
        Time.timeScale = 0f;
    }
}
