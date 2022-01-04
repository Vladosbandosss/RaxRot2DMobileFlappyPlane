using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] ParticleSystem exp;
    PlayerMover player;

    private string ENEMYTAG = "Enemy";
    private string COINTAG = "coin";
    private void Start()
    {
        player = GetComponent<PlayerMover>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMYTAG))
        {
            SoundManger.instanse.PlayerDie();
            player.Die();
            GameManger.instance.StopIncreaseScore();
        }

        if (collision.gameObject.CompareTag(COINTAG))
        {
            Instantiate(exp, transform.position, Quaternion.identity);
            SoundManger.instanse.SoundCollect();
            GameManger.instance.IncreaseScore();
            Destroy(collision.gameObject);
        }
    }
}
