using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCreator
{
    GameObject[] particlePool;
    Transform pollHolder;

    GameObject particlePrefab;

    public ParticleCreator()
    {
        particlePrefab = Resources.Load("Objects/PopEffect", typeof(GameObject)) as GameObject;

        Setup_ParticlesPool(20);
    }

    public void SpawnParticle(Vector3 spawnPos)
    {
        GameObject particle = Get_FreeParticle();
        particle.transform.position = spawnPos;

        particle.SetActive(true);
    }

    private void Setup_ParticlesPool(int count)
    {
        particlePool = new GameObject[count];
        pollHolder = new GameObject("PoolHolder_PopEffects").transform;

        for (int i = 0; i < particlePool.Length; i++)
        {
            GameObject particle_obj = MonoBehaviour.Instantiate(particlePrefab, pollHolder);
            particle_obj.SetActive(false);

            particlePool[i] = particle_obj;
        }
    }

    private GameObject Get_FreeParticle()
    {
        foreach (GameObject particle in particlePool)
        {
            if (!particle.activeInHierarchy)
                return particle;
        }

        Debug.LogError("Missing particle prefabs, add more into pool");
        return null;
    }

    public void Reset_ActiveParticles()
    {
        for (int i = 0; i < particlePool.Length; i++)
        {
            GameObject particle = particlePool[i];
            if (particle.activeInHierarchy)
                particle.SetActive(false);
        }
    }
}
