using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    protected virtual void Start()
    {
        ActorManager.Register(this);
    }

    void Update()
    {
        
    }
}
