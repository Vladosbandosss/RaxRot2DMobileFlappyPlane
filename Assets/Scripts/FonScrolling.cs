using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FonScrolling : MonoBehaviour
{
    [SerializeField] private float speed = 0.3f;
    Material backgroundMaterial;
    
    private void Start()
    {
        backgroundMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        Vector2 offset =new Vector2( speed * Time.deltaTime,0);
        backgroundMaterial.mainTextureOffset += offset;
    }
    
    public void StopScroll()
    {
        speed = 0f;
    }
}
