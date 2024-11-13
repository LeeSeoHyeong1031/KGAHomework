using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private NavMeshAgent nav;
	public Transform point;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out RaycastHit hit, 1000f, 1 << LayerMask.NameToLayer("Plane")))
			{
				nav.SetDestination(hit.point);
			}
		}
	}
}
