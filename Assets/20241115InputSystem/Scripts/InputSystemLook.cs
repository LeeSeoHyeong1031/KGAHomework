using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Context = UnityEngine.InputSystem.InputAction.CallbackContext;

public class InputSystemLook : MonoBehaviour
{
	public Transform cameraRig;
	public float mouseSensivity; //���콺 ����

	private Vector2 inputDir;


	public void OnLook(Context context)
	{
		inputDir = context.ReadValue<Vector2>();
		Look();
	}

	private void Look()
	{
		inputDir = Vector2.ClampMagnitude(inputDir, 1);

		//��, �� ȸ�� ����
		Vector3 lookInputDirX = new Vector3(0, inputDir.x, 0) * mouseSensivity;
		transform.Rotate(lookInputDirX * Time.deltaTime);

		//��, �� ȸ�� ����
		//���� ī�޶� ���� ���� �ȵ�.
		Vector3 lookInputDirY = new Vector3(-inputDir.y, 0, 0) * mouseSensivity;
		cameraRig.Rotate(lookInputDirY * Time.deltaTime);
	}
}
