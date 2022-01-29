using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordModel : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void PlayAnimation()
    {
        GetComponent<Animator>().SetTrigger("swing");
    }
}
