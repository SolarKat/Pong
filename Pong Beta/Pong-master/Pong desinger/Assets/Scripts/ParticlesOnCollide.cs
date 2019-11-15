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

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("solid"))
        {
            GameObject firework = Instantiate(FireworksAll, coll.contacts[0].point, Quaternion.identity);
            firework.GetComponent<ParticleSystem>().Play();
        }
    }
}
