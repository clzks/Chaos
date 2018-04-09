using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;       // 네브메쉬를 사용하기 위한 네임스페이스 추가


[RequireComponent(typeof(NavMeshAgent))]
public class PlayerControl : MonoBehaviour
{

    NavMeshAgent navMesh = null;
    private Animator charAnim;
    // private bool isMove = false;
    // private bool isAttack = false;
    public float HP = 100.0f;
    public float ATK = 10.0f;

    private void Awake()
    {
        navMesh = this.GetComponent<NavMeshAgent>();
        charAnim = this.GetComponentInChildren<Animator>();
        
        // 자동 회전을 하지 않도록 한다.
        navMesh.updateRotation = false;
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.S))
            navMesh.ResetPath();        // 설정 된 경로를 지운다.

        if (navMesh.path.corners.Length > 1)
        {
            Vector3 lookDir = navMesh.path.corners[1] - navMesh.path.corners[0];
            lookDir.y = 0.0f;
            this.transform.rotation = Quaternion.LookRotation(lookDir.normalized, Vector3.up);
        }
    }

    private void LateUpdate()
    {
       if(navMesh.velocity.magnitude > 0)
       {
            charAnim.SetBool("isMove", true);
       }
       else
       {
            charAnim.SetBool("isMove", false);
        }
    }

    public void MoveOrder(Vector3 dest)
    {
        navMesh.SetDestination(dest);   // 목적지 설정
    }

    private void OnDrawGizmos()
    {
        // 캐릭터의 포워드 방향으로 라인 그리기
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(this.transform.position,
            this.transform.position + this.transform.forward * 3.0f);

        if (navMesh)
        {
            // 캐릭터가 이동하는 방향으로 이동하는 속도의 크기로 라인 그리기
            Gizmos.color = Color.red;
            Gizmos.DrawLine(this.transform.position,
                this.transform.position + navMesh.velocity);

            for (int i = 0; i < navMesh.path.corners.Length; ++i)
            {
                // 네브메쉬에서 지정 된 코너마다 와이어스피어를 그린다.
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(navMesh.path.corners[i], 1.0f);
            }
        }
    }
}
