using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifeCoin : MonoBehaviour
{
    public AudioClip picMoney;
    public AudioClip picHealth;
    private AudioSource audioSource;
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnMouseDown()
    {
        if (tag == "Life")
        {
            PlayerStats.Lives++;
            StartCoroutine(PlaySound(picHealth));
        }
        else
        {
            PlayerStats.Money += 100;
            StartCoroutine(PlaySound(picMoney));
        }
    }


    IEnumerator PlaySound(AudioClip clip)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        audioSource.PlayOneShot(clip, 1.0f);
        yield return new WaitForSeconds(clip.length);
        Destroy(gameObject);
    }

}
