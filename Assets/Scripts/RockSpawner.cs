
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] roks;
    
    private float maxY = 1.8f; 
    private float minY = -2.2f;
    
    private float repeatRate = 1f;
    private float timeBeforeSpawn = 1f;
   
   private void Start()
   {
        InvokeRepeating(nameof(CreateRock),timeBeforeSpawn, repeatRate);
   }
   
    private void CreateRock() 
    {
        int RandomRock = Random.Range(0, roks.Length);
        float randomYPos = Random.Range(minY, maxY);
        Vector2 randSpawnPos = new Vector2(transform.position.x, randomYPos);
        Instantiate(roks[RandomRock], randSpawnPos, Quaternion.identity);
    }
}
