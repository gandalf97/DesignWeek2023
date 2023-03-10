using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);

    }

    private void Update()
    {
        if(Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
