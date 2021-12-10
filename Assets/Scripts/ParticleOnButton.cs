using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnButton : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particleSystemPrefab;
     
    private ParticleSystem _particleSystemOnStage;

    public void CreateParticle()
    {
        if (_particleSystemOnStage == null)
        {
            _particleSystemOnStage = Instantiate(_particleSystemPrefab,gameObject.transform);
        }
    }
}
