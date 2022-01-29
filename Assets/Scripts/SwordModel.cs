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
        if (Input.GetMouseButtonDown(0))
        {
            PlayAnimation();
        }
    }

    void PlayAnimation()
    {
        GetComponent<Animator>().SetTrigger("swing");
    }
}
