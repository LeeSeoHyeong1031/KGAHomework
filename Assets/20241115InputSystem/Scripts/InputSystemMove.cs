using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Context = UnityEngine.InputSystem.InputAction.CallbackContext;

public class InputSystemMove : MonoBehaviour
{
	#region Private Components
	private Animator anim;
	private CharacterController cc;
	#endregion

	public float moveSpeed;

	private Vector2 inputDir;

	private void Awake()
	{
		cc = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		Move();
	}

	public void OnMove(Context context)
	{
		inputDir = context.ReadValue<Vector2>();
	}

	private void Move()
	{
		inputDir = Vector2.ClampMagnitude(inputDir, 1);
		//print($"inputDir x, y 蔼 : {inputDir.x}, {inputDir.y}");

		Vector3 moveInputDir = new Vector3(inputDir.x, 0, inputDir.y) * moveSpeed;
		Vector3 actualMoveDir = transform.TransformDirection(moveInputDir);
		cc.Move(actualMoveDir * Time.deltaTime);

		//局聪皋捞记 贸府
		anim.SetFloat("Speed", inputDir.magnitude);
		anim.SetFloat("dirX", inputDir.x);
		anim.SetFloat("dirY", inputDir.y);
	}
}
