using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
