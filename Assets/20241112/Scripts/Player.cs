using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private CharacterController cc;
	public float moveSpeed;
	public float rotateSpeed;
	public LayerMask layerMask;

	private void Update()
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputZ = Input.GetAxis("Vertical");
		Move(new Vector3(inputX, 0, inputZ));
	}

	private void Move(Vector3 dir)
	{
		cc.Move(dir * moveSpeed * Time.deltaTime);
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if ((Mathf.Pow(2, hit.gameObject.layer)) == (int)layerMask)
		{
			hit.collider.GetComponent<Renderer>().material.color = Color.magenta;
		}
	}
}
