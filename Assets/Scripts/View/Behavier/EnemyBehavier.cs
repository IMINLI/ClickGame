using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]//attribut //強制掛Animator
public class EnemyBehavier : MonoBehaviour {

    private Animator animator;//指標
    private void Awake()
    {
        animator = GetComponent<Animator>();//設定指標
        //animator.SetTrigger("die"); 
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
