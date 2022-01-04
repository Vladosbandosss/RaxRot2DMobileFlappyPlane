using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    public static SoundManger instanse;
     private AudioSource soundFx;

    [SerializeField]private AudioSource BG;
    [SerializeField]private AudioSource propeler;

    [SerializeField]  AudioClip coinCollect;
    [SerializeField]  AudioClip playerDie;

    private void Awake()
    {
        if (instanse == null)
        {
            instanse = this;
        }

        soundFx=GetComponent<AudioSource>();
      
    }
    public void SoundCollect()
    {
       
       soundFx.PlayOneShot(coinCollect);
    }

    public void PlayerDie()
    {
      soundFx.PlayOneShot(playerDie);
      
    }

    public void StopMusic()
    {

        PlayerDie();

        StartCoroutine(nameof(StopAllMusic));
    }

    IEnumerator StopAllMusic()
    {
        yield return new WaitForSeconds(1f);

        BG.Stop();
        propeler.Stop();
        
    }
   

    
}
