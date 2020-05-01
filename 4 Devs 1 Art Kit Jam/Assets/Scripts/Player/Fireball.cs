using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] AudioSource bounceSound;
    [SerializeField] bool damagePlayer;

    [SerializeField] float fireballLifetime = 5f;

    [SerializeField] GameObject particles;
    [SerializeField] float particleLifetime;

    [SerializeField] GameObject deathEffectPrefab;
    [SerializeField] float deathEffectLifetime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyFireball", fireballLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyFireball()
    {
        if (!damagePlayer) ScreenshakeHandler.AddScreenShake(3, 5, 0.1f);

        //Decouple particles
        particles.transform.parent = null;
        particles.GetComponent<ParticleSystem>().Stop();
        Destroy(particles, particleLifetime);

        //Effect
        var deathEffect = Instantiate(deathEffectPrefab, transform.position, transform.rotation);
        Destroy(deathEffect, deathEffectLifetime);

        //Destory Self
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bounceSound.pitch = Random.Range(0.8f, 1.2f);
        bounceSound.Play();

        if (!damagePlayer) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().DamagePlayer(1, false);
            DestroyFireball();
        }
    }

}
