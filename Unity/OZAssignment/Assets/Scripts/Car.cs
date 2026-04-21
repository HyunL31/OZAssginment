using UnityEngine;

public class Car : MonoBehaviour
{
    private PureClass pureClass = new PureClass();

    private bool _fixedDid = false;
    private bool _updateDid = false;
    private bool _lateUpdate = false;

    void Awake()
    {
        Debug.Log("Awake입니다.");

        pureClass.Print();
    }

    void OnEnable()
    {
        Debug.Log("OnEnable입니다.");
    }

    void Start()
    {
        Debug.Log("불응불응~ Start입니다.");
    }

    void FixedUpdate()
    {
        if (_fixedDid)
        {
            return;
        }
        else
        {
            Debug.Log("FixedUpdate입니다.");
            _fixedDid = true;
        }
    }

    void Update()
    {
        if (_updateDid)
        {
            return;
        }
        else
        {
            Debug.Log("Update입니다.");
            _updateDid = true;
        }
    }

    void LateUpdate()
    {
        if (_lateUpdate)
        {
            return;
        }
        else
        {
            Debug.Log("LateUpdate입니다.");
            _lateUpdate = true;
        }
    }

    void OnDisable()
    {
        Debug.Log("OnDisable입니다.");
    }

    void OnDestroy()
    {
        Debug.Log("Destroy입니다.");
    }
}
