using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medal : MonoBehaviour
{
    
    private void Start()
    {
        if (Random.Range(0, 6) > 1)
        {
            gameObject.SetActive(false);
        }
    }

}
