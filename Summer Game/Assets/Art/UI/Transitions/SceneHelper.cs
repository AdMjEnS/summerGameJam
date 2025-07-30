using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour
{
    private string sceneToLoad;

    [SerializeField] private Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        transition = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QueueScene(string scene)
    {
        sceneToLoad = scene;

        transition.SetTrigger("Next");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
