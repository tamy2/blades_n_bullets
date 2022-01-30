using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    public bool isEnemy;
    public HealthManager healthManager;

    public Renderer[] renderers;

    private Material mat;
    Texture tex;
    public AudioSource audioSource;

    private float flashTime;

    // Start is called before the first frame update

    void Start()
    {
        if (renderers.Length == 0)
        {
            return;
        }

        mat = Material.Instantiate(renderers[0].material);
        tex = mat.GetTexture("_MainTex");
        foreach (Renderer renderer in renderers)
        {
            renderer.material = mat;
        }
    }

    void Update()
    {
        if (flashTime < 0)
        {
            mat.SetTexture("_MainTex", tex);
        }
        flashTime -= Time.deltaTime;
    }
    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    /*
    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Hitbox>() != null) {
            if (other.gameObject.tag == "player") {
                //player damages everything
            }
            if (other.gameObject.tag == "enemy") {
                if (gameObject.tag == "player") {
                    //enemies don't hurt themselves
                }
            }
        }
    }
    */

    public void PlaySound()
    {
        audioSource.Play();
    }

    public void FlashModel()
    {
        mat.SetTexture("_MainTex", null);
        flashTime = 0.1f;
    }

}