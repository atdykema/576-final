using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LostCanvas : MonoBehaviour
{
    public AudioClip lostSound;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.PlayOneShot(lostSound,1.0f);
    }

    // Called when user presses: 
    // Start Helping Mungo
    public void StartPressed()
    {
        SceneManager.LoadScene("MainScene");
    }
}
