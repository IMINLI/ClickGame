using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]//attribut //強制掛Animator
[RequireComponent(typeof(MeshFader))]
public class EnemyBehavier : MonoBehaviour {

    private Animator animator;//指標
    private MeshFader meshFader;
    private AudioSource audioSource;
    private HealthComponent healthComponent;
    [SerializeField]
    private AudioClip hurtClip;
    private void Awake()
    {
        animator = GetComponent<Animator>();//設定指標
        //animator.SetTrigger("die"); 
        meshFader = GetComponent<MeshFader>();
        audioSource = GetComponent<AudioSource>();
        healthComponent = GetComponent<HealthComponent>();
    }
	
    private void DoDamage(int attack)
    {
        animator.SetTrigger("hurt");
        audioSource.clip = hurtClip;
        audioSource.Play();
        healthComponent.Hurt(attack);
    }
    private void Update()
    {
        if (healthComponent.IsOver)
            return;
        if(Input.GetButtonDown("Fire1"))//滑鼠左鍵
        {
            DoDamage(10);//扣10滴血
        }
    }
}
