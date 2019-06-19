using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    TransitionPanel panel;

    // Start is called before the first frame update
    void Start()
    {
        panel = TransitionPanel.instance;
        panel.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene (int index)
    {
        if (index < SceneManager.sceneCount && index >= 0)
        {
            SceneManager.LoadScene(index);
        }
    }

    void OnTriggerExit (Collider other) {
        if (other.CompareTag("Player")) {
            panel.StartCoroutine (RespawnRoutine ());
        }
    }

    IEnumerator RespawnRoutine  () {
        yield return panel.FedeAlpha(1);
        LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return new WaitForSeconds(1);
        yield return panel.FedeAlpha(0);
    }
}
