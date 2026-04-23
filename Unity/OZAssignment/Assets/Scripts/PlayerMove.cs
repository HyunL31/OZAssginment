using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpPower = 5.0f;
    public float collideDis = 30f;
    public float angle = 5f;

    private bool _isForward = true;
    private bool _isRight = false;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _isForward = true;
            _isRight = false;

            Move();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _isForward = false;
            _isRight = false;

            Move();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _isForward = false;
            _isRight = true;

            Move();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _isForward = true;
            _isRight = true;

            Move();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Rotation(-angle);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            Rotation(angle);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        Shoot();
    }

    private void Move()
    {
        Vector3 dir = Vector3.forward;

        if (_isForward && !_isRight)
        {
            dir = Vector3.forward;
        }
        else if (!_isForward && !_isRight)
        {
            dir = Vector3.back;
        }
        else if (!_isForward && _isRight)
        {
            dir = Vector3.right;
        }
        else
        {
            dir = Vector3.left;
        }

        transform.Translate(dir * Time.deltaTime * moveSpeed);
    }

    private void Rotation(float angle)
    {
        transform.Rotate(Vector3.up * angle);
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
    }

    private void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, collideDis))
        {
            Debug.Log($"몬스터 {hit.collider.gameObject.name}이(가) Ray에 맞았습니다!");

            Destroy(hit.collider.gameObject);
        }
    }
}
