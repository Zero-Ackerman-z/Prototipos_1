using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonNotPersistent<T> : MonoBehaviour
    where T : Component
{
    public static T instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
