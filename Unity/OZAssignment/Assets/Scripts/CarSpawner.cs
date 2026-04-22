using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    public Transform spawnPos;
    public GameObject carRoot;

    //void OnEnable()
    //{
    //    // 실체화 후 부모 설정
    //    var car = Instantiate(carPrefab, spawnPos);
    //    car.transform.SetParent(carRoot.transform);
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPrefab();
        }
    }

    private void SpawnPrefab()
    {
        // 실체화와 함께 부모 설정
        Instantiate(carPrefab, spawnPos.position, Quaternion.identity, carRoot.transform);
    }
}
