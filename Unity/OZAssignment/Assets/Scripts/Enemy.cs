using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed = 10f;

    private GameObject player;
    private Rigidbody rb;

    void Awake()
    {
        player = GameObject.Find("Player");

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        gameObject.transform.LookAt(player.transform.position);

        FollowPlayer();
    }

    private void FollowPlayer()
    {
        // Translate : 회전(LookAt)과 이동이 따로 진행
        // 적 오브젝트들이 회오리 치듯이 밀리고 모인다.
        //gameObject.transform.Translate(player.transform.position * Time.deltaTime * enemySpeed);

        // 플레이어와 적 오브젝트 사이의 거리를 구한다.
        // 제미나이 : 단순히 거리의 차이만 구하면 안됨
        // 벡터의 방향만 필요하기에 크기를 1로 정규화해야 한다. (.normalized가 이를 정규화한다.)
        Vector3 dir = (player.transform.position - gameObject.transform.position).normalized;

        rb.linearVelocity = dir * enemySpeed;
    }
}
