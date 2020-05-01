using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private GameObject sprite;
    [SerializeField] private GameObject deathExplossionPrefab;
    [SerializeField] Animator fadeOutAnimatr;

    private bool isDead;
    public int health;
    public int gems;

    private Rigidbody2D rigidbody;

    private const float inviTime = 0.5f;
    private float timer = 2f;

    private void Start()
    {
        gems = PlayerData.GetGems();
        health = PlayerData.GetHealth();
        rigidbody = GetComponent<Rigidbody2D>();
        isDead = false;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (transform.position.y < -7) DamagePlayer(100, false);
    }

    public void DamagePlayer(int damage, bool push)
    {
        if (timer > 0 || isDead) return;

        ScreenshakeHandler.AddScreenShake(15, 5, 0.3f);
        timer = inviTime;
        health -= damage;
   
        hitSound.Play();
        if (push) rigidbody.AddForce(new Vector2(0, 750));

        if (health <= 0)
        {
            PlayerData.SaveHealth(5);
            isDead = true;
            health = 0;
            sprite.SetActive(false);
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<CapsuleCollider2D>().enabled = false;

            var deathEffect = Instantiate(deathExplossionPrefab, transform.position, transform.rotation);
            deathEffect.transform.parent = null;

            Destroy(deathEffect, 6f);
            ScreenshakeHandler.AddScreenShake(25, 5, 0.6f);
            Invoke("FadeOut", 2f);
            Invoke("ReloadScene", 3f);
        }
        else
        {
            ScreenshakeHandler.AddScreenShake(15, 5, 0.3f);
        }
    }

    private void FadeOut()
    {
        fadeOutAnimatr.SetTrigger("Fade Out");
    }


    private void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
}
