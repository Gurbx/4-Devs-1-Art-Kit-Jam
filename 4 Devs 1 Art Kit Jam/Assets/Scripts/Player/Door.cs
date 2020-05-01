using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] Animator fadeOutAnimatr;
    [SerializeField] private string sceneName;
    private bool canEnter = false;
    private bool triggered = false;


    private void Update()
    {
        if (triggered) return;
        if (canEnter && Input.GetKeyDown(KeyCode.E))
        {
            triggered = true;
            PlayerData.SaveData(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().health,
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().gems);

            fadeOutAnimatr.SetTrigger("Fade Out");
            Invoke("ChangeScene", 1.1f);
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canEnter = false;
        }
    }
}
