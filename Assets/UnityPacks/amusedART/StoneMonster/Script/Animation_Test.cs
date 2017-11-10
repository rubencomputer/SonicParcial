using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Test : MonoBehaviour {

	public  string IDLE	= "Anim_Idle";
	public  string RUN		= "Anim_Run";
	public  string ATTACK	= "Anim_Attack";
	public  string DAMAGE	= "Anim_Damage";
	public  string DEATH	= "Anim_Death";

	public Animation anim;

	void Start () {


	}
	
	public void IdleAni (){
		anim.CrossFade (IDLE);
	}

	public void RunAni (){
		anim.CrossFade (RUN);
	}

	public void AttackAni (){
		anim.CrossFade (ATTACK);
	}

	public void DamageAni (){
		anim.CrossFade (DAMAGE);
	}

	public void DeathAni (){
		anim.CrossFade (DEATH);
	}

}
