using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static int wishesLeft = 4;
    public static string finalScene;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        Debug.Log(wishesLeft);
    }

    public void endTheGame()
    {
        GameObject.Find("Fondu").GetComponent<PanelHandling>().fadeIn();
        GameObject.Find("SceneManager").GetComponent<AudioManager>().fadeOutMainMusic();
        StartCoroutine("loadProper");
    }

    private IEnumerator loadProper()
    {
        yield return new WaitForSeconds(2);
        if (wishesLeft <= 0 && SceneManager.GetActiveScene().name != "Day7")
            SceneManager.LoadScene(7);

        else
            SceneManager.LoadScene(8);
    }
}
