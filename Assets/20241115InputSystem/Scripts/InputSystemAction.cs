using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using Context = UnityEngine.InputSystem.InputAction.CallbackContext;

public class InputSystemAction : MonoBehaviour
{
	private Animator anim;
	private Rig handRig;

	//���� ����
	public float attackInterval;

	private float lastAttackTime;
	private bool isFiring;

	[Header("�ִϸ��̼� Ŭ��")]
	public AnimationClip reloadClip;
	public AnimationClip grenadeClip;

	private void Awake()
	{
		anim = GetComponent<Animator>();
		handRig = GetComponent<RigBuilder>().layers[0].rig;
	}

	public void OnReload(Context context)
	{
		StartCoroutine(ReloadCoroutine());
	}

	public void OnGrenade(Context context)
	{
		StartCoroutine(GrenadeCoroutine());
	}

	public void OnFire(Context context)
	{
		if (context.performed)
		{
			print("OnFire�� ������ ����");
			isFiring = true;
			anim.SetBool("isFiring", true);
			StartCoroutine(FireCoroutine());
		}
		else
		{
			print("OnFire ��ư�� ����");
			isFiring = false;
			anim.SetBool("isFiring", false);
		}
	}

	private IEnumerator ReloadCoroutine()
	{
		handRig.weight = 0f;
		anim.SetTrigger("Reload");
		yield return new WaitForSeconds(reloadClip.length);
		handRig.weight = 1f;
	}

	private IEnumerator GrenadeCoroutine()
	{
		handRig.weight = 0f;
		anim.SetTrigger("Grenade");
		yield return new WaitForSeconds(grenadeClip.length);
		handRig.weight = 1f;
	}

	private IEnumerator FireCoroutine()
	{
		while (isFiring)
		{
			if (Time.time >= lastAttackTime)
			{
				lastAttackTime = Time.time + attackInterval;
				anim.SetTrigger("Fire");
				print("�߻���");
			}
			yield return null;
		}
	}
}
