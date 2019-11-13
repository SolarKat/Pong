using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesOnCollide : MonoBehaviour
{
    public GameObject FireworksAll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Explode();
        }
    }
    void Explode()
    {
        GameObject firework = Instantiate(FireworksAll, transform.position, Quaternion.identity);
        firework.GetComponent<ParticleSystem>().Play();
    }
}
