using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]//attribut //強制掛Animator
[RequireComponent(typeof(MeshFader))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(HealthComponent))]
public class EnemyBehavier : MonoBehaviour {

    private Animator animator;//指標
    private MeshFader meshFader;
    private AudioSource audioSource;
    private HealthComponent healthComponent;
    [SerializeField]
    private AudioClip hurtClip;
    [SerializeField]
    private AudioClip deadClip;

    public EnemyData enemyData;

    public bool IsDead
    {
        get
        {
            return healthComponent.IsOver;
        }
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();//設定指標
        //animator.SetTrigger("die"); 
        meshFader = GetComponent<MeshFader>();
        audioSource = GetComponent<AudioSource>();
        healthComponent = GetComponent<HealthComponent>();
        //GameFacade.GetInstance();  //測試用
    }

    private void OnEnable()
    {
        StartCoroutine(meshFader.FadeIn());
    }

    [ContextMenu("Test Execute")]
    private void TestExecute()
    {
        StartCoroutine(Execute(enemyData));
    }

    public IEnumerator Execute(EnemyData enemyData)
    {
        healthComponent.Init(enemyData.health);
        while(IsDead == false)
        {
            yield return null;
        }
        animator.SetTrigger("die");
        audioSource.clip = deadClip;
        audioSource.Play();
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        yield return StartCoroutine(meshFader.FadeOut());
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
