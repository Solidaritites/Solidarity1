using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persist : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (FindObjectOfType<Persist>())
        {
            Destroy(this);
        }
    }
}
