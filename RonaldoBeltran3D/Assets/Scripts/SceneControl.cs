using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePlayerData {
    public int itemCount { get; private set; }
    public Vector3 position { get; private set; }
    public Quaternion rotation { get; private set; }

    public void SetData (int itemCount, Vector3 position, Quaternion rotation) {
        this.itemCount = itemCount;
        this.position = position;
        this.rotation = rotation;
    }
}

public class SceneControl : MonoBehaviour
{
    TransitionPanel panel;
    MovScript player;
    static ScenePlayerData persistenPlayerData;
    Vector3 startPoint = new Vector3(3, 1, 8);

    // Start is called before the first frame update
    void Start() {
        if (persistenPlayerData == null)
        {
            persistenPlayerData = new ScenePlayerData();
            persistenPlayerData.SetData(0, startPoint, Quaternion.identity);

        }
        player = GameObject.FindGameObjectWithTag ("Player").GetComponent<MovScript> () ;
        player.activeControl = true;
        panel = TransitionPanel.instance;
        panel.Initialize();
        player.GetComponent<PlayerAtributes>().Initialize ();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void ONGUI() {
        GUI.Label(new Rect(10, 10, 120, 30), "Item collected: " + player.GetComponent<PlayerAtributes>().itemCount);
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
        yield return new WaitForSeconds(1);
        yield return panel.FedeAlpha(1);
        LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return new WaitForSeconds(1);
        yield return panel.FedeAlpha(0);
    }
}
