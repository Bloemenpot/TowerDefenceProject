using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager
{
    public virtual void Awake()
    {
        Debug.Log($"Waking Manager: {GetType()}");
    }

    public virtual void Start()
    {
        Debug.Log($"Starting Manager: {GetType()}");
    }

    public virtual void Update()
    {

    }

    public virtual void Pause()
    {
        Debug.Log($"Pausing Manager: {GetType()}");
    }

}
