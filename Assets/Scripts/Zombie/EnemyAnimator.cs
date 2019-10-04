using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAnimator : MonoBehaviour {

    private Animator animator;

	void Awake () {
        animator = GetComponent<Animator>();	
	}
	
    public void Walk(bool walk) {
        //anim.SetBool(AnimationTags.WALK_PARAMETER, walk);
        animator.SetBool("Walk", walk);
    }
/* 
    public void Run(bool run) {
        anim.SetBool(AnimationTags.RUN_PARAMETER, run);
    }
    */

    public void Attack() {
        animator.SetTrigger("Atack");
    }

    public void Dead() {
        animator.SetTrigger("Dead");
        Destroy(gameObject, 2.0f);
    }

} 



