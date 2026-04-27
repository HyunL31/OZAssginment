using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public Transform margin1;
    public Transform margin2;
    public GameObject monsterParent;

    public void EnemySpawn()
    {
        float minX = margin1.position.x;
        float maxX = margin2.position.x;
        float minZ = margin1.position.z;
        float maxZ = margin2.position.z;

        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        Instantiate(monsterPrefab, new Vector3(randomX, 1, randomZ), gameObject.transform.rotation, monsterParent.transform);
    }
}
