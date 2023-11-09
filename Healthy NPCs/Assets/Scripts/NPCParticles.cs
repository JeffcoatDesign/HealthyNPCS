using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathParticlePrefab;

    private void Start()
    {
        GetComponent<IHealth>().OnDied += HandleNPCDied;
    }

    private void HandleNPCDied()
    {
        var deathParticle = Instantiate(deathParticlePrefab, transform.position, transform.rotation);
        Destroy(deathParticle, 4f);
    }
}
