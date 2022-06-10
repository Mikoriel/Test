using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 10;
    private int Health;

    public AudioClip se1;//被ダメ音
    public float seVolume;

    private void Start()
    {
        Health = maxHealth;

        AudioSource se = GetComponent<AudioSource>();
        se.volume = seVolume;
    }

    public bool IsAllive()
    {
        return Health > 0 ? true : false;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    //ここに敵と接触したらダメージを受ける関数と被ダメ音を鳴らす

}

