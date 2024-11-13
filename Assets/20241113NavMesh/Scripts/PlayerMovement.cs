using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotSpeed;
    private Vector3 moveDir = Vector3.zero;
    private float eulerAngleX;
    private float eulerAngleY;

    private void Start()
    {
        nav.speed = moveSpeed;
    }

    private void Update()
    {
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");
        moveDir = moveDir.normalized;

        eulerAngleX += Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
        eulerAngleY += Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000f))
            {
                transform.position = hit.point;
            }
        }

        Move(moveDir);
        Rotate();
    }

    private void Move(Vector3 dir)
    {
        transform.Translate(dir * nav.speed * Time.deltaTime);
    }

    private void Rotate()
    {
        eulerAngleY = Mathf.Clamp(eulerAngleY, -30f, 30f);
        transform.localRotation = Quaternion.Euler(-eulerAngleY, eulerAngleX, 0);
    }
}
