using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MolotovCocktail : MonoBehaviour
{
    public GameObject fireEffectPrefab; // Assign the fire particle system prefab in the Inspector
    public AudioClip igniteSound; // Assign the ignite sound in the Inspector
    private bool hit = false;
     public GameObject player;
    public GameObject DamageSphere;
    private void OnCollisionEnter(Collision collision)
    {        
        if(collision.gameObject.tag == "Player")
        {
            return;
        }
        print(collision.collider.name);
        if (!hit)
        {
            hit = true;

            // Instantiate the fire particle effect
            GameObject fireEffect = Instantiate(fireEffectPrefab, collision.contacts[0].point, Quaternion.LookRotation(collision.contacts[0].normal));
            GameObject sphere = Instantiate(DamageSphere, fireEffect.transform.position, fireEffect.transform.rotation);
            sphere.GetComponent<MolotovSphere>().player = player;
            // Play the ignite sound
            AudioSource.PlayClipAtPoint(igniteSound, fireEffect.transform.position);

            // Destroy the Molotov cocktail object (you might want to disable it instead, depending on your game design)
            Destroy(fireEffect, 5f);
            Destroy(gameObject, 6);
        }
    }


}
