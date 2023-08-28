using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Main_Menu_Script : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator titleText, buttonText;
    void Start()
    {
        StartCoroutine(StartMainMenu());
    }

    private IEnumerator StartMainMenu()
    {
        yield return new WaitForSeconds(.3f);
        titleText.Play("Title_Animation");
        yield return new WaitForSeconds(5f);
        titleText.Play("Text_Glitching");
    }
    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }

    private IEnumerator StartGameCoroutine()
    {
        yield return new WaitForSeconds(.3f);
        titleText.Play("Title_Animation_Next");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
