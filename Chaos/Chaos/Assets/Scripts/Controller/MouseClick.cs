using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerControl))]
public class MouseClick : MonoBehaviour
{
    private PlayerControl navMeshMove;

    private void Awake()
    {
        navMeshMove = this.GetComponent<PlayerControl>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // 카메라 기준으로 스크린 좌표에서 월드 공간의 레이를 생성
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                navMeshMove.MoveOrder(hit.point);
            }
        }
    }
}
