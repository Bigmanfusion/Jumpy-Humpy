using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPortal : MonoBehaviour
{
    private bool enterAllowed;
    private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Portal>())
        {
            sceneToLoad = "Victory";
            enterAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent <Portal>())
        {
            enterAllowed = false;
        }
    }




    // Update is called once per frame
    private void Update()
    {
        if (enterAllowed && Input.GetKeyDown(KeyCode.Z))
        {

            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
