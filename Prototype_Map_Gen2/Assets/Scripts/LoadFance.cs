using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFance : MonoBehaviour
{

    [SerializeField] 
    private GameObject[] HorizontalFenceGoPos;
    [SerializeField] 
    private GameObject[] VerticalFenceGoPos;

    [SerializeField] private GameObject[] HorizontalFencePrefabs;
    [SerializeField] private GameObject[] VerticalFencePrefabs;


    private void Awake()
    {
        SetFenceToPos();
    }

    private void SetFenceToPos()
    {
        SetFenceToPosHorizontal();
        SetFenceToPosVertical();
    }
    
    private void SetFenceToPosHorizontal()
    {
        for (int i = 0; i < HorizontalFenceGoPos.Length; i++)
        {
            if (Random.Range(0, 2) == 1)
            {
               Instantiate(HorizontalFencePrefabs[Random.Range(0, HorizontalFencePrefabs.Length)], HorizontalFenceGoPos[i].transform.position, Quaternion.identity);
               
            }
        }
    }

    private void SetFenceToPosVertical()
    {
        for (int i = 0; i < VerticalFenceGoPos.Length; i++)
        {
            if (Random.Range(0, 2) == 1)
            {
                Instantiate(VerticalFencePrefabs[Random.Range(0, VerticalFencePrefabs.Length)], VerticalFenceGoPos[i].transform.position, Quaternion.identity);
            } 
        }
    }
}
