using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    [SerializeField] private Animator fadeOutAnimatr;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerData.SaveData(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().health,
                 GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().gems);
            FadeOut();
            Invoke("ChangeScene", 1.1f);
        }
    }

    private void FadeOut()
    {
        fadeOutAnimatr.SetTrigger("Fade Out");
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("EndScene");
    }
}
